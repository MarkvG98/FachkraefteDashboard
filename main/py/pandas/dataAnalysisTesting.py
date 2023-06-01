from main.py.connectors import RestApiConnector
import pandas as pd

con = RestApiConnector()
jobs = con.getHTTPResponse().json()
dict_list = [jobs['stellenangebote']]
df = pd.DataFrame(dict_list)
print(df.to_string())

for index, row in df.iterrows():
    for column in df.columns:
        val = row[column]
        print(val)