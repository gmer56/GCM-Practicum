using System;

namespace Practicum
{
	public class InvalidEntryException : Exception
	{
		public InvalidEntryException()
        {
        }

		  public InvalidEntryException(string message)
            : base(message)
        {
        }
	}
}
