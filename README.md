# CryptoLadderConsole
A dotnet core console application that uses the ByBit API to ladder orders.
[![Build Status](https://internetwideworld.visualstudio.com/CryptoLadder/_apis/build/status/GeorgeLeithead.CryptoLadderConsole?branchName=master)](https://internetwideworld.visualstudio.com/CryptoLadder/_build/latest?definitionId=4&branchName=master)
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
## Logging
By default the application logs information levels.  The application also provides the ability to log to a file and the console.  To adjust the logging level, edit the application `appsettings.json` file, setting the "rules" minLevel as appropriate.

For example, the following rule will set the file logging level to "Debug":
```
        "rules": [
            {
                "logger": "*",
                "minLevel": "Debug",
                "writeTo": "logToFile"
            },
```

### Log levels
The log levels, in descending order, are as follows:

|Level|Typical Use|
------|-------
|Fatal|Something bad happened; application may crash|
|Error|Something failed; application may or may not continue|
|Warn|Something unexpected; application will continue|
|Info|Normal behavior like API key retrieved, order made, etc.|
|Debug|For debugging; activities such as executed order, etc.|
|Trace|For trace debugging; begin method X, end method X|

There is one more level, Off. Since it is the highest value and is not used for entries, it disables logging when used as the minimum log level.