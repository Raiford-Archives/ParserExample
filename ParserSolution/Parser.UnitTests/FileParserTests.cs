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

			// Verify Output1 - Sorted by Gender
			Assert.IsTrue(sorted1[0].FirstName == "Jackie" && sorted1[0].LastName == "Anderson" && sorted1[0].Gender == "Female");
			Assert.IsTrue(sorted1[1].FirstName == "Beth" && sorted1[1].LastName == "Smith" && sorted1[1].Gender == "Female");
			Assert.IsTrue(sorted1[2].FirstName == "Jack" && sorted1[2].LastName == "Anderson" && sorted1[2].Gender == "Male");


			// Verify Output2 - Sorted by Birthdate ASC
			Assert.IsTrue(sorted2[0].FirstName == "Jackie" && sorted2[0].LastName == "Anderson");
			Assert.IsTrue(sorted2[1].FirstName == "Joe" && sorted2[1].LastName == "Smith");
			Assert.IsTrue(sorted2[2].FirstName == "Beth" && sorted2[2].LastName == "Smith");

			// Verify Output3 - Sorted by Lastname DESC
			Assert.IsTrue(sorted3[0].LastName == "Smith");
			Assert.IsTrue(sorted3[1].LastName == "Smith");
			Assert.IsTrue(sorted3[2].LastName == "Smith");
			Assert.IsTrue(sorted3[3].LastName == "Black");
			Assert.IsTrue(sorted3[4].LastName == "Black");
			Assert.IsTrue(sorted3[5].LastName == "Black");
			Assert.IsTrue(sorted3[6].LastName == "Black");
			Assert.IsTrue(sorted3[7].LastName == "Anderson");
			Assert.IsTrue(sorted3[8].LastName == "Anderson");
			Assert.IsTrue(sorted3[9].LastName == "Anderson");

		}
	}
}
