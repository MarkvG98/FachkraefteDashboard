import csv


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
        self.ars_rb = ars_rb


class Region:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_rb
        self.ars_kreis = ars_kreis


class Kreis:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_rb
        self.ars_kreis = ars_kreis


class Gemeindeverband:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis, ars_vb):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_rb
        self.ars_kreis = ars_kreis
        self.ars_vb = ars_vb


class Gemeinde:
    def __init__(self, id, name, ars_land, ars_rb, ars_kreis, ars_vb, ars_gem, flaeche, postleitzahl,
                 bevoelkerung_insgesamt, bevoelkerung_maennlich, bevoelkerung_weiblich, bevoelkerung_pro_flaeche,
                 ort_laengengrad, ort_breitengrad, verstaedterung):
        self.id = id
        self.name = name
        self.ars_land = ars_land
        self.ars_rb = ars_rb
        self.ars_kreis = ars_kreis
        self.ars_vb = ars_vb
        self.ars_gem = ars_gem
        self.flaeche = flaeche
        self.postleitzahl = postleitzahl
        self.bevoelkerung_insgesamt = bevoelkerung_insgesamt
        self.bevoelkerung_maennlich = bevoelkerung_maennlich
        self.bevoelkerung_weiblich = bevoelkerung_weiblich
        self.bevoelkerung_pro_flaeche = bevoelkerung_pro_flaeche
        self.ort_laengengrad = ort_laengengrad
        self.ort_breitengrad = ort_breitengrad
        self.verstaedterung = verstaedterung


laender = []
regierungsbezirke = []
regionen = []
kreise = []
gemeindeverbaende = []
gemeinden = []

home_path = 'C:/Users/REDEMELV/OneDrive - Nagel-Group/Desktop/Uni Dashboard/'

with open(home_path + 'regional_data.csv', newline='', encoding='utf-8') as csvfile:
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

# Export Länder
with open(home_path + 'database/geo_land.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land"])

    for land in laender:
        writer.writerow([land.id, land.name, land.ars_land])

# Export Regierungsbezirke
with open(home_path + 'database/geo_regierungsbezirk.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land", "ars_rb"])

    for regierungsbezirk in regierungsbezirke:
        writer.writerow(
            [regierungsbezirk.id, regierungsbezirk.name, regierungsbezirk.ars_land, regierungsbezirk.ars_rb])

# Export Regionen
with open(home_path + 'database/geo_region.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land", "ars_rb", "ars_kreis"])

    for region in regionen:
        writer.writerow([region.id, region.name, region.ars_land, region.ars_rb, region.ars_kreis])

# Export Kreise
with open(home_path + 'database/geo_kreis.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land", "ars_rb", "ars_kreis"])

    for kreis in kreise:
        writer.writerow([kreis.id, kreis.name, kreis.ars_land, kreis.ars_rb, kreis.ars_kreis])

# Export Gemeindeverband
with open(home_path + 'database/geo_gemeindeverband.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land", "ars_rb", "ars_kreis", "ars_vb"])

    for gemeindeverband in gemeindeverbaende:
        writer.writerow([gemeindeverband.id, gemeindeverband.name, gemeindeverband.ars_land, gemeindeverband.ars_rb,
                         gemeindeverband.ars_kreis, gemeindeverband.ars_vb])

# Export Gemeinden
with open(home_path + 'database/geo_gemeinde.csv', 'w', newline='', encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["id", "name", "ars_land", "ars_rb", "ars_kreis", "ars_vb", "ars_gem", "flaeche", "postleitzahl",
                     "bevoelkerung_insgesamt", "bevoelkerung_maennlich", "bevoelkerung_weiblich",
                     "bevoelkerung_pro_flaeche", "ort_laengengrad", "ort_breitengrad", "verstaedterung"])

    for gemeinde in gemeinden:
        writer.writerow(
            [gemeinde.id, gemeinde.name, gemeinde.ars_land, gemeinde.ars_rb, gemeinde.ars_kreis, gemeinde.ars_vb,
             gemeinde.ars_gem, gemeinde.flaeche, gemeinde.postleitzahl,
             gemeinde.bevoelkerung_insgesamt.replace(" ", ''), gemeinde.bevoelkerung_maennlich.replace(" ", ''),
             gemeinde.bevoelkerung_weiblich.replace(" ", ''), gemeinde.bevoelkerung_pro_flaeche.replace(" ", ''),
             gemeinde.ort_laengengrad, gemeinde.ort_breitengrad, gemeinde.verstaedterung])
