using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
using System.Linq;
using System.Collections.Generic;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        //public ViewResult Index() => View(repository);

        public IActionResult Index([FromQuery] int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
            //View(repository[id] ?? repository.People.First());
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        public ViewResult DisplaySummary(
            //[Bind(Prefix =nameof(Person.HomeAdress))] AddressSummary summary) => 
            [Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAdress))] AddressSummary summary ) =>
            View(summary);

        //public ViewResult Names(string[] names) => View(names ?? new string[0]);
        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) => View(addresses ?? new List<AddressSummary>());

        //public string Header([FromHeader] string accept) => $"Header: {accept}";
        //public string Header([FromHeader(Name = "Accept-Language")] string accept) => $"Header: {accept}";
        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Person Body([FromBody] Person model) => model;
    }
}
