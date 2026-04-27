using TravelAgency.Common;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Лабораторна робота №1".ToTitleText());
Console.WriteLine("Демонстрація роботи CRUD сервісу\n");

var busService = new CrudService<Bus>();
var carService = new CrudService<Car>();
var ticketService = new CrudService<Ticket>();

var bus = new Bus("Mercedes Sprinter", 2020, 20, "Полтава - Київ", 12.5);
var car = new Car("Octavia", 2019, "Skoda", 5, 1200);
var ticket = new Ticket(450, "TK-001", "Київ");

busService.Create(bus);
carService.Create(car);
ticketService.Create(ticket);

Console.WriteLine("Додані об'єкти:");

foreach (var item in busService.ReadAll())
{
    Console.WriteLine(item.GetInfo());
}

foreach (var item in carService.ReadAll())
{
    Console.WriteLine(item.GetInfo());
}

foreach (var item in ticketService.ReadAll())
{
    Console.WriteLine(item.GetInfo());
}

Console.WriteLine($"\nКількість створених транспортних засобів: {Vehicle.GetVehicleCount()}");

Console.WriteLine("\nПошук автобуса за Id:");
var foundBus = busService.Read(bus.Id);
Console.WriteLine(foundBus.GetInfo());

Console.WriteLine("\nВидалення квитка...");
ticketService.Remove(ticket);

Console.WriteLine($"Кількість квитків після видалення: {ticketService.ReadAll().Count()}");

Console.WriteLine("\nПрограма завершена.");