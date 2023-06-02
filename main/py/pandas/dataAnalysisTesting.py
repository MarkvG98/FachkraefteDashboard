
from main.py.connectors import RestApiConnector
import pandas as pd

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

def getDictForPages(pagesToShow: int) -> []:
    data = []
    for index in range(pagesToShow):
       jobsForPage = con.getHTTPResponse(index+1).json()
       for entity in jobsForPage["stellenangebote"]:
           dict = {
               "beruf": entity.get("beruf", ""),
               "titel": entity.get("titel", ""),
               "refnr": entity.get("refnr", ""),
               "arbeitgeber": entity.get("arbeitgeber", ""),
               "eintrittsdatum": entity.get("eintrittsdatum", ""),
               "entfernung": entity.get("entfernung", ""),
               "plz": entity.get("arbeitsort","plz")
           }
           data.append(dict)

    return data

# print()

data = getDictForPages(15)




df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
df_nach_stellenangeboten.sort_values(by=["beruf"])
print(df_nach_stellenangeboten)
