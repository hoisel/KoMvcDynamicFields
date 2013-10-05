using System;
using System.Collections.Generic;
using KoMvcDynamicFields.Common;

namespace KoMvcDynamicFields.Models
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