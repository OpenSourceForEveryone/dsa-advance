// See https://aka.ms/new-console-template for more information
using System.Net;

MyTask.AddGroup(assetgroupname: "OE_Sample_Vipul3",
               groupType: "AzdevDrop",
               ownerAlias: "v-ajaisawal",
               contactAlias: "ORetentionIDC@microsoft.com",
               numberOfDaysToRetainInPrimaryStorage: 10,
               numberOfDaysToRetainInSecondaryStorage: 60,
               organisationName: "office");

Console.WriteLine("Completed");


public class MyTask
{
    static string baseUrl = "https://oretentionpr";
    public static void AddGroup(
          string assetgroupname,
          string groupType,
          string ownerAlias,
          string contactAlias,
          int numberOfDaysToRetainInPrimaryStorage,
          int numberOfDaysToRetainInSecondaryStorage = 0,
          string organisationName = null)
    {


        string url =
                $"{baseUrl}/API/AssetGroup/Add/{assetgroupname}/?groupType={groupType}&ownerAlias={ownerAlias}&contactAlias={contactAlias}" +
                $"&numberOfDaysToRetainAtArchive={numberOfDaysToRetainInSecondaryStorage}&numberOfDaysToRetainAtAzure=0" +
                $"&numberOfDaysToRetainAtFast={numberOfDaysToRetainInPrimaryStorage}&numberOfDaysToRetainAtMiddleTier=0" +
                $"&numberOfDaysToRetainAtTape=0&organisationName={(string.IsNullOrEmpty(organisationName) ? string.Empty : organisationName)}";

        MakeHttpGetRequestWithCSRF(url);
    }

    private static HttpResponseMessage MakeHttpGetRequestWithCSRF(string url)
    {
        return MakeHttpRequestWithCSRF(url, HttpMethod.Get);
    }

    private static HttpResponseMessage MakeHttpRequestWithCSRF(string url, HttpMethod httpMethod)
    {
        Cookie antiCsrfCookie = null;
        string antiCsrfToken = string.Empty;
        GetAntiCSRFToken(out antiCsrfCookie, out antiCsrfToken);

        CookieContainer cookieContainer = new CookieContainer();
        cookieContainer.Add(antiCsrfCookie);
        HttpClientHandler handler = new HttpClientHandler
        {
            Credentials = CredentialCache.DefaultCredentials,
            CookieContainer = cookieContainer
        };
        HttpClient httpClient = new HttpClient(handler);
        httpClient.Timeout = TimeSpan.FromSeconds(500);

        var httpRequestMessage = new HttpRequestMessage(httpMethod, url);
        httpRequestMessage.Headers.Add("X-RVT", antiCsrfToken);
        var response = httpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();
        return response;
    }

    private static void GetAntiCSRFToken(out Cookie antiCsrfCookie, out string antiCsrfToken)
    {
        antiCsrfCookie = null;
        antiCsrfToken = string.Empty;
        string url = $"{baseUrl}/API/AntiCSRF/GetToken";

        CookieContainer cookieContainer = new CookieContainer();
        HttpClientHandler handler = new HttpClientHandler
        {
            Credentials = CredentialCache.DefaultCredentials,
            CookieContainer = cookieContainer
        };

        HttpClient httpClient = new HttpClient(handler);

        var response = httpClient.GetAsync(url.ToString()).GetAwaiter().GetResult();
        response.EnsureSuccessStatusCode();
        antiCsrfToken = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        if (handler.CookieContainer.Count != 0)
        {
            Uri uri = new Uri(url);
            var cookie = handler.CookieContainer.GetCookies(uri)["__RequestVerificationToken"];
            if (cookie != null)
            {
                antiCsrfCookie = cookie;
            }
        }

        if (antiCsrfCookie == null)
        {
            throw new Exception("Cookie __RequestVerificationToken not found in the response.");
        }
    }
}