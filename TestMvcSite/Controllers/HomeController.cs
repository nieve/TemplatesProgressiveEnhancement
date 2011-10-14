using System;
using System.Web.Mvc;
using TemplatesProgressiveEnhancement;

namespace TestMvcSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult List()
        {
            var name1 = new FullName{FirstName="Che", LastName="Guevara"};
            var name2 = new FullName{FirstName="Chairman", LastName="Mao"};
            var name3 = new FullName{FirstName="Jean-Luc", LastName="Godard"};
            var names = new []{name1,name2,name3};
            return this.Template("SomeList", names);
        }
    }

    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
