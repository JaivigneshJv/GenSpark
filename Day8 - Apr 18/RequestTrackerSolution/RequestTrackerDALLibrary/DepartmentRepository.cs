using System.Collections.Generic;
using System.Linq;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        private readonly List<Department> _departments;

        public DepartmentRepository()
        {
            _departments = new List<Department>();
        }

        public Department Add(Department entity)
        {
            _departments.Add(entity);
            return entity;
        }

        public Department Update(Department entity)
        {
            var existingDepartment = GetById(entity.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = entity.Name;
                existingDepartment.DepartmentHead = entity.DepartmentHead;
                return existingDepartment;
            }

            throw new Exception("Failed to update department.");
        }

        public Department? GetById(int id)
        {
            return _departments.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _departments.Remove(department);
            }
        }
    }
}
