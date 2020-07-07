using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetreg.Models {
    interface IEmployeeRepository {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Add(Employee employee);
        void Create(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
        Employee Delete(Employee employee);
    }
}
