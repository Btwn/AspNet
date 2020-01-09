using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filters.Infrastructure;
using System;

namespace Filters.Controllers
{
    //[HttpsOnly]
    //[Profile]
    //[ViewResultDetails]
    //[RangeException]
    //[TypeFilter(typeof(DiagnosticsFilter))]
    //[TypeFilter(typeof(TimeFilter))]
    //[ServiceFilter(typeof(TimeFilter))]
    [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]
        public IActionResult Index() => View("Message", "This is the Index action on the Home controller");

        public IActionResult SecondAction() => View("Message", "This is the SecondAction action on the Home controller");

        public ViewResult GenerateException(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if(id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message",$"The value is {id}");
            }
        }
    } 
}
