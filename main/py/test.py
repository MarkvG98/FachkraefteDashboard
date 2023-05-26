import requests

url = 'https://rest.arbeitsagentur.de/oauth/gettoken_cc'

headers = {"Content-Type": "application/json; charset=utf-8"}

data = {
    "client_id": "c003a37f-024f-462a-b36d-b001be4cd24a",
    "client_secret": "32a39620-32b3-4307-9aa1-511e3d7f48a8",
    "grant_type": "client_credentials",
}
 

request = requests.post(url,headers=headers,json=data)

print(requests)