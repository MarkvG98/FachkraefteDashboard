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


def getDictForDE(pagesToShow: int, onlyCompleteDatasets: bool):
    data = []
    for psDict in getPostalData():
        # Fehlervorbeugung, Check ob das returnte Dictionary wirklich nur eine PLZ enthält und ein 5-Stelliger Code ist
        if len(psDict) == 1 and len(psDict.get('plz')) == 5:
            ps = psDict.get('plz')
            for i in range(pagesToShow):
                jobsForPage = con.getHTTPResponse(i + 1, ps).json()
                time.sleep(1)
                # Gibt es Stellenangebote in der Page oder ist die leer? Falls ja, breaken damit wir die Ortschaft abschließen
                if "stellenangebote" not in jobsForPage:
                    print("Keine Jobangebote für Ortschaft " + ps + " gefunden, überspringe Ort")
                    break
                else:
                    print("Jobs bei Ortschaft " + ps + " auf Seite " + str(i + 1) + " gefunden")
                    for entity in jobsForPage["stellenangebote"]:
                        dict = {
                            "beruf": entity.get("beruf", None),
                            "titel": entity.get("titel", None),
                            "refnr": entity.get("refnr", None),
                            "arbeitgeber": entity.get("arbeitgeber", None),
                            "eintrittsdatum": entity.get("eintrittsdatum", None),
                            "entfernung": entity.get("arbeitsort", "").get("entfernung", None),
                            "plz": entity.get("arbeitsort", "").get("plz", None),
                            "lat": entity.get("arbeitsort", "").get("koordinaten", "").get("lat", None),
                            "lon": entity.get("arbeitsort", "").get("koordinaten", "").get("lon", None)
                        }

                        if onlyCompleteDatasets:
                            if None not in dict:
                                data.append(dict)
                        # Ja, das muss hier wirklich stehen, damit die API einen nicht rauswirft.
                        print("Insgesamt " + str(len(data)) + " Jobs")

                        if len(data) >= 2500:
                            df_codes = pd.DataFrame.from_dict(getPostalData())
                            df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
                            df_nach_stellenangeboten.sort_values(by=["beruf"])
                            df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten, df_codes, how='inner',
                                                                on=["plz", "plz"])
                            dfjson = df_nach_stellenangeboten.to_json(orient="records")
                            with open('returnData.json', 'a') as file:
                                json.dump(json.loads(dfjson), file)
                            data.clear()

        print("Ortschaft " + ps + " abgearbeitet")
        # Zwischenspeichern falls der Gerät uns abraucht



def getPostalData() -> []:
    home_path = '../../import/geo_dataset.json'
    data = []
    f = open(home_path)
    cityCodes = json.load(f)
    for gemeinde in cityCodes["gemeinden"]:
        dict = {
            # Rausgenommen, weil nicht zuordbar
            # "id": gemeinde.get("id", None),
            "plz": gemeinde.get("postleitzahl", None)
        }
        if (dict not in data):
            data.append(dict)
    f.close()
    return data

# codes = getPostalData()
# df_codes = pd.DataFrame.from_dict(codes)
# df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
# df_nach_stellenangeboten.sort_values(by=["beruf"])
# df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten, df_codes, how='inner', on=["plz", "plz"])
# print(df_nach_stellenangeboten)
