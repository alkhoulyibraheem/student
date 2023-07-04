using Microsoft.AspNetCore.Mvc;
using student.core.Constent;
using student.core.Dto;
using student.infrastructure.Services.user;
using System.Threading.Tasks;

namespace student.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _IUserServices;

        public UserController(IUserServices IUserServices)
        {
            _IUserServices = IUserServices;
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
            var result = await _IUserServices.GitAll(pagination, query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
               await _IUserServices.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpDate(string Id)
        {
            var user = await _IUserServices.Get(Id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpDate([FromForm] UpDateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IUserServices.Ubdate(dto);
                return Ok(Results.EditSuccessResult());
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _IUserServices.Delete(Id);
            return Ok(Results.DeleteSuccessResult());
        }
    }
}
