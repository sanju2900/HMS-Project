using System.ComponentModel.DataAnnotations;

namespace Week_Project.Models
{
    public class Patient
    {
        [Key]
        public int Patient_id { get; set; }

        public string Patient_Name { get; set; }
        
        public DateTime? Patient_DOB { get; set; }
        [Required]
        public string Patient_Gender { get; set; }
        public Int64 Patient_number { get; set; }
        public string Patient_email { get; set; }
        public string Patient_Address { get; set; } 
        public string Patient_Problem { get; set; }

         public DateTime? Todays_date { get; set; }
       

        public ICollection<Admin_pg>Admin_Pgs { get; set; }
    }
}
