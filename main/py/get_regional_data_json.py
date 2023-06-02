import csv
import json

class Land:
    def __init__(self, id, name, ars_land):
        self.id = id
        self.name = name
        self.ars_land = ars_land


class Regierungsbezirk:
    def __init__(self, id, name, ars_land, ars_rb):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_land+ars_rb


class Region:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_land+ars_rb
        self.ars_kreis = ars_land+ars_rb+ars_kreis


class Kreis:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_land+ars_rb
        self.ars_kreis = ars_land+ars_rb+ars_kreis


class Gemeindeverband:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis, ars_vb):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_land+ars_rb
        self.ars_kreis = ars_land+ars_rb+ars_kreis
        self.ars_vb = ars_land+ars_rb+ars_kreis+ars_vb


class Gemeinde:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis, ars_vb, ars_gem, flaeche, postleitzahl,
                 bevoelkerung_insgesamt, bevoelkerung_maennlich, bevoelkerung_weiblich, bevoelkerung_pro_flaeche,
                 ort_laengengrad, ort_breitengrad, verstaedterung):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_land+ars_rb
        self.ars_kreis = ars_land+ars_rb+ars_kreis
        self.ars_vb = ars_land+ars_rb+ars_kreis+ars_vb
        self.ars_gem = ars_land+ars_rb+ars_kreis+ars_vb+ars_gem
        self.flaeche = flaeche
        self.postleitzahl = postleitzahl
        self.bevoelkerung_insgesamt = bevoelkerung_insgesamt.replace(" ","")
        self.bevoelkerung_maennlich = bevoelkerung_maennlich.replace(" ","")
        self.bevoelkerung_weiblich = bevoelkerung_weiblich.replace(" ","")
        self.bevoelkerung_pro_flaeche = bevoelkerung_pro_flaeche.replace(" ","")
        self.ort_laengengrad = ort_laengengrad
        self.ort_breitengrad = ort_breitengrad
        self.verstaedterung = verstaedterung


laender = []
regierungsbezirke = []
regionen = []
kreise = []
gemeindeverbaende = []
gemeinden = []

home_path = 'C:/Users/melvi/Desktop/FachkraefteDashboard/main/import/'

with open(home_path + 'AuszugGV1QAktuell.csv', newline='', encoding='utf-8') as csvfile:
    csv_reader = csv.reader(csvfile, delimiter=';')
    for row in csv_reader:

        id = row[2] + row[3] + row[4] + row[5] + row[6]
        name = row[7]

        if row[0] == '10':
            laender.append(Land(id, name, row[2]))
        elif row[0] == '20':
            regierungsbezirke.append(Regierungsbezirk(id, name, row[2], row[3]))
        elif row[0] == '30':
            regionen.append(Region(id, name, row[2], row[3], row[4]))
        elif row[0] == '40':
            kreise.append(Kreis(id, name, row[2], row[3], row[4]))
        elif row[0] == '50':
            gemeindeverbaende.append(Gemeindeverband(id, name, row[2], row[3], row[4], row[5]))
        elif row[0] == '60':
            gemeinden.append(
                Gemeinde(id, name, row[2], row[3], row[4], row[5], row[6], row[8], row[13], row[9], row[10], row[11],
                         row[12], row[14], row[15], row[18]))

json_data = {}
json_laender = []
json_regierungsbezirke = []
json_regionen = []
json_kreise = []
json_gemeindeverbaende = []
json_gemeinden = []

for land in laender:
    json_laender.append({"id":land.id,"name":land.name,"ars_land":land.ars_land})

for regierungsbezirk in regierungsbezirke:
    json_regierungsbezirke.append({"id":regierungsbezirk.id,"name":regierungsbezirk.name,"ars_land":regierungsbezirk.ars_land,"ars_rb":regierungsbezirk.ars_rb})

for region in regionen:
    json_regionen.append({"id":region.id,"name":region.name,"ars_land":region.ars_land,"ars_rb":region.ars_rb,"ars_kreis":region.ars_kreis})

for kreis in kreise:
    json_kreise.append({"id":kreis.id,"name":kreis.name,"ars_land":kreis.ars_land,"ars_rb":kreis.ars_rb,"ars_kreis":kreis.ars_kreis})

for gemeindeverband in gemeindeverbaende:
    json_gemeindeverbaende.append({"id":gemeindeverband.id,"name":gemeindeverband.name,"ars_land":gemeindeverband.ars_land,"ars_rb":gemeindeverband.ars_rb,"ars_kreis":gemeindeverband.ars_kreis,"ars_vb":gemeindeverband.ars_vb})

for gemeinde in gemeinden:
    json_gemeinden.append({"id":gemeinde.id,"name":gemeinde.name,"ars_land":gemeinde.ars_land,"ars_rb":gemeinde.ars_rb,"ars_kreis":gemeinde.ars_kreis,"ars_vb":gemeinde.ars_vb,"ars_gem":gemeinde.ars_gem,"flaeche" : gemeinde.flaeche, "postleitzahl" : gemeinde.postleitzahl, "bevoelkerung_insgesamt" : gemeinde.bevoelkerung_insgesamt, "bevoelkerung_maennlich" : gemeinde.bevoelkerung_maennlich, "bevoelkerung_weiblich" : gemeinde.bevoelkerung_weiblich, "bevoelkerung_pro_flaeche" : gemeinde.bevoelkerung_pro_flaeche, "ort_laengengrad" : gemeinde.ort_laengengrad, "ort_breitengrad" : gemeinde.ort_breitengrad, "verstaedterung" : gemeinde.verstaedterung})

json_data = {"laender":json_laender,"regierungsbezirke":json_regierungsbezirke,"regionen":json_regionen,"kreise":json_kreise,"gemeindeverbaende":json_gemeindeverbaende,"gemeinden":json_gemeinden}

with open(home_path+"geo_dataset.json", "w") as outfile:
    json.dump(json_data, outfile)