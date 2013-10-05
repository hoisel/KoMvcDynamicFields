using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KoMvcRepeatingFieldGroup.Common.Attributes;

namespace KoMvcRepeatingFieldGroup.Common
{
    /// <summary>
    /// Obtém o nome das propriedades de um objeto recursivamente
    /// http://stackoverflow.com/questions/4220991/recursively-get-properties-child-properties-of-an-object
    /// </summary>
    public static class DynamicPropertiesVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public static IEnumerable<string> ListProperties( Type baseType, Func<PropertyInfo, bool> filter = null )
        {
            return ListPropertiesInner( baseType, baseType.Name );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="baseName"></param>
        /// <returns></returns>
        private static IEnumerable<string> ListPropertiesInner( Type baseType, string baseName )
        {
            var props = baseType.GetProperties();

            foreach ( var property in props )
            {
                if ( IsDynamic( property ) )
                {
                    yield return string.Format( "{0}.{1}", baseName, property.Name );
                }


                if ( IsMarked( property ) )
                {
                    var name = property.Name;
                    var type = ListArgumentOrSelf( property.PropertyType );

                    foreach ( var info in ListPropertiesInner( type, name ) )
                    {
                        yield return string.Format( "{0}.{1}", baseName, info );
                    }
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static bool IsMarked( PropertyInfo prop )
        {
            return prop.GetCustomAttributes( typeof( ExpandAttribute ), true ).Any();
        }



        static bool IsDynamic( PropertyInfo prop )
        {
            return prop.GetCustomAttributes( typeof( DynamicAttribute ), true ).Any();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ListArgumentOrSelf( Type type )
        {
            if ( !type.IsGenericType )
            {
                return type;
            }

            if ( type.GetGenericTypeDefinition() != typeof( List<> ) )
            {
                throw new Exception( "Only List<T> are allowed" );
            }

            return type.GetGenericArguments()[ 0 ];
        }
    }
}