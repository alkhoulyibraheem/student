using student.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.Data.Models
{
    public class Stu
    {
        
        public int id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string FattherName { get; set; }
        [Required]

        public string GrandfatherName { get; set; }
        [Required]

        public string FamilyName { get; set; }

        public int IdNumber  { get; set; }

        public Gender Gender { get; set; }

        public String Image { get; set; }

        public String IDImage { get; set; }

        public String Address { get; set; }

        public int Phone { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? JoiningDate { get; set; }

        public Level Level { get; set; }

        public float estimate { get; set; }

        public DateTime? CreateAt { get; set; }

        public bool IsDelete { get; set; }

        public User user { get; set; }






    }
}
