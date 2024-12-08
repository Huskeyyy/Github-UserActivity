using System.Text.Json;

namespace Github_UserActivity
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please enter your github username.");
            string? username = Console.ReadLine();

            if (string.IsNullOrEmpty(username)) 
            {
                Console.WriteLine("No username entered, please try again.");
                return;
            }

            await FetchEvents(username);
        }

        static async Task FetchEvents(string username)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string? token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");

                    if (string.IsNullOrEmpty(token))
                    {
                        Console.WriteLine("GitHub api token is missing.");
                    }

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Github-UserActivityCLI");

                    var response = await httpClient.GetAsync($"https://api.github.com/users/{username}/events");

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error fetching data for {username}: {response.StatusCode}");
                        return;
                    }

                    // awaits and prses the content
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // deserializes to dynamic array
                    var events = JsonSerializer.Deserialize<JsonElement[]>(jsonResponse);

                    if (events == null || events.Length == 0)
                    {
                        Console.WriteLine($"No recent events found for user {username}.");
                        return;
                    }

                    // display events
                    Console.WriteLine($"Recent GitHub Events for {username}:");
                    foreach (var gitEvent in events)
                    {
                        string eventType = gitEvent.GetProperty("type").GetString();
                        string repoName = gitEvent.GetProperty("repo").GetProperty("name").GetString();
                        DateTime createdAt = gitEvent.GetProperty("created_at").GetDateTime();

                        Console.WriteLine($"- {eventType} in {repoName} on {createdAt:g}");
                    }
                }
            }
            catch (Exception ex) // TODO: more specific error handling maybe idk
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }
    }
}
