using TravelAgency.Common;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var service = new CrudServiceAsync<Bus>();

Console.WriteLine("Генерація 1000 автобусів...");

Parallel.For(0, 1000, i =>
{
    var bus = new Bus($"Bus-{i}", 2000 + (i % 20), 20 + (i % 30), "Route", 10 + i);
    service.CreateAsync(bus).Wait();
});

Console.WriteLine("Готово!");

var all = await service.ReadAllAsync();

Console.WriteLine($"\nВсього автобусів: {all.Count()}");

// LINQ статистика
var newest = all.OrderByDescending(x => x.Year).First();
var avgCapacity = all.Average(x => x.Capacity);

Console.WriteLine($"\nНайновіший автобус: {newest.GetInfo()}");
Console.WriteLine($"Середня кількість місць: {avgCapacity}");

Console.WriteLine("\nТоп 5 автобусів:");

foreach (var bus in all.Take(5))
{
    Console.WriteLine(bus.GetInfo());
}

Console.WriteLine("\nПрограма завершена.");