import pandas as pd
import matplotlib.pyplot as plt

path_to_json = "C:\\Users\\melvi\\OneDrive - Privatperson\\MarksXXXtapes\\TestJason.json"
path_to_export = "C:\\Users\\melvi\\OneDrive - Privatperson\\MarksXXXtapes\\TestJason.geojson"

dataframe = pd.DataFrame()
dataframe = pd.read_json(path_to_json)

index = 0
size = dataframe.size

file = open(path_to_export,"w",encoding='utf-8')
file.write("{")
file = open(path_to_export,"a",encoding='utf-8')
file.write('"type": "FeatureCollection","features": [')

for entity in dataframe.index:
    index = index + 1
    print(str(index/size) + "%")
    if(dataframe['beruf'][entity] is not None and dataframe['lon'][entity] is not None and dataframe['lon'][entity] is not None and dataframe['arbeitgeber'][entity] is not None):
        #print('{ "type": "Feature", "geometry": { "type": "Point", "coordinates": [' + str(dataframe['lon'][entity]) + ',' + str(dataframe['lat'][entity]) + '] }, "properties": { "name": "' + dataframe['beruf'][entity] + '", "arbeitgeber": "' + dataframe['arbeitgeber'][entity] + '" } }')
        file.write('{ "type": "Feature", "geometry": { "type": "Point", "coordinates": [' + str(dataframe['lon'][entity]) + ',' + str(dataframe['lat'][entity]) + '] }, "properties": { "name": "' + dataframe['beruf'][entity] + '", "arbeitgeber": "' + (dataframe['arbeitgeber'][entity].replace('"','\'').replace(chr(92),chr(92)+chr(92))) + '" } },')

file.write('  ]')
file.write('}')