import requests

api_url = "https://rest.arbeitsagentur.de/oauth/gettoken_cc"
#headers =  {"Content-Type":"application/json","Encoding":"UTF-8"}
response = requests.get(api_url)
#response.json()