using HelloWorldSimpleCodeExample.Controllers;
using HelloWorldSimpleCodeExample.Models.Data;
using HelloWorldSimpleCodeExample.Models.Response;
using HelloWorldSimpleCodeExample.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HelloWorldSimpleCodeExampleTest
{
	public class QuoteOfTheDayControllerTest
	{
		[Fact]
		public void QuoteOfTheDayController_should_return_quote_and_day()
		{
			var mockService = new Mock<IQuoteService>();

			var quote = new Quote()
			{
				QuoteText = "Test Quote",
				DayOfWeek = "Saturday"
			};

			mockService.Setup(x => x.FindQuoteByDayOfWeek(It.IsAny<string>())).Returns(quote);

			var mockLogger = new Mock<ILogger<QuoteOfTheDayController>>();

			var controller = new QuoteOfTheDayController(mockLogger.Object, mockService.Object);

			var result = controller.Get();

			Assert.Equal("Test Quote", result.QuoteText);
			Assert.Equal("Saturday", result.DayOfTheWeek);
		}

		[Fact]
		public void QuoteOfTheDayController_should_return_correct_response_type()
		{
			var mockService = new Mock<IQuoteService>();

			var quote = new Quote()
			{
				QuoteText = "Test Quote",
				DayOfWeek = "Monday"
			};

			mockService.Setup(x => x.FindQuoteByDayOfWeek(It.IsAny<string>())).Returns(quote);

			var mockLogger = new Mock<ILogger<QuoteOfTheDayController>>();

			var controller = new QuoteOfTheDayController(mockLogger.Object, mockService.Object);

			var result = controller.Get();

			Assert.IsType<QuoteOfTheDayResponse>(result);
		}
	}
}
