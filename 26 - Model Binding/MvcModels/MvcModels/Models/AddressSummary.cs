using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcModels.Models
{
    //[Bind(nameof(Country))]
    public class AddressSummary
    {
        public string City { get; set; }

        //[BindNever]
        public string Country { get; set; }
    }
}
