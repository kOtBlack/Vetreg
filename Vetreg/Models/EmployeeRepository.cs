using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetreg.Data;

namespace Vetreg.Models {
    public class EmployeeRepository : IEmployeeRepository {


        private ApplicationDbContext _service;

        public EmployeeRepository(ApplicationDbContext service) {
            _service = service;


        }


        public Employee Add(Employee employee)
        {

            throw new NotImplementedException();
        }

        public void Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
