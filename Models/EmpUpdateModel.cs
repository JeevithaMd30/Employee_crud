namespace CRUD_with_SP.Models
{
    public class EmpUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Dob { get; set; }
        public string country { get; set; } 

        public double Salary { get; set; }

        public bool  Isactive {  get; set; }    
      
        // public DateTime updated_on { get; set; }

       // public string updated_by { get; set; }

    }
}
