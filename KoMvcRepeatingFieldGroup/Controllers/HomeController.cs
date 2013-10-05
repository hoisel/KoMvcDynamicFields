using System.Web.Http;

namespace KoMvcRepeatingFieldGroup.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using KoMvcRepeatingFieldGroup.Models;



    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Pessoa = new HomeViewModel.PessoaVM()
                {
                    Nome = "Edgar",
                    Idade = 27,
                    Empregos = new List<HomeViewModel.EmpregoVM>{
                            new HomeViewModel.EmpregoVM { Empresa = "Prodest", Cargo = "Analista" },
                            new HomeViewModel.EmpregoVM { Empresa = "Sefaz", Cargo = "Analista" }, 
                            new HomeViewModel.EmpregoVM { Empresa = "Sejus", Cargo = "Analista" } ,
                            new HomeViewModel.EmpregoVM { Empresa = "Secom", Cargo = "Analista" }
                        },
                    Cursos = new List<HomeViewModel.CursoVM> { 
                        new HomeViewModel.CursoVM {Id=1, Local="Mindworks",Nome="Knockoutjs em 24hrs" },
                        new HomeViewModel.CursoVM {Id=2, Local="UFES",Nome="EF4 avançado" },
                        new HomeViewModel.CursoVM {Id=3, Local="Sebrae",Nome="MVC pipeline" },
                    },
                    Apelidos = new List<string> { "Ed","ed2","ed3","ed4"}
                }
            };
            return this.View( viewModel );
        }



        [HttpPost]
        public ActionResult Index( HomeViewModel newModel )
        {
            // coloque um break point aqui pra ver se o viewmodel foi submetido com sucesso

            return RedirectToAction( "Index" );
        }
    }
}
