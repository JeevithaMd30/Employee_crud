using CRUD_with_SP.Models;

namespace CRUD_with_SP.IServices
{
    public interface IEmployeeServices
    {
        // by creating interface we can acccess the methods anywhere in the project
         List<EmpModel> GetAllEmployees();


        // public Task GetEmpBy(int id);
         EmpModel GetEmpById(int id);

         void AddEmployeeData(EmpModel employee);

         EmpModel UpdateEmployee(EmpModel emp1);

       //EmpModel EditPage(int id);

        void DeleteEmployee(int id);  
        
    }
}
