using Parser.Core;
using Parser.Core.Models;
using System;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Parser.Console
{
	class Program
	{
		private static string _apiBaseUrl = "http://localhost:8888/records/";
		private static string _fileName;
		private static SortOutputFormat _format;

		static void Main(string[] args)
		{

			// The Length property is used to obtain the length of the array. 
			// Notice that Length is a read-only property:
			Output("Number of command line parameters = {0}", args.Length);

			try
			{
				_format = (SortOutputFormat)Convert.ToInt32(args[1]);
				_fileName = args[0].ToString().Trim();
				Output("Input - Filename: {0} Sort Format: {1}", _fileName, _format.ToString());
				
			}
			catch(Exception)
			{
				Output("ERROR: Please provide valid arguments ex: c:\temp\testdata.txt 1");
				PauseExit();
			}

			// Create the Worker classes - These contain all the implementation code.
			FileParser parser = new FileParser();
			Sorter sorter = new Sorter();
			
			// Parse People from file
			IList<Person> people = parser.ParseFile(_fileName);

			// Sort People
			IList<Person> sorted = sorter.Sort(people, _format);

			// Display People
			Output(people);
						
			// Call REST Api
			CallRestApi();

			// Wait for Press any Key
			PauseExit();
			

		}


		#region Private Helpers
		static void Output(string format, params object[] args)
		{
			System.Console.WriteLine(format, args);
		}
		static void Output(string output)
		{
			System.Console.WriteLine(output);
		}
		static void Output(IList<Person> people)
		{
			foreach(Person p in people)
			{
				Output(p.ToString());
			}
		}
		static void PauseExit()
		{
			Output("Press any key to continue...");
			System.Console.ReadKey();
		}		

		static void CallRestApi()
		{

			Output(Environment.NewLine);
			Output(Environment.NewLine);
			Output("==============================================================================");
			Output("==== Call Web Api (should be 3 sorted sets ===================================");
			Output("==============================================================================");
			Output(Environment.NewLine);

			
			// Create HttpCient and make a request to api/values 
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_apiBaseUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


			var response = client.GetAsync("").Result;

			response = client.GetAsync("gender").Result;
			Output("Gender Sorted: {0}{1}", Environment.NewLine, response.Content.ReadAsStringAsync().Result);
			Output(Environment.NewLine);

			response = client.GetAsync("birthdate").Result;
			Output("Birthdate Sorted: {0}{1}", Environment.NewLine, response.Content.ReadAsStringAsync().Result);
			Output(Environment.NewLine);

			response = client.GetAsync("name").Result;
			Output("Name Sorted: {0}{1}", Environment.NewLine, response.Content.ReadAsStringAsync().Result);
			Output(Environment.NewLine);



			//response = client.GetAsync("birthdate").Result;
			//response = client.GetAsync("name").Result;



			//else
			//{
			//	Output("ERROR: Impossible to connect to service");
			//}


		}

		#endregion
	}
}
