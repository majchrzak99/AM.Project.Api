using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AM.Projekt.Web.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var serviceInstallers = Assembly.GetExecutingAssembly().GetTypes()
    .Where(concreteInstaller =>
        typeof(IServiceInstaller).IsAssignableFrom(concreteInstaller) && !concreteInstaller.IsInterface)
    .Select(Activator.CreateInstance)
    .Cast<IServiceInstaller>().ToList();

foreach (IServiceInstaller serviceInstaller in serviceInstallers)
{
    serviceInstaller.AddServices(builder.Services);
}

var app = builder.Build();
app.UseHttpsRedirection();

foreach (IServiceInstaller serviceInstaller in serviceInstallers)
{
    serviceInstaller.UseService(app);
}

var endpointDefinitions = Assembly.GetExecutingAssembly().GetTypes()
    .Where(concreteInstaller =>
        typeof(IEndpointDefinition).IsAssignableFrom(concreteInstaller) && !concreteInstaller.IsInterface)
    .Select(Activator.CreateInstance)
    .Cast<IEndpointDefinition>().ToList();

foreach (var endpointDefinition in endpointDefinitions)
{
    endpointDefinition.DefineEndpoints(app);
}

app.Run();