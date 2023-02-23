using Newtonsoft.Json;
using System.Text;

namespace InventoryManagement.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tags = File.ReadAllLines("..\\..\\..\\tags.txt");

            int tagsCounter = 0;
            int batchesCount = 6;
            int maxBatchSize = tags.Length / batchesCount;
            int currentBatchCount = new Random().Next(maxBatchSize);

            for (var i = 0; i < batchesCount; i++)
            {
                var body = new
                {
                    ExternalId = i + " Batch",
                    Location = "blablavla",
                    Tags = new List<string>()
                };

                for (var j = 0; j < currentBatchCount; j++)
                {
                    body.Tags.Add(tags[tagsCounter + j]);
                }

                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7224/inventories");
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                client.Send(request);

                tagsCounter += currentBatchCount;

                currentBatchCount = new Random().Next(maxBatchSize);
                if (i == batchesCount - 2)
                {
                    currentBatchCount = tags.Length - tagsCounter;
                }
            }
        }
    }
}