namespace RequestTrackerModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentHead { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Department department)
            {
                return Name == department.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return $"{Id}: {Name ?? "Unnamed Department"} (Head ID: {DepartmentHead})";
        }
    }
}
