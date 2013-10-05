using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace KoMvcRepeatingFieldGroup.Common
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Serializa objeto em notação json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson( this object obj )
        {
            JsonSerializer js = JsonSerializer.Create( new JsonSerializerSettings() );
            var jw = new StringWriter();
            js.Serialize( jw, obj );
            return jw.ToString();
        }


        /// <summary>
        /// Otém propriedades marcadas com atributo "Dynamic".
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> GetDynamicPropertiesNames( this object obj )
        {
            return DynamicPropertiesVisitor.ListProperties( obj.GetType() ).ToList<string>();
        }
    }
}