namespace TravelAgency.Common;

public class Car : Vehicle
{
    public string Brand { get; set; }
    public int Seats { get; set; }
    public double RentalPrice { get; set; }

    // конструктор
    public Car(string name, int year, string brand, int seats, double rentalPrice)
    {
        Name = name;
        Year = year;
        Brand = brand;
        Seats = seats;
        RentalPrice = rentalPrice;
    }

    // метод
    public override string GetInfo()
    {
        return $"Авто: {Brand} {Name}, рік: {Year}, місць: {Seats}, ціна оренди: {RentalPrice}";
    }
}