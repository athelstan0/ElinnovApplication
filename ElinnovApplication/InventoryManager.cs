class InventoryManager
{
    private Dictionary<int, Product> _products = new();

    public void AddProduct(Product product) //Method to add a product
    {
        if (_products.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product ID already exists.");
            return;
        }

        _products[product.ProductId] = product;
        Console.WriteLine("Product added successfully.");
    }

    public void RemoveProduct(int productId) //Method to remove product
    {
        if (_products.Remove(productId))
            Console.WriteLine("Product removed successfully.");
        else
            Console.WriteLine("Product not found.");
    }

    public void UpdateProduct(int productId, int newQuantity, decimal newPrice) //Method to update product
    {
        if (!_products.ContainsKey(productId))
        {
            Console.WriteLine("Product not found.");
            return;
        }
        var product = _products[productId];
        product.QuantityInStock = newQuantity;
        product.Price = newPrice;
        Console.WriteLine("Product updated successfully.");
    }

    public void GetProductName(int productId) //Method to get product name
    {
        if (!_products.ContainsKey(productId))
        {
            Console.WriteLine("Product not found.");
            return;
        }
        Console.WriteLine("Product Name: " + _products[productId].Name);
    }

    public void ListProducts() //Method to list products
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

    public decimal GetTotalValue() //Method to get total value
    {
        decimal total = 0;
        foreach (var product in _products.Values)
            total += product.TotalValue;
        return total;
    }
}