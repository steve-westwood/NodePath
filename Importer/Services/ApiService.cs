using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Services
{
	public class ApiService : IExporter
	{
		public void Export(Core.Vertex[] itemsToExport)
		{
			CallSaveApi(itemsToExport).Wait();
		}

		private static async Task CallSaveApi(Core.Vertex[] data)
		{
			var apiBaseUri = ConfigurationManager.AppSettings["ApiUrl"];
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiBaseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				// HTTP POST
				HttpResponseMessage response = await client.PostAsJsonAsync("installer/save", data);
				if (response.IsSuccessStatusCode)
				{
					// Get the URI of the created resource.
					Console.WriteLine("nodes imported!");
				}
				else
				{
					// Get the URI of the created resource.
					Console.WriteLine("There was an error importing the nodes!");
				}
			}
		}
	}
}
