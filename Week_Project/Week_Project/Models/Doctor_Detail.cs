using System.ComponentModel.DataAnnotations;


namespace Week_Project.Models
{
    public class Doctor_Detail
    {
        [Key]
        public string Dr_id { get; set; }
        public string Dr_name { get; set; }
        /*[Required]
        [StringLength(50)]
        [DataType(DataType.Password)]*/
        public string Dr_pofile { get; set; }
        [Required]
        public Int64 Dr_Number { get; set; }
        
        public string begin_time { get; set; }
        public string end_time { get; set; }
        public ICollection<Admin_pg> Admin_pgs { get; set; }
    }
}

