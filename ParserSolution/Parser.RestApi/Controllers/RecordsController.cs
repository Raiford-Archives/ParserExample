using Parser.Core;
using Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace Parser.RestApi.Controllers
{
	[RoutePrefix("records")]
	public class RecordsController : ApiController
    {
		Sorter _sorter = new Sorter();


		[HttpPost, HttpGet]
		public void Add(Person person)
		{
			// Add a line to the file
		}

		[HttpGet]
		[Route("gender")]
		public IList<Person> Gender()
		{			
			return  _sorter.Sort(GetPeople(), SortOutputFormat.Output1);			
		}

		[HttpGet]
		[Route("birthdate")]
		public IList<Person> BirthDate()
		{
			return _sorter.Sort(GetPeople(), SortOutputFormat.Output2);

		}

		[HttpGet]
		[Route("name")]
		public IList<Person> Name()
		{
			return _sorter.Sort(GetPeople(), SortOutputFormat.Output3);


		}


		private IList<Person> GetPeople()
		{
			string fullFileName = HostingEnvironment.MapPath("~/people.txt");
			FileParser parser = new FileParser();
			IList<Person> people = parser.ParseFile(fullFileName);
			return people;
		}


	}
}
