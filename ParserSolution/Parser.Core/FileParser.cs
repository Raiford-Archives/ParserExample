﻿using Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    public class FileParser
    {
		public IList<Person> ParseFile(string fullFileName)
		{
			IList<Person> people = new List<Person>();

			try
			{
				///////////////////////////////////////////////////////////////////////////
				// NOTE: This is only good for small files use 
				//       another algorithm for reading chunks into memory for large files
				///////////////////////////////////////////////////////////////////////////

				// Parse line into Person
				foreach (string line in File.ReadLines(fullFileName))
				{
					Person person = ParseLine(line);
					people.Add(person);
				}
			}
			catch (Exception exception)
			{
				// Just throw to UI with new descriptive message
				throw new Exception(string.Format("Error Parsing File {0}", fullFileName), exception);
			}		

			return people;
		}


		private Person ParseLine(string line)
		{
			Person person = new Person();

			string[] lines = line.Split(',');

			// Assume data is aligned
			person.LastName = lines[0];
			person.FirstName = lines[1];
			person.Gender = lines[2];
			person.FavoriteColor = lines[3];
			person.DateOfBirth = DateTime.Parse(lines[4]);

			return person;
		}


	}
}
