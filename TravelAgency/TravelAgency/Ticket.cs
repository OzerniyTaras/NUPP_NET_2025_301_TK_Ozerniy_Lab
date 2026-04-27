namespace TravelAgency.Common;

public class Ticket
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string SerialNumber { get; set; }
    public string Destination { get; set; }

    // конструктор
    public Ticket(double price, string serialNumber, string destination)
    {
        Id = Guid.NewGuid();
        Price = price;
        SerialNumber = serialNumber;
        Destination = destination;
    }

    // метод
    public string GetInfo()
    {
        return $"Квиток {SerialNumber}, напрямок: {Destination}, ціна: {Price}";
    }
}