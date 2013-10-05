using System;
using System.Collections.Generic;
using KoMvcRepeatingFieldGroup.Common;

namespace KoMvcRepeatingFieldGroup.Models
{
    public class BaseViewModel
    {
        public virtual List<String> DynamicProperties
        {
            get
            {
                var propNames = this.GetDynamicPropertiesNames();
                return propNames;
            }
        }
    }
}