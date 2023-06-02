import requests
import pandas as pd
from requests import Response

class RestApiConnector:
    def getHTTPResponse(self) -> Response:
        client_id = "c003a37f-024f-462a-b36d-b001be4cd24a"
        client_secret = "32a39620-32b3-4307-9aa1-511e3d7f48a8"
        url = "https://rest.arbeitsagentur.de/oauth/gettoken_cc"

        data = {
            "client_id": client_id,
            "client_secret": client_secret,
            "grant_type": "client_credentials"
        }

        response = requests.post(url, data=data)
        response_json = response.json()

        token = response_json.get("access_token")

        url = "https://rest.arbeitsagentur.de/jobboerse/jobsuche-service/pc/v4/jobs"
        headers = {
            "OAuthAccessToken": token
        }

        params = {
            "angebotsart": "1",
            "wo": "Berlin",
            "umkreis": "200",
            "arbeitszeit": "ho;mj",
            "page": "1",
            "size": "100",
            "pav": "false"
        }
        response = requests.get(url, headers=headers, params=params)
        return response
