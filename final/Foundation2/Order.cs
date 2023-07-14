using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products; 
    private Customer _customer;

    public Order (Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.GetTotalPrice();
        }

        return totalCost += _customer.IsUSA() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Orders:\n";

        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()}\t({product.GetID()})\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Customer:\n{_customer.GetName()}\n{_customer.GetAddress().GetDetailAddress()}";
    }
}