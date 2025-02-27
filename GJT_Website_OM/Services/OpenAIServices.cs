using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

public class OpenAIHttpService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenAIHttpService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["ConnectionStrings:OpenAI:ApiKey"];
    }

    public async Task<string> GetOpenAIResponseAsync(string prompt)
    {
        // Construct the request body with messages (chat completion format)
        var requestBody = new
        {
            model = "gpt-3.5-turbo", // Use the appropriate model name
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." }, // optional, can set the assistant's behavior
                new { role = "user", content = prompt } // user's input prompt
            },
            max_tokens = 100 // Set the max tokens as needed
        };

        var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

        // Set the Authorization header with the API key
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        try
        {
            // Send the request to OpenAI's chat completion endpoint
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

            // Throw an exception if the response status is not successful (400 or 500)
            response.EnsureSuccessStatusCode();

            // Read the response content
            var result = await response.Content.ReadAsStringAsync();

            // Deserialize the response into an OpenAIResponse object
            var completion = JsonConvert.DeserializeObject<OpenAIResponse>(result);

            // Return the assistant's response
            return completion?.Choices?.FirstOrDefault()?.Message?.Content;
        }
        catch (Exception ex)
        {
            // Log or handle any errors that occur during the request
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}

// OpenAI response structure
public class OpenAIResponse
{
    public List<Choice> Choices { get; set; }
}

// Each choice corresponds to a possible response
public class Choice
{
    public Message? Message { get; set; }
}

// The message returned by the model
public class Message
{
    public string? Content { get; set; }
}
