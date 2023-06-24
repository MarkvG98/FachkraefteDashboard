import time

from main.py.connectors import RestApiConnector
import pandas as pd
import json

con = RestApiConnector()



def set_pandas_display_options() -> None:
    # Ref: https://stackoverflow.com/a/52432757/
    display = pd.options.display
    display.max_columns = 1000
    display.max_rows = 5000
    display.max_colwidth = 199
    display.width = 1000


set_pandas_display_options()


def getDictForDE(pagesToShow: int, postalCodes: []) -> []:
    data = []
    it = 1
    for psDict in postalCodes:
        # Fehlervorbeugung, Check ob das returnte Dictionary wirklich nur eine PLZ enthält und ein 5-Stelliger Code ist
        if len(psDict) == 1 and len(psDict.get('plz')) == 5:
            ps = psDict.get('plz')

            jobsForPage = con.getHTTPResponse(1, ps).json()
            # Gibt es Stellenangebote in der Page oder ist die leer?
            if jobsForPage.get("maxErgebnisse") >= 1:
                for entity in jobsForPage["stellenangebote"]:
                    dict = {
                        "beruf": entity.get("beruf", None),
                        "titel": entity.get("titel", None),
                        "refnr": entity.get("refnr", None),
                        "arbeitgeber": entity.get("arbeitgeber", None),
                        "eintrittsdatum": entity.get("eintrittsdatum", None),
                        "entfernung": entity.get("arbeitsort", "").get("entfernung", None),
                        "plz": entity.get("arbeitsort", "").get("plz", None)
                    }
                    data.append(dict)
                # Ja, das muss hier wirklich stehen, damit die API einen nicht rauswirft.
            time.sleep(1)
            print("Ping" + str(it))
            it += 1
            if len(data) >= 100:
                df_codes = pd.DataFrame.from_dict(getPostalData())
                df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
                df_nach_stellenangeboten.sort_values(by=["beruf"])
                df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten, df_codes, how='inner', on=["plz", "plz"])
                dfjson = df_nach_stellenangeboten.to_json(orient="records")
                with open('returnData.json', 'w') as file:
                    json.dump(dfjson, file)
                    return data

    return data


def getPostalData() -> []:
    home_path = '../../import/geo_dataset.json'
    data = []
    f = open(home_path)
    cityCodes = json.load(f)
    for gemeinde in cityCodes["gemeinden"]:
        dict = {
            # Rausgenommen weil nicht zuordbar
            # "id": gemeinde.get("id", None),
            "plz": gemeinde.get("postleitzahl", None)
        }
        if (dict not in data):
            data.append(dict)
    f.close()
    return data


codes = getPostalData()
data = getDictForDE(400, codes)

df_codes = pd.DataFrame.from_dict(codes)
df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
df_nach_stellenangeboten.sort_values(by=["beruf"])
df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten, df_codes, how='inner', on=["plz", "plz"])
print(df_nach_stellenangeboten)
