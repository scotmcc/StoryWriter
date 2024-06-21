using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoryWriter.Services
{
    public class OllamaService
    {
        // Define the properties for the OllamaResponse class
        public class OllamaResponse
        {
            public string Model { get; set; } = string.Empty;
            public long Total_Duration { get; set; } = 0;
            public int Prompt_Eval_Count { get; set; } = 0;
            public long Prompt_Eval_Duration { get; set; } = 0;
            public int Eval_Count { get; set; } = 0;
            public long Load_Duration { get; set; } = 0;
            public long Eval_Duration { get; set; } = 0;
            public long[] Context { get; set; } = [];
            public string Response { get; set; } = string.Empty;
            public bool Done { get; set; } = false;
        }

        // Define the properties for the OllamaRequest class
        public class OllamaRequest
        {
            public string Model { get; set; } = string.Empty;
            public string Prompt { get; set; } = string.Empty;
            public string System { get; set; } = string.Empty;
            public bool Stream { get; set; } = false;
        }

        public async Task<OllamaResponse?> GetResponseAsync(OllamaRequest request)
        {
            using var client = new HttpClient();
            try
            {
                Console.WriteLine("Sending POST request to Ollama API...");
                Console.WriteLine($"Request: {JsonSerializer.Serialize(request)}");
                var response = await client.PostAsJsonAsync("http://localhost:11434/api/generate", request);

                response.EnsureSuccessStatusCode();

                Console.WriteLine("Received response from Ollama API...");
                Console.WriteLine($"Response status code: {response.StatusCode}");
                Console.WriteLine($"Response content: {await response.Content.ReadAsStringAsync()}");
                return await response.Content.ReadFromJsonAsync<OllamaResponse>();
            }
            catch (HttpRequestException e)
            {
                // Handle HTTP request errors
                Console.WriteLine($"Request error: {e.Message}");
                if (e.StatusCode.HasValue)
                {
                    Console.WriteLine($"Response status code: {e.StatusCode}");
                }
                return null;
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine($"The content type is not supported: {e.Message}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON parsing error: {e.Message}");
                return null;
            }
        }
    }
}
