using HelloWorldSimpleCodeExample.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HelloWorldSimpleCodeExample.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class HelloWorldController : ControllerBase
	{
		private readonly ILogger<HelloWorldController> _logger;

		public HelloWorldController(ILogger<HelloWorldController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public HelloWorldResponse Get()
		{
			string message = "Hello World!";
			string subMessage = string.Format("It's {0} on {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString());

			return new HelloWorldResponse()
			{
				Message = message,
				SubMessage = subMessage
			};
		}
	}
}
