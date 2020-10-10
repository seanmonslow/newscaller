using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace dotnetprojects
{
    public class NewsApiResponse
    {
        public string status {get;set;}
        public int totalResults{get;set;}
        public List<Article> articles{get; set;}
    }
    public class Article
    {
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var result = await client.GetAsync("https://newsapi.org/v2/top-headlines?country=gb&apiKey=a0475e2114d949738c313f5f08d5ad62");

            string v = await result.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<NewsApiResponse>(v);

            Console.WriteLine(model.articles);

            foreach (Article article in model.articles)
            {
                Console.WriteLine("Author: " + article.author);
                Console.WriteLine("Title: " + article.title);
            }

        }
    }
}
