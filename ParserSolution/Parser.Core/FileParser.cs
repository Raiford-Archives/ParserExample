using Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
	/// <summary>
	/// Handles all the reading and parsing of the file and returns a People collection
	/// </summary>
	public class FileParser
    {
		/// <summary>
		/// Parses the file and returns a list of people from the file
		/// </summary>
		/// <param name="fullFileName"></param>
		/// <returns></returns>
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
					if (!string.IsNullOrWhiteSpace(line))
					{
						Person person = ParseLine(line);
						people.Add(person);
					}
				}
			}
			catch (Exception exception)
			{
				// Just throw to UI with new descriptive message
				throw new Exception(string.Format("Error Parsing File {0}", fullFileName), exception);
			}		

			return people;
		}


		/// <summary>
		/// Parses a single line into a Person object
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private Person ParseLine(string line)
		{
			Person person = new Person();

			string[] lines = line.Split(',');

			// Assume data is aligned
			person.LastName = CleanString(lines[0]);
			person.FirstName = CleanString(lines[1]);
			person.Gender = CleanString(lines[2]);
			person.FavoriteColor = CleanString(lines[3]);
			person.DateOfBirth = DateTime.Parse(lines[4]);

			return person;
		}

		/// <summary>
		/// Cleans the string by removing white space and any other formatting as the code is developed
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private string CleanString(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
				return "";

			return input.Trim();

		}


	}
}
