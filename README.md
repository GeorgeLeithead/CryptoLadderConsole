# CryptoLadderConsole
A dotnet core console application that uses the ByBit API to ladder orders.
## Getting Your API Key and Secret Key

> For Testnet
https://testnet.bybit.com/user/api-management

> For Mainnet
https://www.bybit.com/app/user/api-management

## Applying your API Key and Secret Key
Edit the appsettings.json file and enter your details as appropriate:
```
{
    "TestNet": true,
    "ApiAuthorization": {
        "ApiKey": "kxLuuAAVVcmdcbihm1",
        "Sign": "Ko9bPRk9y4AVm1rVjpRoEAQeghsecirqL1rc"
    }
}
```
### ByBit Official API documentation
Libraries for connecting to the Bybit API. https://github.com/bybit-exchange/bybit-official-api-docs

## Changes to ByBit official C# examples
* Replaced NewtonSoft.Json for System.Text.Json
* Removed all un-necessary API and models
* Coverted over Client to apply authentication and signature at API run-time. See: https://github.com/bybit-exchange/bybit-official-api-docs/blob/master/en/rest_api_sign.md#authentication
* Added signature algorythm
* Changed API requests to return base model, which includes full response message. See: https://github.com/bybit-exchange/bybit-official-api-docs/blob/master/en/rest_api_sign.md#response-messages

## Features added
* Ability to ladder orders based on a starting price, end price and the number of rungs.
* Ability to generate a linear order for each rung of the ladder.
* Ability to specify the total quantity to use in ladder.
* Ability to ladder any available currency.