namespace TravelAgency.Common;

public class Bus : Vehicle
{
    public int Capacity { get; set; }
    public string Route { get; set; }
    public double FuelConsumption { get; set; }

    // делегат
    public delegate void BusCreatedHandler(string message);

    // подія
    public event BusCreatedHandler BusCreated;

    // конструктор
    public Bus(string name, int year, int capacity, string route, double fuelConsumption)
    {
        Name = name;
        Year = year;
        Capacity = capacity;
        Route = route;
        FuelConsumption = fuelConsumption;

        BusCreated?.Invoke($"Автобус {Name} створено");
    }

    // метод
    public override string GetInfo()
    {
        return $"Автобус: {Name}, рік: {Year}, маршрут: {Route}, місць: {Capacity}";
    }
}