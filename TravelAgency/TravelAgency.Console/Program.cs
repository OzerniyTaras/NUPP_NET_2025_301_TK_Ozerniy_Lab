using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure;
using TravelAgency.Infrastructure.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var options = new DbContextOptionsBuilder<TravelAgencyContext>()
    .UseSqlite("Data Source=travelagency.db")
    .Options;

using var context = new TravelAgencyContext(options);

context.Database.EnsureCreated();

var repository = new Repository<BusModel>(context);

var bus = new BusModel
{
    Id = Guid.NewGuid(),
    Name = "Mercedes Sprinter",
    Year = 2020,
    Capacity = 20,
    Route = "Полтава - Київ",
    FuelConsumption = 12.5
};

await repository.CreateAsync(bus);

var buses = await repository.GetAllAsync();

Console.WriteLine("Лабораторна робота №3");
Console.WriteLine("Робота з базою даних SQLite через Entity Framework\n");

Console.WriteLine("Автобуси в базі даних:");

foreach (var item in buses)
{
    Console.WriteLine($"{item.Name}, рік: {item.Year}, маршрут: {item.Route}, місць: {item.Capacity}");
}

Console.WriteLine($"\nКількість автобусів у БД: {buses.Count}");
Console.WriteLine("\nПрограма завершена.");