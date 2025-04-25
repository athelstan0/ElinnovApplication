class InventoryManager
{
    private Dictionary<int, Product> _products = new();

    public void AddProduct(Product product)
    {
        if (_products.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product ID already exists.");
            return;
        }

        _products[product.ProductId] = product;
        Console.WriteLine("Product added successfully.");
    }

    public void RemoveProduct(int productId)
    {
        if (_products.Remove(productId))
            Console.WriteLine("Product removed successfully.");
        else
            Console.WriteLine("Product not found.");
    }

    public void UpdateProduct(int productId, int newQuantity)
    {
        if (_products.TryGetValue(productId, out var product))
        {
            product.QuantityInStock = newQuantity;
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ListProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        foreach (var product in _products.Values)
        {
            Console.WriteLine(product);
        }
    }

    public decimal GetTotalValue()
    {
        decimal total = 0;
        foreach (var product in _products.Values)
            total += product.TotalValue;
        return total;
    }
}