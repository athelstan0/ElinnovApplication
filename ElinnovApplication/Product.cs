class Product
{
    private static int _nextProductId = 1;
    public int ProductId { get; private set; } = _nextProductId++; // Since ID auto increments from 1 to n, integer will always be positive.
    public string Name { get; set; }
    public int QuantityInStock { get; set; }
    public decimal Price { get; set; }

    public decimal TotalValue => QuantityInStock * Price;

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {Name}, Quantity: {QuantityInStock}, Price: ${Price}, Value: ${TotalValue}";
    }
}
