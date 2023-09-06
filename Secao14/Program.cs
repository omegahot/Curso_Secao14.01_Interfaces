﻿using Secao14.Entities;
using System.Globalization;
using Secao14.Services;
class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter rental data:");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE:");
            Console.WriteLine(carRental.Invoice);
        }
        catch (FormatException e)
        {
            Console.WriteLine("ERRO: Formato de data inválido. Utilizar o formato (dd/MM/yyyy hh:mm) ");
            Console.WriteLine(e.Message);
        }
        
    }
}