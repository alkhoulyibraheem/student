using student.core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.infrastructure.Services.user
{
     public interface IUserServices
    {
        Task<ResponseDto> GitAll(Pagination pagination, Query query);
        Task<string> Create(CreateUserDto dto);
        Task<string> Ubdate(UpDateUserDto dto);
        Task<string> Delete(string id);
        Task<UpDateUserDto> Get(string Id);

    }
}
