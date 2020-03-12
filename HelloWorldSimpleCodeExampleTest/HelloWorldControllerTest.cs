using HelloWorldSimpleCodeExample.Controllers;
using HelloWorldSimpleCodeExample.Models.Data;
using HelloWorldSimpleCodeExample.Models.Response;
using HelloWorldSimpleCodeExample.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HelloWorldSimpleCodeExampleTest
{
	public class HelloWorldControllerTest
	{
		[Fact]
		public void HelloController_should_return_message_and_submessage()
		{
			var mockLogger = new Mock<ILogger<HelloWorldController>>();

			var controller = new HelloWorldController(mockLogger.Object);

			var response = controller.Get();

			Assert.Equal("Hello World!", response.Message);
			Assert.StartsWith("It's ", response.SubMessage);
		}

		[Fact]
		public void QuoteOfTheDayController_should_return_correct_response_type()
		{
			var mockLogger = new Mock<ILogger<HelloWorldController>>();

			var controller = new HelloWorldController(mockLogger.Object);

			var result = controller.Get();

			Assert.IsType<HelloWorldResponse>(result);
		}
	}
}
