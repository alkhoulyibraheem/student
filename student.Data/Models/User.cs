using Microsoft.AspNetCore.Identity;
using student.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.Data.Models
{
    public class User : IdentityUser
    {
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string FattherName { get; set; }
        [Required]

        public string GrandfatherName { get; set; }
        [Required]

        public string FamilyName { get; set; }

        public DateTime? DOB { get; set; }

        

        public String ImageURL { get; set; }


        public UserType UserType { get; set;}

        public bool IsDelete { get; set; }

        public String CreateBy { get; set; }

        public DateTime CreateAt { get; set; }

        public String UpdateBy { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int studentId { get; set; }

        public Stu student { get; set; }
    }
}
