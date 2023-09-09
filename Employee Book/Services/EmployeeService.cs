using Employee_Book.DbConfig;
using Employee_Book.Models;
using System;

namespace Employee_Book.Services
{
	public class EmployeeService
	{
		private readonly EmployeeDbContext _employeeDbContext;
		public EmployeeService(EmployeeDbContext employeeDbContext) {
			_employeeDbContext = employeeDbContext;
		}

		 public List<Employee> GetEmployee()
		{
			var list = new List<Employee>();

			var dbData=_employeeDbContext.Employees.OrderByDescending(e => e.Id).ToList();

			if (dbData?.Any() != null)
			{
               foreach(var employee in dbData)
				{
					list.Add(new Employee()
					{
						Id= employee.Id,
						Name= employee.Name,
						Email= employee.Email,
						Phone= employee.Phone,
						Address	= employee.Address,
						CreatedAt = employee.CreatedAt
					});
				}
			}
			return list;

			}
		public int  AddEmp(Employee employee)
		{
			var newEmployee = new Employee()
			{
				Name=employee.Name,
				Email=employee.Email,	
				Phone=employee.Phone,
				Address=employee.Address,
				CreatedAt=DateTime.UtcNow+""


			};

			_employeeDbContext.Employees.Add(newEmployee);
			_employeeDbContext.SaveChanges();
			return newEmployee.Id;

		}
		int Val = 0;
		  public Employee GetEmployeeById(int id)
		{
			
			Employee empData=null;
			var entity= _employeeDbContext.Employees.SingleOrDefault(x => x.Id==id);
			if (entity != null)
			{
				empData=new Employee()
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				Phone = entity.Phone,
				Address = entity.Address,
			};
			}
			Val = empData.Id;
			return empData;
		}
		 public bool UpdateEmployee(Employee emp)
		{
			emp.CreatedAt = DateTime.UtcNow + "";
			

			_employeeDbContext.Entry(_employeeDbContext.Employees.FirstOrDefault(x => x.Id == emp.Id)).CurrentValues.SetValues(emp);
			_employeeDbContext.SaveChanges();
			return true;
		}
		public int DeleteEmp(int employeeId)
		{
			if (employeeId > 0)
			{
				var user = _employeeDbContext.Employees.Find(employeeId);

				_employeeDbContext.Employees.Remove(user);
				_employeeDbContext.SaveChanges();
			
			}
			return employeeId;
		}
	}
}
