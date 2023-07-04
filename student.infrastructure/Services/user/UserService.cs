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

namespace student.infrastructure.Services.user
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _IFileService;

        public UserServices(IFileService IFileService , ApplicationDbContext db , IMapper mapper , UserManager<User> userManager)
        {
            _db= db;
            _mapper= mapper;
            _userManager= userManager;
            _IFileService = IFileService;
        }


        public async Task<ResponseDto> GitAll(Pagination pagination, Query query)
        {
            var queryble = _db.Users.Where(x => !x.IsDelete).AsQueryable();
            var count = queryble.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryble.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var user = Mapper.Map<List<userViewModel>>(dataList);
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



        public async Task<string> Create(CreateUserDto dto)
        {
            var isExite = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));
            if (isExite)
            {
                throw new DoublictPhoneOrEmail();
            }
            var user = new User();
            user.Email = dto.Email;

            user.PhoneNumber = dto.PhoneNumber;
            user.FirstName = dto.FirstName;
            user.FattherName = dto.FattherName;
            user.GrandfatherName = dto.GrandfatherName;
            user.FamilyName = dto.FamilyName;
            user.UserType = dto.UserType;
            user.DOB = dto.DOB;
            user.UserName = dto.Email;
            if (dto.Imege != null)
            {
                user.ImageURL = await _IFileService.SaveFile(dto.Imege, "Image");
            }
            var pass = genartPassWord();
            user.CreateAt = DateTime.Now;
            user.studentId = 1;
            
         

            var re = await _userManager.CreateAsync(user, pass);
            if (!re.Succeeded)
            {
                throw new oprationFailedExacption();
            }


            return pass;

        }


        public async Task<string> Ubdate(UpDateUserDto dto)
        {
            var isExite = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (isExite)
            {
                throw new DoublictPhoneOrEmail();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            var upDate = Mapper.Map<UpDateUserDto, User>(dto, user);
            if (dto.Imege != null)
            {
                upDate.ImageURL = await _IFileService.SaveFile(dto.Imege, "Image");
            }
            _db.Users.Update(upDate);
            await _db.SaveChangesAsync();
            return user.Id;
        }


        public async Task<string> Delete(string id)
        {
            var x = await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (x == null)
            {
                throw new EntityNotFoundExecption();
            }
            x.IsDelete = true;
            _db.Users.Update(x);
            _db.SaveChangesAsync();
            return x.Id;
        }

        public async Task<UpDateUserDto> Get(string Id)
        {
            var x = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (x == null)
            {
                throw new EntityNotFoundExecption();
            }
            return Mapper.Map<UpDateUserDto>(x);

        }

        private string genartPassWord()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }

    }
}
