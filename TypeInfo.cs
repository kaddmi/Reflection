using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Reflection
{
    public class TypeInfo
    {
        private Type type;
        public TypeInfo(Type type)
        {
            this.type = type;
        }
        
        public IEnumerable<CustomAttributeData> Attributes => type.CustomAttributes;
        public IEnumerable<FieldInfo> Fields => type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        public IEnumerable<MethodInfo> Methods => type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(mi => !mi.IsSpecialName);
        public IEnumerable<ConstructorInfo> Constructors => type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        public IEnumerable<PropertyInfo> Properties => type.GetProperties(BindingFlags.Public | BindingFlags.Instance);


        public void ShowTypeInfo ()
        {
            Console.WriteLine("Type info about {0}", this.type.Name);
            Console.WriteLine("Attributes");
            foreach (var atr in this.Attributes)
            {
                Console.WriteLine("  " + atr.AttributeType);
            }
            Console.WriteLine("Fields");
            foreach (var fieldInfo in this.Fields)
            {
                Console.WriteLine("   {0}: {1}", fieldInfo.Name, fieldInfo.FieldType);
            }
            Console.WriteLine("Properties");
            foreach (var prop in this.Properties)
            {
                Console.WriteLine("   {0} ({1})", prop.Name, prop.PropertyType.Name);
            }
            Console.WriteLine("Constructors");
            foreach (var constr in this.Constructors)
            {
                Console.WriteLine("   Constructors: " + constr.ToString());
            }
            Console.WriteLine("Methods");
            foreach (var meth in this.Methods)
            {
                Console.WriteLine("   name - " + meth.Name + "; return value - " + meth.ReturnType);
            }
        }

    }
}