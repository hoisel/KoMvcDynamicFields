using System.Collections.Generic;
using KoMvcRepeatingFieldGroup.Common.Attributes;

namespace KoMvcRepeatingFieldGroup.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public EmpregoVM NovoEmprego
        {
            get { return new EmpregoVM(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public CursoVM NovoCurso
        {
            get { return new CursoVM(); }
        }


        [Expand]
        public PessoaVM Pessoa { get; set; }



        /************* Inner classes **************/

        /// <summary>
        /// 
        /// </summary>
        public class PessoaVM
        {
            public string Nome { get; set; }
            public int Idade { get; set; }

            public PessoaVM()
            {
                this.Empregos = new List<EmpregoVM>();
                this.Cursos = new List<CursoVM>();
                this.Apelidos = new List<string>();
            }


            [Dynamic]
            public List<EmpregoVM> Empregos { get; set; }

            [Dynamic]
            public List<CursoVM> Cursos { get; set; }

            [Dynamic]
            public List<string> Apelidos { get; set; }
        }



        /// <summary>
        /// Sem id
        /// </summary>
        public class EmpregoVM
        {
            public string Empresa { get; set; }

            public string Cargo { get; set; }
        }


        /// <summary>
        ///  Com id
        /// </summary>
        public class CursoVM
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Local { get; set; }
        }
    }
}