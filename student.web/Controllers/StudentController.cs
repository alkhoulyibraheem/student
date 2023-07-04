using Microsoft.AspNetCore.Mvc;
using student.core.Constent;
using student.core.Dto;
using student.infrastructure.Services.student;
using student.infrastructure.Services.user;
using System.Threading.Tasks;

namespace student.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _IStudentServices;

        public StudentController(IStudentServices IStudentServices)
        {
            _IStudentServices = IStudentServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<JsonResult> GetUserData(Pagination pagination, Query query)
        {
            var result = await _IStudentServices.GitAll(pagination, query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateStudentDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IStudentServices.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            return View(dto);
        }




        [HttpGet]
        public async Task<IActionResult> UpDate(int Id)
        {
            var user = await _IStudentServices.Get(Id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpDate([FromForm] UpDateStudentDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IStudentServices.Ubdate(dto);
                return Ok(Results.EditSuccessResult());
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var user = await _IStudentServices.Delete(Id);
            return Ok(Results.DeleteSuccessResult());
        }


        [HttpGet]
        public async Task<IActionResult> ProFile(int Id)
        {
            var user = await _IStudentServices.getViewModel(Id);
            return View(user);
        }

        

    }
}
