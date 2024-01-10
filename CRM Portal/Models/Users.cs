using CRM_Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Portal.Models
{
    public class Users:IUsers
    {
  

        [Key]
       public int UserID { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       public string CinfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       public DateTime Create_At { get; set; }
        public List<Users> GetAll()
        {
            using(var entity =new CRM_PortalDbContext())
            {
                var log = entity.tblUsers.ToList();
                return log;
            }
        }

    }
}
