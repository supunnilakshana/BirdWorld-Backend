using Newtonsoft.Json.Linq;
using System.Text;

namespace BirdWorld.Helpers
{
    public class FirebaseDynamicLinksService
    {
        private readonly HttpClient _httpClient;

        public FirebaseDynamicLinksService()
        {
            _httpClient = new HttpClient  
            {
                BaseAddress = new Uri("https://firebasedynamiclinks.googleapis.com/v1/"),
            };
        }


        public async Task<string?> CreateDynamicLinkAsync(String token,String email)
        {
            try
            {
                string encodedTokenData = System.Web.HttpUtility.UrlEncode(token);
                string apiKey = "AIzaSyAz7a4beRSMdXj9xwFYuBZw3-9yIPoISE8";
                string domainUriPrefix = "https://birdworld.page.link";
                string targetLink = $"https://www.example.com/?token={encodedTokenData}&email={email}";
                  /*  $"&email={email}";*/
                string androidPackageName = "com.example.birdworld";
               

                var apiUrl = $"shortLinks?key={apiKey}";

                var dynamicLinkData = new
                {
                    dynamicLinkInfo = new
                    {
                        domainUriPrefix = domainUriPrefix,
                        link = targetLink,
                        androidInfo = new
                        {
                            androidPackageName = androidPackageName,
                        },
                        /*iosInfo = new
                        {
                            iosBundleId = iosBundleId,
                        },*/
                    },
                };

                // Serialize the data to JSON
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicLinkData);

                // Set the Content-Type header
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                // Send a POST request to create the dynamic link
                var response = await _httpClient.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                Console.WriteLine(response.StatusCode);

                Console.WriteLine(response.Content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    /*  // Parse the response to extract the short dynamic link
                      var dynamicLinkResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DynamicLinkResponse>(responseContent);
                      return dynamicLinkResponse.shortLink;*/
                    var jsonResponse = JObject.Parse(responseContent);
                    

                    string? shortLink = jsonResponse["shortLink"]?.ToString();
                    Console.WriteLine(shortLink);
                    return shortLink;
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }






    }
}
