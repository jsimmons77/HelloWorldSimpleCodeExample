using HelloWorldSimpleCodeExample.Data;
using HelloWorldSimpleCodeExample.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldSimpleCodeExample.Services
{
	public class QuoteService : IQuoteService
	{
		private readonly LocalDbContext _dbContext;
		public QuoteService(LocalDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Quote> AllQuotes()
		{
			return _dbContext.Quote
				.OrderBy(x => x.QuoteIndex)
				.ToList();
		}

		public Quote FindQuoteByDayOfWeek(string dayOfWeek)
		{
			return _dbContext.Quote.Where(f => f.DayOfWeek == dayOfWeek).FirstOrDefault();
		}
	}
}
