using System.Collections.Generic;
using System.Web.Mvc;
using KoMvcDynamicFields.Models;

namespace KoMvcDynamicFields.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Person = new HomeViewModel.PersonVM()
                {
                    Name = "Edgar",
                    Age = 27,
                    Jobs = new List<HomeViewModel.JobVM>{
                            new HomeViewModel.JobVM { Company = "Prodest", Job = "Analista" },
                            new HomeViewModel.JobVM { Company = "Sefaz", Job = "Analista" }, 
                            new HomeViewModel.JobVM { Company = "Sejus", Job = "Analista" } ,
                            new HomeViewModel.JobVM { Company = "Secom", Job = "Analista" }
                        },
                    Courses = new List<HomeViewModel.CourseVM> { 
                        new HomeViewModel.CourseVM {Id=1, Local="Mindworks",Name="Knockoutjs em 24hrs" },
                        new HomeViewModel.CourseVM {Id=2, Local="UFES",Name="EF4 avançado" },
                        new HomeViewModel.CourseVM {Id=3, Local="Sebrae",Name="MVC pipeline" },
                    },

                    Houses = new List<HomeViewModel.HouseVM> { 
                        new HomeViewModel.HouseVM{Address="Rua odette de oliveira, 234", City="Vitória" },
                        new HomeViewModel.HouseVM{Address="Rua do canal, 45", City="Ilhéus" },
                        new HomeViewModel.HouseVM{Address="Rua 6, casa 23", City="Serra" },
                    },
                    Nicknames = new List<string> { "Ed", "ed2", "ed3", "ed4" }
                }
            };
            return this.View(viewModel);
        }



        [HttpPost]
        public ActionResult Index(HomeViewModel newModel)
        {
            // coloque um break point aqui pra ver se o viewmodel foi submetido com sucesso

            return RedirectToAction("Index");
        }
    }
}
