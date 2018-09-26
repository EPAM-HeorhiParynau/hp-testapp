using System;

using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceStation.WebUI.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class AiHanleErrorAttribute : ExceptionFilterAttribute
	{
		private readonly TelemetryClient telemetryClient;

		public AiHanleErrorAttribute(TelemetryClient telemetryClient)
		{
			this.telemetryClient = telemetryClient;
		}

		public override void OnException(ExceptionContext context)
		{
			if (context != null && context.HttpContext != null && context.Exception != null)
			{
				this.telemetryClient.TrackException(context.Exception);
			}

			base.OnException(context);
		}
	}
}
