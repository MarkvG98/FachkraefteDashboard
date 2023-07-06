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
    dfjson = pd.DataFrame()
    for psDict in getPostalData():
        ps = psDict.get("plz")
        # Fehlervorbeugung, Check ob ein 5-Stelliger Code PLZ-Code
        print("Ping")
        if len(ps) == 5 and ps.startswith("0"):
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

                        if len(data) >= 250:
                            df_codes = pd.DataFrame.from_dict(getPostalData())
                            df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
                            df_nach_stellenangeboten.sort_values(by=["beruf"])
                            df_nach_stellenangeboten = pd.merge(df_nach_stellenangeboten, df_codes, how='inner',
                                                                on=["plz", "plz"])
                            dfjson = df_nach_stellenangeboten.to_json(orient="records")
                            with open('returnData.json', 'a') as file:
                                json.dump(json.loads(dfjson), file)
                            data.clear()
        if ps.startswith('0'):
            print("Ortschaft " + ps + " abgearbeitet")
        # Zwischenspeichern falls der Gerät uns abraucht
    print("Ende")
    with open('returnData.json', 'a') as file:
        if(not dfjson.empty):
            jsDf = dfjson.to_json(orient= "records")
            json.dump(json.loads(jsDf), file)
        data.clear()


def getPostalData() -> []:
    home_path = '../../import/geo_dataset.json'
    data = []
    f = open(home_path)
    cityCodes = json.load(f)
    for gemeinde in cityCodes["gemeinden"]:
        dict = {
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
