using Microsoft.AspNetCore.Http;
using student.core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.core.Dto
{
    public class UpDateUserDto
    {

        public String Id { get; set; }
        [Required]
        [Display(Name = "الاسم الاول")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "اسم الاب")]

        public string FattherName { get; set; }
        [Required]
        [Display(Name = "اسم الجد")]

        public string GrandfatherName { get; set; }
        [Required]
        [Display(Name = "العائلة")]

        public string FamilyName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "رقم الهاتف")]

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
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
