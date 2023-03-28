// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Application.Mapping;
using Application.Models;
using AutoMapper;
using Domain;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var serviceProvider = services.AddAutoMapper(typeof(MappingProfile).Assembly).BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var mapper = scope.ServiceProvider.GetService<IMapper>();

var initialData = DataContext.GenerateInitialData();
var mappedData = mapper.Map<PersonDto>(initialData);

Console.WriteLine("==============");
Console.WriteLine("Initial Data:");
Console.WriteLine(JsonSerializer.Serialize(initialData, new JsonSerializerOptions { WriteIndented = true }));

Console.WriteLine("==============");
Console.WriteLine("Mapped Data:");
Console.WriteLine(JsonSerializer.Serialize(mappedData, new JsonSerializerOptions { WriteIndented = true }));
