using System.Diagnostics.CodeAnalysis;


namespace ShoppingModelLibrary
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public string Name { get; set; }
        public int Age { get; set; }
        
        public int CompareTo(Customer? other)
        {
            if (this.Age == other.Age)
                return 0;
            else if (this.Age < other.Age)
                return -1;
            else
                return 1;
            
        }
        
        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
        
        public override string ToString()
        {
            return Id + " " + Name + " " + Age + " " + Phone;
        }
    }

    
    public class SortByCustomerName : IComparer<Customer>
    {

        public int Compare(Customer? x, Customer? y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}