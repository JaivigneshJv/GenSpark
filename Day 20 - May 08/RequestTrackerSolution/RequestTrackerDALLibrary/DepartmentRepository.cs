using RequestTrackerDALLibrary.Model; //Change -> scaffold


namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        RequestTrackerContext context = new RequestTrackerContext();

        private List<Department> _departments;

        public DepartmentRepository()
        {
            _departments = new List<Department>();
        }

        int GenerateId()
        {

            if (_departments.Count == 0)
            {
                return 1;
            }
            int id = _departments.Count;
            return ++id;
        }

        public Department Add(Department item)
        {
            context.Departments.Add(item);
            context.SaveChanges();
            _departments = context.Departments.ToList();
            item = _departments.Find(d => d.Name == item.Name);
            return item;
        }
        public Department Delete(int key)
        {
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                _departments = context.Departments.ToList();
                return department;
            }
            return null!;
        }

        public List<Department> GetAll()
        {
            _departments = context.Departments.ToList();
            if (_departments.Count == 0)
                return null!;
            return _departments;
        }

        public Department Get(int key)
        {
            var department = _departments.SingleOrDefault(d => d.Id == key);
            if (department != null)
            {
                return department;
            }
            return null!;
        }

        public Department Update(Department item)
        {
            var department = _departments.SingleOrDefault(d => d.Id == item.Id);
            if (department != null)
            {
                department = item;
                context.Departments.Update(department);
                context.SaveChanges();
                return department;
            }
            return null!;
        }
    }
}
