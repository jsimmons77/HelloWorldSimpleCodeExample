using HelloWorldSimpleCodeExample.Models.Data;
using HelloWorldSimpleCodeExample.Models.Response;
using HelloWorldSimpleCodeExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldSimpleCodeExample.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class QuoteOfTheDayListController : ControllerBase
	{
		private readonly ILogger<QuoteOfTheDayListController> _logger;
		private readonly IQuoteService _quoteService;

		public QuoteOfTheDayListController(ILogger<QuoteOfTheDayListController> logger, IQuoteService quoteService)
		{
			_logger = logger;
			_quoteService = quoteService;
		}

		[HttpGet]
		public QuoteOfTheDayResponse[] Get()
		{
			var listForResponse = new List<QuoteOfTheDayResponse>();

			try
			{
				var quoteOfTheDayList = _quoteService.AllQuotes().OrderBy(q => q.QuoteIndex);

				listForResponse = BuildListForResponse(quoteOfTheDayList, ref listForResponse);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while getting list of quotes", null); // TODO: add more robust error handling logic here
			}

			return listForResponse.ToArray<QuoteOfTheDayResponse>();
		}

		private List<QuoteOfTheDayResponse> BuildListForResponse(IEnumerable<Quote> quoteOfTheDayList, ref List<QuoteOfTheDayResponse> listForResponse)
		{
			foreach (Quote quote in quoteOfTheDayList)
			{
				listForResponse.Add(new QuoteOfTheDayResponse()
				{
					QuoteText = quote.QuoteText,
					Author = quote.Author,
					DayOfTheWeek = quote.DayOfWeek
				});
			}

			return listForResponse;
		}
	}
}
