using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ProductTester
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61482/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/products/1");

                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync<Product> ();
                    Console.WriteLine("{0}\t{1}\t${2}\t{3}", product.Id, product.Name, product.Price, product.Category);
                }

                Console.ReadLine();
            }
        }

    }
}
