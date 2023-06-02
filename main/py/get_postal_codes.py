import json

home_path = 'C:/Users/melvi/Desktop/FachkraefteDashboard/main/import/'

f = open(home_path+'geo_dataset.json')
  
data = json.load(f)
  
for gemeinde in data['gemeinden']:
    print(gemeinde['id'] + " " + gemeinde['postleitzahl'])
  
f.close()