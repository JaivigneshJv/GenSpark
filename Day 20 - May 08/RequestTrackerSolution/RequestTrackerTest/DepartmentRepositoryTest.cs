using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerTest
{
    public class DepartmentRepositoryTest
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            //repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            Department department1 = new Department() { Name = "IT", Department_Head = 101 };
            Department department2 = new Department() { Name = "CSE", Department_Head = 102 };
            List<Department> departments;
            //Action
            var result1 = repository.Add(department1);
            var result2 = repository.Add(department2);
            departments = repository.GetAll();
            //Assert
            //Assert.IsNotNull(departments);
            Assert.That(departments.Count, Is.EqualTo(2));
        }

        [TestCase(1, "Hr", 101)]
        [TestCase(2, "Admin", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}

