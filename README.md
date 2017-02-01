# ISYD-Demo
A project developed in C# (ASP.NET Web API 2) which explains how to grab a request coming from ISYD Say Box / Do Box and how to send the request back to server by making the status as 1. Then it show the code how to talk to ISayYouDo API through IdeaBiz and to invoke the Do Box to do the assigned action. It also implements method grab the Dialog smart button press and how to respond to click requests.

#### Sample JSON object which is passed to our application when a user creates a recipe

```json
{
	"connectToken": "",
	"notifyURL": "https://ideabiz.lk/.../invokeUserCondition",
	"sessionId": 3270,
	"userId": 131,
	"activeStatus": 200,
	"InputObject": {
		"button_serial": "DB224"
	}
}
```

####Sample JSON object which we should post to invoke the Do box

```json
{
	"connectToken": "",
	"notifyURL": "https://ideabiz.lk/.../invokeUserCondition",
	"sessionId": 3194,
	"userId": 131,
	"activeStatus": 1,
	"outputObject": {
		"button_serial": "sdfoh"
	}
}
```

####Sample JSON object which is sent to our application in the event of smart button click

```json
{
	"mac": "DB273",
	"messagetype": "EVENT",
	"in_device_id": "111151",
	"brand": "UOM",
	"type": "BUTTON_V2",
	"user_id": "55915",
	"event_name": "PRESSED"
}
```
