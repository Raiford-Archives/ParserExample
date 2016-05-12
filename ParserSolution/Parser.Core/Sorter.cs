using Parser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{

	/// <summary>
	/// Sort Output according to spec
	/// </summary>
	public enum SortOutputFormat
	{
		/// <summary>
		/// sorted by gender(females before males) then by last name ascending.
		/// </summary>
		Output1 = 1,
		/// <summary>
		/// sorted by birth date, ascending
		/// </summary>
		Output2 = 2,
		/// <summary>
		/// sorted by last name, descending
		/// </summary>
		Output3 = 3
	}

	/// <summary>
	/// Helper class to encapsulate the sorting behavior of people
	/// </summary>
	public class Sorter
	{

		/// <summary>
		/// Sorts a Person collection and returns the sorted results.
		/// </summary>
		/// <param name="people"></param>
		/// <param name="sortFormat"></param>
		/// <returns></returns>
		public IList<Person> Sort(IList<Person> people, SortOutputFormat sortFormat)
		{
			IList<Person> sorted = null;

			switch(sortFormat)
			{
				case SortOutputFormat.Output1:
					{
						sorted = people.OrderBy(p => p.Gender).ThenBy((p => p.LastName)).ToList();
						break;
					}
				case SortOutputFormat.Output2:
					{
						sorted = people.OrderBy(p => p.DateOfBirth).ToList();
						break;
					}
				case SortOutputFormat.Output3:
						sorted = people.OrderByDescending(p => p.LastName).ToList();
						break;
			}

			return sorted;
		}		

	}
}
