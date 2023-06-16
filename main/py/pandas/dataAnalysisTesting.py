from main.py.connectors import RestApiConnector
import pandas as pd
import json

con = RestApiConnector()


# jobs = con.getHTTPResponse().json()

def set_pandas_display_options() -> None:
    # Ref: https://stackoverflow.com/a/52432757/
    display = pd.options.display
    display.max_columns = 1000
    display.max_rows = 5000
    display.max_colwidth = 199
    display.width = 1000


set_pandas_display_options()


def getDictForDE(pagesToShow: int) -> []:
    data = []
    for index in range(pagesToShow):
        jobsForPage = con.getHTTPResponse(index + 1).json()
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
    return data


def getPostalData() -> []:
    home_path = '../../import/geo_dataset.json'
    data = []
    f = open(home_path)
    cityCodes = json.load(f)
    for gemeinde in cityCodes["gemeinden"]:
        dict = {
            #Rausgenommen weil nicht zuordbar
            #"id": gemeinde.get("id", None),
            "plz": gemeinde.get("postleitzahl", None)
        }
        if(dict not in data):
            data.append(dict)
    f.close()
    return data


data = getDictForDE(15)
cityData = getPostalData()

df_codes = pd.DataFrame.from_dict(cityData)
df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
df_nach_stellenangeboten.sort_values(by=["beruf"])
df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten,df_codes,how='inner',on=["plz","plz"])
print(df_nach_stellenangeboten)


