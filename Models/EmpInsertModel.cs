namespace CRUD_with_SP.Models
{
    public class EmpInsertModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Dob { get; set; }

        public string country { get; set; }

        public int Salary { get; set; }

        public int D_id { get; set; }

        public bool Isactive { get; set; }

        public DateTime created_on { get; set; }
        public string created_by { get; set; }

       
    }
}
