using Newtonsoft.Json;
using System.Net.Http.Headers;

var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, "https://csp-rubrik-004.redmond.corp.microsoft.com/api/v1/api/client_token");
var content = new MultipartFormDataContent();
content.Add(new StringContent("User:::8645b589-dea9-4407-98fc-33d69dba9c83"), "client_id");
content.Add(new StringContent("/FrWvEpl+3G2s5b6FhkambaOl1tTdSKj6EEgbODnlX4NgG8+pcdr86RSa1t//ZvmGGJbvA3V1HRZtqPjPotP"), "client_secret");
request.Content = content;
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
var token = await response.Content.ReadAsStringAsync();

Token tok = JsonConvert.DeserializeObject<Token>(token);

Console.WriteLine(tok.AccessToken);

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tok.AccessToken);
var result = await client.GetAsync("https://arrowprod.azurewebsites.net/API/GetAssets?organisationName=domoreexp&projectName=Teamspace&buildId=18933712&startDate=2023-1-17&endDate=2023-3-18");
var resultAsync = await result.Content.ReadAsStringAsync();
Console.WriteLine(resultAsync);


internal class Token
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}
