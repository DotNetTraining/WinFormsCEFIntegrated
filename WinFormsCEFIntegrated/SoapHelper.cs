using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class SoapHelper
{
    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task<string> CallSoapService(string soapAction, string methodName, string bodyContent)
    {
        //string url = "https://localhost:44309/WebService1.asmx";
        string url = "http://localhost/WebService/WebService1.asmx";

        string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""> 
  <soap:Body> 
    <{methodName} xmlns=""http://tempuri.org/""> 
      {bodyContent} 
    </{methodName}> 
  </soap:Body>
</soap:Envelope>";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("SOAPAction", $"http://tempuri.org/{methodName}");
        request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public static string ExtractSoapResult(string soapResponse, string resultTag)
    {
        var xml = XDocument.Parse(soapResponse);
        XNamespace ns = "http://schemas.xmlsoap.org/soap/envelope/";
        var body = xml.Root.Element(ns + "Body");
        var resultElement = body.Descendants().FirstOrDefault(e => e.Name.LocalName == resultTag);
        return resultElement?.Value;
    }
}
