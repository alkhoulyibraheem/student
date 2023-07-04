using student.core.Dto;
using student.core.ViweModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.infrastructure.Services.student
{
     public interface IStudentServices
    {
        Task<ResponseDto> GitAll(Pagination pagination, Query query);
        Task<int> Create(CreateStudentDto dto);
        Task<int> Ubdate(UpDateStudentDto dto);
        Task<int> Delete(int id);
        Task<UpDateStudentDto> Get(int Id);
        Task<StudentViewModel> getViewModel(int id);

    }
}
