namespace TravelAgency.Common;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }

    // статичне поле
    public static int VehicleCount;

    // статичний конструктор
    static Vehicle()
    {
        VehicleCount = 0;
    }

    // конструктор
    public Vehicle()
    {
        Id = Guid.NewGuid();
        VehicleCount++;
    }

    // метод
    public virtual string GetInfo()
    {
        return $"{Name}, рік: {Year}";
    }

    // статичний метод
    public static int GetVehicleCount()
    {
        return VehicleCount;
    }
}