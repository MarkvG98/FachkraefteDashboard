
from main.py.connectors import RestApiConnector
import pandas as pd

con = RestApiConnector()
jobs = con.getHTTPResponse().json()

def set_pandas_display_options() -> None:
    # Ref: https://stackoverflow.com/a/52432757/
    display = pd.options.display

    display.max_columns = 1000
    display.max_rows = 1000
    display.max_colwidth = 199
    display.width = 1000

set_pandas_display_options()

print(jobs)

data = []

for entity in jobs["stellenangebote"]:
    dict ={
        "beruf": entity.get("beruf", ""),
        "titel": entity.get("titel", ""),
        "refnr": entity.get("refnr", ""),
        "arbeitgeber": entity.get("arbeitgeber", ""),
        "eintrittsdatum": entity.get("eintrittsdatum", "")
    }
    data.append(dict)

df_nach_stellenangeboten = pd.DataFrame.from_dict(data)
print(df_nach_stellenangeboten)
