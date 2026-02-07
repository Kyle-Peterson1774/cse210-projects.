using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Reno", "NV", "USA");
        Customer customer1 = new Customer("Kyle Peterson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Creatine Gummies - Watermelon", "CG-1001", 29.99, 2));
        order1.AddProduct(new Product("Shaker Bottle", "SB-2002", 9.99, 1));
        order1.AddProduct(new Product("Sticker Pack", "SP-3003", 3.50, 3));

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");

        Address address2 = new Address("55 King Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alicia Chen", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Creatine Gummies - Mango", "CG-1002", 29.99, 1));
        order2.AddProduct(new Product("Workout Bands", "WB-4004", 14.99, 2));

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
        Console.WriteLine("====================================");
    }
}
