using HelloWorldSimpleCodeExample.Controllers;
using HelloWorldSimpleCodeExample.Models.Data;
using HelloWorldSimpleCodeExample.Models.Response;
using HelloWorldSimpleCodeExample.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HelloWorldSimpleCodeExampleTest
{
	public class QuoteOfTheDayListControllerTest
	{
		[Fact]
		public void QuoteOfTheDayListController_should_get_full_list()
		{
			var mockService = new Mock<IQuoteService>();

			var quoteList = new List<Quote>()
			{
				new Quote()
				{
					QuoteIndex = 1,
					QuoteText = "Monday Quote",
					DayOfWeek = "Monday"
				},
				new Quote()
				{
					QuoteIndex = 2,
					QuoteText = "Tuesday Quote",
					DayOfWeek = "Tuesday"
				},
				new Quote()
				{
					QuoteIndex = 3,
					QuoteText = "Wednesday Quote",
					DayOfWeek = "Wednesday"
				},
				new Quote()
				{
					QuoteIndex = 4,
					QuoteText = "Thursday Quote",
					DayOfWeek = "Thursday"
				},
				new Quote()
				{
					QuoteIndex = 5,
					QuoteText = "Friday Quote",
					DayOfWeek = "Friday"
				},
				new Quote()
				{
					QuoteIndex = 6,
					QuoteText = "Saturday Quote",
					DayOfWeek = "Saturday"
				},
				new Quote()
				{
					QuoteIndex = 7,
					QuoteText = "Sunday Quote",
					DayOfWeek = "Sunday"
				}
			};
 
			mockService.Setup(x => x.AllQuotes()).Returns(quoteList);

			var mockLogger = new Mock<ILogger<QuoteOfTheDayListController>>();

 			var controller = new QuoteOfTheDayListController(mockLogger.Object, mockService.Object);

			var results = controller.Get();

			Assert.Equal(7, results.Length);

			Assert.Equal("Monday Quote", results[0].QuoteText);
			Assert.Equal("Sunday Quote", results[6].QuoteText);
		}

		[Fact]
		public void QuoteOfTheDayListController_should_get_list_in_order()
		{
			var mockService = new Mock<IQuoteService>();

			var quoteList = new List<Quote>()
			{
				new Quote()
				{
					QuoteIndex = 2,
					QuoteText = "Tuesday Quote",
					DayOfWeek = "Tuesday"
				},
				new Quote()
				{
					QuoteIndex = 1,
					QuoteText = "Monday Quote",
					DayOfWeek = "Monday"
				},
				new Quote()
				{
					QuoteIndex = 5,
					QuoteText = "Friday Quote",
					DayOfWeek = "Friday"
				},
				new Quote()
				{
					QuoteIndex = 4,
					QuoteText = "Thursday Quote",
					DayOfWeek = "Thursday"
				},
				new Quote()
				{
					QuoteIndex = 3,
					QuoteText = "Wednesday Quote",
					DayOfWeek = "Wednesday"
				},
				new Quote()
				{
					QuoteIndex = 7,
					QuoteText = "Sunday Quote",
					DayOfWeek = "Sunday"
				},
				new Quote()
				{
					QuoteIndex = 6,
					QuoteText = "Saturday Quote",
					DayOfWeek = "Saturday"
				}
			};

			mockService.Setup(x => x.AllQuotes()).Returns(quoteList);

			var mockLogger = new Mock<ILogger<QuoteOfTheDayListController>>();

			var controller = new QuoteOfTheDayListController(mockLogger.Object, mockService.Object);

			var results = controller.Get();

			Assert.Equal(7, results.Length);

			Assert.Equal("Monday Quote", results[0].QuoteText);
			Assert.Equal("Tuesday Quote", results[1].QuoteText);
			Assert.Equal("Wednesday Quote", results[2].QuoteText);
			Assert.Equal("Thursday Quote", results[3].QuoteText);
			Assert.Equal("Friday Quote", results[4].QuoteText);
			Assert.Equal("Saturday Quote", results[5].QuoteText);
			Assert.Equal("Sunday Quote", results[6].QuoteText);
		}

		[Fact]
		public void QuoteOfTheDayListController_should_get_correct_response_type()
		{
			var mockService = new Mock<IQuoteService>();

			var quoteList = new List<Quote>()
			{
				new Quote()
				{
					QuoteIndex = 2,
					QuoteText = "Tuesday Quote",
					DayOfWeek = "Tuesday"
				},
				new Quote()
				{
					QuoteIndex = 1,
					QuoteText = "Monday Quote",
					DayOfWeek = "Monday"
				}
			};

			mockService.Setup(x => x.AllQuotes()).Returns(quoteList);

			var mockLogger = new Mock<ILogger<QuoteOfTheDayListController>>();

			var controller = new QuoteOfTheDayListController(mockLogger.Object, mockService.Object);

			var results = controller.Get();

			Assert.IsType<QuoteOfTheDayResponse[]>(results);
		}

	}
}
