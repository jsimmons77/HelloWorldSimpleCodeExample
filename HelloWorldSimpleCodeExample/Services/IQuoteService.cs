using HelloWorldSimpleCodeExample.Models.Data;
using System.Collections.Generic;

namespace HelloWorldSimpleCodeExample.Services
{
	public interface IQuoteService
	{
		List<Quote> AllQuotes();

		Quote FindQuoteByDayOfWeek(string dayOfWeek);
	}
}
