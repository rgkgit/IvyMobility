using AutoMapper;
using AutoMapper.Execution;
using ShoppingCart.Interface;
using ShoppingCart.Model;
using ShoppingCart.Provider.EntityModel;
using ShoppingCart.Provider.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public class EmployeeService : IEmployee
    {
        UnitOfWork _unitOfWork;
        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddOrUpdateEmployee(EmployeeModel employeeModel)
        {
            bool flag = false;
            try
            {
                var _context = _unitOfWork.GetRepoInstance<Employee>();
                if (employeeModel.EmployeeId != 0)
                {
                    Employee employee = await _context.GetById(employeeModel.EmployeeId);
                    if (employee != null)
                    {
                        employee.Name = employeeModel.Name;
                        employee.Age = employeeModel.Age;
                        employee.UpdatedDate = DateTime.Now;
                        employee.UpdatedBy = 1;
                    }
                    flag = await _context.Update(employee);
                }
                else
                {
                    Employee employeeEntity = Mapper.Map<Employee>(employeeModel);
                    employeeEntity.CreatedDate = DateTime.Now;
                    employeeEntity.CreatedBy = 1;
                    employeeEntity.UpdatedDate = DateTime.Now;
                    employeeEntity.UpdatedBy = 1;
                    flag = await _unitOfWork.GetRepoInstance<Employee>().Add(employeeEntity);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public async Task<bool> DeleteEmployee(EmployeeModel EmployeeModel)
        {
            bool flag = false;
            try
            {
                var _context = _unitOfWork.GetRepoInstance<Employee>();
                Employee Employee = await _context.GetById(EmployeeModel.EmployeeId);
                if (Employee == null)
                {
                    return flag;
                }

                _context.Delete(Employee);
                flag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
               var employeeList = _unitOfWork.GetRepoInstance<Employee>().GetAll().ToList();
                if(employeeList.Count() > 0)
                    employees = Mapper.Map<List<EmployeeModel>>(employeeList);
                            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }

        public async Task<EmployeeModel> GetEmployeeById(long employeeId)
        {
            EmployeeModel employee = new EmployeeModel();
            try
            {
                var employeeDetail = await _unitOfWork.GetRepoInstance<Employee>().GetById(employeeId);
                if (employeeDetail != null)
                    employee = Mapper.Map<EmployeeModel>(employeeDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employee;
        }
    }
}
