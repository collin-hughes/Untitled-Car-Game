using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.Exceptions
{
	class InvalidInstructionFileException : Exception
	{
		public InvalidInstructionFileException()
		{
			Console.WriteLine("Invalid Instruction File(s).");
		}
	}
}
