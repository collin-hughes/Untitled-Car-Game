using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.Exceptions
{
	class InvalidInstructionException : Exception
	{
		public InvalidInstructionException(int _lineNumber)
		{
			Console.WriteLine($"Invalid Instruction Name in Line {_lineNumber + 1}.");
		}
	}
}
