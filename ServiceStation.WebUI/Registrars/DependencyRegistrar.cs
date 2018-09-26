using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;

using ServiceStation.WebUI.Filters;

namespace ServiceStation.WebUI.Registrars
{
    internal static class DependencyRegistrar
    {
	    public static void Register(IServiceCollection services)
	    {
			services.AddSingleton<TelemetryClient>();
		    services.AddSingleton<AiHanleErrorAttribute>();
		}
    }
}
