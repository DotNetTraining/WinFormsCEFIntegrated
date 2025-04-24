using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WinFormsCEFIntegrated;

public class JsBridge
{
    // Get the username from SessionData
    public string GetUsername()
    {
        return SessionData.Instance.Username;
    }

    // Get session variables as a JSON string
    public string GetSessionVariables()
    {
        var sessionVariables = SessionData.Instance.SessionVariables;
        return JsonConvert.SerializeObject(sessionVariables); // Return session data as JSON
    }
}
