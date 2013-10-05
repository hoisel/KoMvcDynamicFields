using System.Collections.Generic;
using KoMvcDynamicFields.Common.Attributes;

namespace KoMvcDynamicFields.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public JobVM NewJob
        {
            get { return new JobVM(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public CourseVM NewCourse
        {
            get { return new CourseVM(); }
        }


        [Expand]
        public PersonVM Person { get; set; }



        /************* Inner classes **************/

        /// <summary>
        /// 
        /// </summary>
        public class PersonVM
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public PersonVM()
            {
                this.Jobs = new List<JobVM>();
                this.Courses = new List<CourseVM>();
                this.Nicknames = new List<string>();
            }


            [Dynamic]
            public List<JobVM> Jobs { get; set; }

            [Dynamic]
            public List<CourseVM> Courses { get; set; }

            [Dynamic]
            public List<string> Nicknames { get; set; }
        }



        /// <summary>
        /// Sem id
        /// </summary>
        public class JobVM
        {
            public string Company { get; set; }

            public string Job { get; set; }
        }


        /// <summary>
        ///  Com id
        /// </summary>
        public class CourseVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Local { get; set; }
        }
    }
}