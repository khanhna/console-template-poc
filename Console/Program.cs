// See https://aka.ms/new-console-template for more information

using Application;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
Console.WriteLine("Hello World!");

MapperlyTest.MappingFromSource();