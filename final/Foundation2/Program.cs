using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Product product1 = new Product("Nike Print T Shirt - Red", "Nk001", 12.99, 5);
        Product product2 = new Product("Nike Print T Shirt - Yellow", "Nk002", 13.99, 6);
        Product product3 = new Product("Nike Print T Shirt - Blue", "Nk003", 10.99, 7);
        Product product4 = new Product("Nike Print T Shirt - Pink", "Nk004", 11.99, 8);
        Product product5 = new Product("Nike Print T Shirt - Black", "Nk005", 9.99, 9);
        Product product6 = new Product("Nike Print T Shirt - Gray", "Nk006", 14.99, 10);

        Address address1 = new Address("567 Hilltop Road", "Olympia", "Washington", "USA");
        Customer customer1 = new Customer("Amanda Dark", address1);

        Address address2 = new Address("29 Stroude Road", "Sissinghurst", "", "UK");
        Customer customer2 = new Customer("Hanif Shah", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product5);
        order1.AddProduct(product6);
        orders.Add(order1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product2);
        order2.AddProduct(product1);   
        orders.Add(order2);   

        foreach (Order order in orders)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine($"Total Price: ${order.GetTotalCost()}");
            Console.WriteLine("--------------------");
        }
    }
}