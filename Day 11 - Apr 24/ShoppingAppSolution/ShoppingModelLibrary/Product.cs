namespace ShoppingModelLibrary
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int QuantityInHand { get; set; }

        public override string ToString()
        {
            return "Id: " + Id +
                "\nName: " + Name +
                "\nPrice: $" + Price +
                "\nQuantity in Stock: " + QuantityInHand;
        }

        public bool Equals(Product? other)
        {
            if (other is null)
                return false;

            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
