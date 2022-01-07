using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AM.Projekt.Web.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();
var serviceInstallers = Assembly.GetExecutingAssembly().GetTypes()
    .Where(concreteInstaller =>
        typeof(IServiceInstaller).IsAssignableFrom(concreteInstaller) && !concreteInstaller.IsInterface)
    .Select(Activator.CreateInstance)
    .Cast<IServiceInstaller>().ToList();

foreach (IServiceInstaller serviceInstaller in serviceInstallers)
{
    serviceInstaller.AddServices(builder.Services, configuration);
}

var app = builder.Build();
app.UseHttpsRedirection();

foreach (IServiceInstaller installers in serviceInstallers)
{
    installers.UseService(app);
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