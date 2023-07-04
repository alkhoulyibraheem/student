using Microsoft.AspNetCore.Http;
using student.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace student.core.ViweModel
{
    public class userViewModel
    {
        public String Id { get; set; }
        [Display(Name = "الاسم الاول")]

        public string FirstName { get; set; }
        [Display(Name = "اسم الاب")]

        public string FattherName { get; set; }
        [Display(Name = "اسم الجد")]

        public string GrandfatherName { get; set; }
        [Display(Name = "العائلة")]

        public string FamilyName { get; set; }
        [Display(Name = "رقم الهاتف")]

        public string PhoneNumber { get; set; }
        [Display(Name = "البريد الالكتروني")]

        public string Email { get; set; }

        [Display(Name = "الصورة")]

        public IFormFile Imege { get; set; }
        [Display(Name = "تاريخ الميلاد")]

        public DateTime? DOB { get; set; }
        [Display(Name = "نوع المستخدم")]

        public UserType UserType { get; set; }
    }
}
