using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class main
{
    static void Main(string[] args)
    {
        List<Car> cars = GetCarsFromUserInput();
        List<Truck> trucks = GetTrucksFromUserInput();

        DisplayFilteredCars(cars);
        DisplayGroupedCars(cars);
        DisplayOrderedTrucks(trucks);
        DisplayTruckCompanies(trucks);
    }

    static List<Car> GetCarsFromUserInput()
    {
        List<Car> cars = new List<Car>();
        Console.WriteLine("Enter car details (brand, year, price) or type 'done' to finish:");
        while (true)
        {
            Console.Write("Brand: ");
            string brand = Console.ReadLine();
            if (brand.ToLower() == "done")
                break;

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            cars.Add(new Car { Brand = brand, Year = year, Price = price });
        }
        return cars;
    }

    static List<Truck> GetTrucksFromUserInput()
    {
        List<Truck> trucks = new List<Truck>();
        Console.WriteLine("Enter truck details (brand, year, price, company) or type 'done' to finish:");
        while (true)
        {
            Console.Write("Brand: ");
            string brand = Console.ReadLine();
            if (brand.ToLower() == "done")
                break;

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Company: ");
            string company = Console.ReadLine();

            trucks.Add(new Truck { Brand = brand, Year = year, Price = price, Company = company });
        }
        return trucks;
    }

    static void DisplayFilteredCars(List<Car> cars)
    {
        // Display cars within the price range and manufactured after 1990
        var filteredCars = cars.Where(c => c.Price >= 100000 && c.Price <= 250000 && c.Year > 1990);
        foreach (var car in filteredCars)
        {
            Console.WriteLine($"Brand: {car.Brand}, Year: {car.Year}, Price: {car.Price}");
        }
    }

    static void DisplayGroupedCars(List<Car> cars)
    {
        // Group cars by brand and calculate total value for each group
        var groupedCars = cars.Where(c => c.Price >= 100000 && c.Price <= 250000 && c.Year > 1990)
                              .GroupBy(c => c.Brand)
                              .Select(group => new
                              {
                                  Brand = group.Key,
                                  TotalValue = group.Sum(c => c.Price)
                              });
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"Brand: {group.Brand}, Total Value: {group.TotalValue}");
        }
    }

    static void DisplayOrderedTrucks(List<Truck> trucks)
    {
        // Display trucks ordered by the newest year
        var orderedTrucks = trucks.OrderByDescending(t => t.Year);
        foreach (var truck in orderedTrucks)
        {
            Console.WriteLine($"Brand: {truck.Brand}, Year: {truck.Year}");
        }
    }

    static void DisplayTruckCompanies(List<Truck> trucks)
    {
        // Display the company owning each truck
        foreach (var truck in trucks)
        {
            Console.WriteLine($"Brand: {truck.Brand}, Company: {truck.Company}");
        }
    }
}
