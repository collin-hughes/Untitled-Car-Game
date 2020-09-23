using System;


namespace UntitledCarGame.Exceptions
{
	class InvalidMemoryLocationException : Exception
	{
		public InvalidMemoryLocationException(int _lineNumber)
		{
			Console.WriteLine($"Invalid Memory Location in Line {_lineNumber + 1}.");
		}

	}
}
