# SimSage C# Server example

written using Dotnet Core 2.0

Small SimSage C# Server for HTTP/HTTPS access.  Change `Controllers\\QueryController.cs` before running.
```
    // these parameters are SimSage's keys, see:  https://simsage.nz/api.html
    private const string organisationId = "?";
    private const string kbId = "?";
    private const string securityId = "?";
```

## run/serve on port 5000 (default)
```
dotnet restore
dotnet run
```

## quick sanity check
post some text to the service using curl
```
curl -X POST --header "Content-Type: application/json" --data '{"query": "what are you?", "customerId": "12345"}' http://localhost:5000/query
```

