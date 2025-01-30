using System;

public class Order
{
    public List<Product> Products {get; set;}
    public Customer Customer {get; set;}

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public float CalculateTotalPrice()
    {
        float totalCost = 0;
        
        foreach (var product in Products)
        {
            totalCost += product.CalculateTotalCost();
        }

        float shippingCost = Customer.IsInUSA() ? 5.0f : 35.0f;
        totalCost += shippingCost;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in Products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label: \n{Customer.Name}\n{Customer.CustomerAddress.GetFullAddress()}\n";
    }
}