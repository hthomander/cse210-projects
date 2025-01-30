using System;

class Program
{
    static void Main()
    {
        Address address = new Address("123 Elm St", "Springfield", "IL", "USA");

        Customer customer = new Customer("Hazel Beth", address);

        Product product1 = new Product("Laptop", "P12345", 999.99f, 2);
        Product product2 = new Product("Mouse", "P12346", 19.99f, 1);

        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");

        Address internationalAddress = new Address("456 Pine St", "London", "ENG", "UK");
        Customer internationalCustomer = new Customer("Jane Doe", internationalAddress);
        order internationalOrder = new order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Tablet", "P54321", 499.99f, 1));

        Console.WriteLine("\n" + internationalOrder.GetPackingLabel());
        Console.WriteLine(internationalOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${internationalOrder.CalculateTotalPrice()}");
    }