using System;

class Program
{
    static void Main(string[] args)
    {
        // Orden 1: Cliente de USA ($5 costo de envío)
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "P101", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P102", 75.00, 1));
        order1.AddProduct(new Product("USB-C Cable", "P103", 8.99, 3));

        // Orden 2: Cliente Internacional ($35 costo de envío)
        Address address2 = new Address("456 Avenida Central", "Cochabamba", "Cochabamba", "Bolivia");
        Customer customer2 = new Customer("Carlos Gutierrez", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("HD Monitor 27''", "P201", 180.00, 1));
        order2.AddProduct(new Product("Gaming Headset", "P202", 45.00, 2));

        // Mostrar Resultados Orden 1
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1 DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        // Mostrar Resultados Orden 2
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2 DETAILS");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}\n");
    }
}
