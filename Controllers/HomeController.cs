using System;
using Microsoft.AspNetCore.Mvc;
using NetCoreMiddlewareandDI.Models;
using NetCoreMiddlewareandDI.Services;

namespace NetCoreMiddlewareandDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameService _nameService;
        private readonly IGenericService<Person> _personGenericService;
        public HomeController(INameService nameService, IServiceProvider serviceProvider)
        {
            _nameService = nameService;
            _personGenericService = (IGenericService<Person>)serviceProvider.GetService(typeof(IGenericService<Person>));
        }

        public IActionResult Index()
        {
            ViewBag.Name = _nameService.GetName();
            ViewBag.ListCount = 0;
            var addPersonResult = _personGenericService.AddList(new Person
            {
                Name = "Test Name",
                Age = 999
            });
            if (addPersonResult)
                ViewBag.ListCount = _personGenericService.GetListCount();

            return View();
        }
    }
}
