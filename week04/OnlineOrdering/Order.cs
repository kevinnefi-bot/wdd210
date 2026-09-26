using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInUsa() ? 5.0 : 35.0;
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- PACKING LABEL ---");
        foreach (Product product in _products)
        {
            label.AppendLine($"ID: {product.GetProductId()} | Product: {product.GetName()}");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- SHIPPING LABEL ---");
        label.AppendLine($"Customer Name: {_customer.GetName()}");
        label.AppendLine(_customer.GetAddress().GetFormattedAddress());
        return label.ToString();
    }
}