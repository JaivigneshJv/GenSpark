using System;
using System.Collections.Generic;
using System.Linq;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        private readonly IRepository<int, Department> _departmentRepository;

        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(Department department)
        {
            // Check for duplicate name
            var existingDepartment = _departmentRepository.GetAll().FirstOrDefault(d => d.Name == department.Name);
            if (existingDepartment != null)
            {
                throw new Exceptions.DuplicateDepartmentNameException(department.Name);
            }

            // Add department and return its ID
            var result = _departmentRepository.Add(department);
            return result.Id;
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetAll().FirstOrDefault(d => d.Name == departmentOldName);
            if (department == null)
            {
                throw new Exceptions.DepartmentNotFoundException(departmentOldName);
            }

            // Check if the new name already exists
            var existingDepartment = _departmentRepository.GetAll().FirstOrDefault(d => d.Name == departmentNewName);
            if (existingDepartment != null)
            {
                throw new Exceptions.DuplicateDepartmentNameException(departmentNewName);
            }

            // Update department name and return the updated department
            department.Name = departmentNewName;
            return _departmentRepository.Update(department);
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new Exceptions.DepartmentNotFoundException(id);
            }
            return department;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetAll().FirstOrDefault(d => d.Name == departmentName);
            if (department == null)
            {
                throw new Exceptions.DepartmentNotFoundException(departmentName);
            }
            return department;
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = GetDepartmentById(departmentId);
            return department.DepartmentHead;
        }

        public List<Department> GetDepartmentList()
        {
            return _departmentRepository.GetAll().ToList();
        }
    }
}
