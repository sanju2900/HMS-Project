/*using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week_Project.Models
{
    public class Admin_pg
    {
        // private Microsoft.AspNet.Identity.IUserPasswordStore admin_password;

        [Key]
        public int Admin_Id { get; set; }

        public string Admin_Name { get; set; }
        [Required]
        public string Admin_Email { get; set; }
        [Required]
        public string Admin_password { get; set; }



    }
        
       
    
}
