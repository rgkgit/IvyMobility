using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Interface
{
    public interface IEmployee
    {
        Task<List<EmployeeModel>> GetAllEmployee();
        Task<EmployeeModel> GetEmployeeById(long EmployeeId);
        Task<bool> AddOrUpdateEmployee(EmployeeModel EmployeeModel);
        Task<bool> DeleteEmployee(EmployeeModel EmployeeModel);
    }
}
