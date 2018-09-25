using System;
using System.Collections.Generic;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceStation.WebUI.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class AiHanleErrorAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if (context != null && context.HttpContext != null && context.Exception != null)
			{
				var ai = new TelemetryClient();
				ai.TrackException(context.Exception);
				ai.Track(new EventTelemetry("TestName") {Timestamp = DateTime.Now, Properties = { new KeyValuePair<string, string>("TestKey", "TestValue")}});
			}
			base.OnException(context);
		}
	}
}
