using System;
using System.Text.Json;
public class Solution
{
    public class ApiResponse
    { 
        public int page { get; set; }
        public int total_pages { get; set; }
        public List<ActualData> data { get; set; }

        public int total { get; set; }
        public int per_page { get; set; }
    }

    public class ActualData
    {
        public string name { get; set; }
        public string genre { get; set; }
        public decimal imdb_rating {get;set;}
    }
    public static async Task<string> BestInGenre(string genre)
    {
        try
        {
            string baseUrl = "https://jsonmock.hackerrank.com/api/tvseries";
            int currentPage = 1;
            int totalPages = 1;
            List<ActualData> GenereData = new List<ActualData>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                while (currentPage <= totalPages)
                {
                    var a = await client.GetAsync($"?page={currentPage}");
                    if (!a.IsSuccessStatusCode)
                        throw new Exception("Exception while getting Data from API");

                    var response = await a.Content.ReadAsStringAsync();
                    var respnseData = JsonSerializer.Deserialize<ApiResponse>(response);
                    totalPages = respnseData.total_pages;
                    GenereData.AddRange(respnseData.data);
                    currentPage++;
                }
            }

            string name = GenereData.Where(i => i.genre.ToUpper().Contains(genre.ToUpper()))
                .OrderByDescending(i => i.imdb_rating)
                        .Select(i => i.name).First();

            return name;

        }
        catch
        {
            throw;
        }
    }  
}

public class MainClass
{
    public static async Task Main()
    {
        Console.WriteLine("Enter genre:");
        string genre = Console.ReadLine();
        string result = await Solution.BestInGenre(genre);
        Console.WriteLine($"Best show in genre '{genre}': {result}");
    }
}