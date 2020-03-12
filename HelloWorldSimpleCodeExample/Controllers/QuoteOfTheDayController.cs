using HelloWorldSimpleCodeExample.Models.Data;
using HelloWorldSimpleCodeExample.Models.Response;
using HelloWorldSimpleCodeExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HelloWorldSimpleCodeExample.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class QuoteOfTheDayController : ControllerBase
	{
		private readonly ILogger<QuoteOfTheDayController> _logger;
		private readonly IQuoteService _quoteService;

		public QuoteOfTheDayController(ILogger<QuoteOfTheDayController> logger, IQuoteService quoteService)
		{
			_logger = logger;
			_quoteService = quoteService;
		}


		[HttpGet]
		public QuoteOfTheDayResponse Get()
		{
			string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
			Quote quoteOfTheDay = _quoteService.FindQuoteByDayOfWeek(dayOfTheWeek);

			return new QuoteOfTheDayResponse()
			{
				QuoteText = quoteOfTheDay.QuoteText,
				DayOfTheWeek = quoteOfTheDay.DayOfWeek,
				Author = quoteOfTheDay.Author
			};
		
		}
	}
}
