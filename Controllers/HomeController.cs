using Microsoft.AspNetCore.Mvc;
using Web_Datenbank1_LK.BL;



namespace Web_Datenbank1_LK.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService personService;

        public HomeController(IPersonService personService)
        {
            this.personService = personService;
        }

        public IActionResult Index()
        {
            var allPersons = personService.ReadAllPerson();
            return View(allPersons);
        }
    }
}
