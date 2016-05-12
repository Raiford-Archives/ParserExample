using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.Models
{
	public class Person
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Gender { get; set; }
		public string FavoriteColor { get; set; }
		public DateTime DateOfBirth { get; set; }


		public override string ToString()
		{
			return string.Format(@"{0,-10} {1,-10} {2, -10} {3, -10} {4, -19}", FirstName, LastName, Gender, FavoriteColor, DateOfBirth);			
		}
	}
}
