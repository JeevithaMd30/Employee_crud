using CRUD_with_SP.IServices;
using CRUD_with_SP.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CRUD_with_SP.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public EmployeeService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }


        public List<EmpModel> GetAllEmployees()
        {

            // [HttpGet("GetAllEmployees")]

            List<EmpModel> employeeList = new List<EmpModel>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("Get_employees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EmpModel employee = new EmpModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Dob = Convert.ToDateTime(reader["Dob"]),
                            country = reader["country"].ToString(),
                            Salary = Convert.ToInt32(reader["Salary"]),
                            D_id = Convert.ToInt32(reader["D_Id"]),
                            Isactive = Convert.ToBoolean(reader["Isactive"])

                        };

                        employeeList.Add(employee);
                    }

                    connection.Close();

                }
            }

            return employeeList;
        }
        
        
        public void AddEmployeeData(EmpModel employee)
        {

                EmpInsertModel emp = new EmpInsertModel();
               
                
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {

                        using (SqlCommand command = new SqlCommand("Insert_emp", connection))
                        {

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@name", employee.Name);
                            command.Parameters.AddWithValue("@email", employee.Email);
                            command.Parameters.AddWithValue("@Dob", employee.Dob);
                            command.Parameters.AddWithValue("@country", employee.country);
                            command.Parameters.AddWithValue("@salary", employee.Salary);
                            command.Parameters.AddWithValue("@d_id",employee.D_id);
                            command.Parameters.AddWithValue("@created_on", DateTime.Now);
                            command.Parameters.AddWithValue("@created_by", 1);
                            command.Parameters.AddWithValue("@Isactive", true);

                            connection.Open();
                            command.ExecuteNonQuery();

                            connection.Close();


                        }
                    }


        }

        /// Delete employee

            public void DeleteEmployee(int id)
            {
                
                
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.OpenAsync();
                        using (SqlCommand command = new SqlCommand("DELETE_emp", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int);
                            parameter.Value = id;
                            command.Parameters.Add(parameter);

                            int rowsAffected = command.ExecuteNonQuery();


                         connection.Close();
                        }

                    }
                
            }



        public EmpModel GetEmpById(int id)
            {
                EmpModel emp = new EmpModel();

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("Get_Emp_ById", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Id", id);

                            connection.Open();
                            SqlDataReader reader =  command.ExecuteReader();

                            if (reader.Read())
                            {

                                emp.Id = Convert.ToInt32(reader["Id"]);
                                Console.WriteLine("emp.Id={0}", emp.Id);

                                emp.Name = reader["Name"].ToString();
                                emp.Email = reader["Email"].ToString();
                                emp.Dob = Convert.ToDateTime(reader["Dob"]);
                                emp.country = reader["country"].ToString();
                                emp.Salary = Convert.ToInt32(reader["Salary"]);
                                emp.Isactive = Convert.ToBoolean(reader["Isactive"]);
                                emp.created_on = Convert.ToDateTime(reader["created_on"]);

                                connection.Close();

                            }

                        }
                        return emp;
                    }

            }

        //update employee
        public EmpModel UpdateEmployee(EmpModel emp1)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update_Employee", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", emp1.Id);
                    command.Parameters.AddWithValue("@Name", emp1.Name);
                    command.Parameters.AddWithValue("@email", emp1.Email);
                    command.Parameters.AddWithValue("@Dob", emp1.Dob);
                    command.Parameters.AddWithValue("@country", emp1.country);
                    command.Parameters.AddWithValue("@salary", emp1.Salary);
                    command.Parameters.AddWithValue("@D_id", emp1.D_id);
                    //command.Parameters.AddWithValue("@updated_on", DateTime.Now);
                    //command.Parameters.AddWithValue("@updated_by", "sushanth");


                    command.ExecuteNonQuery();
                }
                
                connection.Close();
                return emp1;
            }
           
        }

            public EmpModel EditPage(int id)
            {
                EmpModel emp = new EmpModel();


                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Get_Emp_ById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            emp.Id = Convert.ToInt32(reader["Id"]);
                            Console.WriteLine("emp.Id={0}", emp.Id);

                            emp.Name = reader["Name"].ToString();
                            emp.Email = reader["Email"].ToString();
                            emp.Dob = Convert.ToDateTime(reader["Dob"]);
                            emp.country = reader["country"].ToString();
                            emp.Salary = Convert.ToInt32(reader["Salary"]);
                            emp.Isactive = Convert.ToBoolean(reader["Isactive"]);
                            emp.created_on = Convert.ToDateTime(reader["created_on"]);

                            connection.Close();

                        }

                    }

                }

                return emp;
            }

        
    }       
    
}

