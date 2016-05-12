using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.Core;
using System.Collections.Generic;
using Parser.Core.Models;

namespace Parser.UnitTests
{
	[TestClass]
	public class FileParserTests
	{
		[TestMethod]
		public void Basic_Usage()
		{
			string fullFileNamme = @"c:\temp\testdata.txt";


			FileParser parser = new FileParser();
			Sorter sorter = new Sorter();

			IList<Person> people = parser.ParseFile(fullFileNamme);

			IList<Person> sorted1 = sorter.Sort(people, SortOutputFormat.Output1);
			IList<Person> sorted2 = sorter.Sort(people, SortOutputFormat.Output2);
			IList<Person> sorted3 = sorter.Sort(people, SortOutputFormat.Output3);

			// Verify the sorted lists are as expect using the test data





		}
	}
}
