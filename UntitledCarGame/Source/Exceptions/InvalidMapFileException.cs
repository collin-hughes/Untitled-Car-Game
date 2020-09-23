using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.Exceptions
{
	class InvalidMapFileException : Exception
	{
		public InvalidMapFileException()
		{
			Console.WriteLine("Invalid Map File.");
		}
	}
}
