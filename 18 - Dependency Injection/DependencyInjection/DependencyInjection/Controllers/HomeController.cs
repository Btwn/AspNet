using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository { get; } = TypeBroker.Repository;

        public ViewResult Index() => View(Repository.Products);
    }
}
