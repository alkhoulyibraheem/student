using Microsoft.AspNetCore.Http;
using student.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.core.ViweModel
{
    public class StudentViewModel
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string FattherName { get; set; }


        public string GrandfatherName { get; set; }


        public String Image { get; set; }


        public string FamilyName { get; set; }

        public int IdNumber { get; set; }

        public Gender Gender { get; set; }

        public String Address { get; set; }

        public int Phone { get; set; }

        public DateTime? DOB { get; set; }

        public Level Level { get; set; }

        public float estimate { get; set; }

    }
}
