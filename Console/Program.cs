// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
Console.WriteLine("Hello World!");