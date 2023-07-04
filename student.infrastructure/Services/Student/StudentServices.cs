using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using student.core.Dto;
using student.core.exceptions;
using student.core.ViweModel;
using student.Data;
using student.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.infrastructure.Services.student
{
    public class StudentServices : IStudentServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _IFileService;

        public StudentServices(IFileService IFileService , ApplicationDbContext db , IMapper mapper , UserManager<User> userManager)
        {
            _db= db;
            _mapper= mapper;
            _userManager= userManager;
            _IFileService = IFileService;
        }


        public async Task<ResponseDto> GitAll(Pagination pagination, Query query)
        {
            var queryble = _db.Students.Where(x => !x.IsDelete).AsQueryable();
            var count = queryble.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryble.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            List<StudentViewModel> user = new List<StudentViewModel>();
            foreach (var item in dataList)
            {
                var x = new StudentViewModel();
                x.id = item.id;
                x.FirstName= item.FirstName;
                x.Address= item.Address;
                x.Phone = item.Phone;
                x.estimate = item.estimate;
                x.DOB = item.DOB;
                x.Level= item.Level;
                x.IdNumber = item.IdNumber;
                x.FattherName = item.FattherName;
                x.GrandfatherName = item.GrandfatherName;
                x.FamilyName = item.FamilyName;
                x.Gender = item.Gender;
                user.Add(x);

            }
            var pages = pagination.GetPages(count);
            var re = new ResponseDto
            {
                data = user,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pagination.Pages,
                    total = pagination.Total
                }
            };
            return re;
        }



        public async Task<int> Create(CreateStudentDto dto)
        {
            var isExite = _db.Students.Any(x => !x.IsDelete && x.IdNumber==dto.IdNumber);
            if (isExite)
            {
                throw new DoublictPhoneOrEmail();
            }
            var user = new Stu();
            user.FirstName= dto.FirstName;
            user.FattherName = dto.FattherName;
            user.GrandfatherName = dto.GrandfatherName;
            user.FamilyName = dto.FamilyName;
            user.DOB = dto.DOB;
            user.IdNumber = dto.IdNumber;
            user.Phone= dto.Phone;
            user.Level= dto.Level;
            user.estimate = dto.estimate;
            user.JoiningDate = dto.JoiningDate;
            user.Gender = dto.Gender;
            user.Address = dto.Address;
            user.CreateAt = DateTime.Now;
            if (dto.IDImage != null)
            {
                user.IDImage = await _IFileService.SaveFile(dto.IDImage, "Image");
            }

            if (dto.Image != null)
            {
                user.Image = await _IFileService.SaveFile(dto.Image, "Image");
            }


            _db.Students.Add(user);
            await _db.SaveChangesAsync();
            return user.id;

        }


        public async Task<int> Ubdate(UpDateStudentDto dto)
        {
            var isExite = _db.Students.Any(x => !x.IsDelete && x.IdNumber == dto.IdNumber &&x.id != dto.id);
            if (isExite)
            {
                throw new DoublictPhoneOrEmail();
            }
            var user = await _db.Students.SingleOrDefaultAsync(x => x.id == dto.id);
            user.FirstName = dto.FirstName;
            user.FattherName = dto.FattherName;
            user.GrandfatherName = dto.GrandfatherName;
            user.FamilyName = dto.FamilyName;
            user.DOB = dto.DOB;
            user.IdNumber = dto.IdNumber;
            user.Phone = dto.Phone;
            user.Level = dto.Level;
            user.estimate = dto.estimate;
            user.JoiningDate = dto.JoiningDate;
            user.Gender = dto.Gender;
            user.Address = dto.Address;
            user.CreateAt = DateTime.Now;

            if (dto.IDImage != null)
            {
                user.IDImage = await _IFileService.SaveFile(dto.IDImage, "Image");
            }

            if (dto.Image != null)
            {
                user.Image = await _IFileService.SaveFile(dto.Image, "Image");
            }

            _db.Students.Update(user);
            await _db.SaveChangesAsync();
            return user.id;
        }


        public async Task<int> Delete(int id)
        {
            var x = await _db.Students.SingleOrDefaultAsync(x => x.id == id && !x.IsDelete);
            if (x == null)
            {
                throw new EntityNotFoundExecption();
            }
            x.IsDelete = true;
            _db.Students.Update(x);
            await _db.SaveChangesAsync();
            return x.id;
        }

        public async Task<UpDateStudentDto> Get(int Id)
        {
            var x = await _db.Students.SingleOrDefaultAsync(x => x.id == Id && !x.IsDelete);
            if (x == null)
            {
                throw new EntityNotFoundExecption();
            }
            var user = new UpDateStudentDto();
            user.id = x.id;
            user.FirstName = x.FirstName;
            user.FattherName = x.FattherName;
            user.GrandfatherName = x.GrandfatherName;
            user.FamilyName = x.FamilyName;
            user.DOB = x.DOB;
            user.IdNumber = x.IdNumber;
            user.Phone = x.Phone;
            user.Level = x.Level;
            user.estimate = x.estimate;
            user.JoiningDate = x.JoiningDate;
            user.Gender = x.Gender;
            user.Address = x.Address;
           
            return user;

        }


        public async Task<StudentViewModel> getViewModel(int id)
        {
            var x = await _db.Students.SingleOrDefaultAsync(x => !x.IsDelete && x.id == id);

            if(x == null)
            {
                throw new EntityNotFoundExecption();
            }
            var user = new StudentViewModel();
            user.id = x.id;
            user.FirstName = x.FirstName;
            user.Address = x.Address;
            user.Phone = x.Phone;
            user.Level = x.Level;
            user.estimate = x.estimate;
            user.DOB = x.DOB;
            user.IdNumber = x.IdNumber;
            user.FattherName= x.FattherName;
            user.GrandfatherName = x.GrandfatherName;
            user.FamilyName= x.FamilyName;
            user.Gender = x.Gender;
            user.Image= x.Image;

            return user;

        }

    }
}
