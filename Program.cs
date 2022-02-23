using System.Reflection;
using Lesson_attribute;

namespace Lesson_AttributeTest
{
    public class Programm
    {
        private static Assembly textForAttribut;

        public static void Main()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var enumType =types.FirstOrDefault(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ThisAttributeForClass))); //Поиск необходимого класса 

            var attributeForClass = enumType.GetCustomAttributes<ThisAttributeForClass>();                     
            Console.WriteLine(attributeForClass);
            var newClass = new ForClass();
            var textFromAttribute = GetAttribute(typeof(ForClass));
            newClass.WorkInClass(textFromAttribute);  // Передача найденного значения атрибута в метод
            Console.ReadKey();
        }



        public static string GetAttribute(Type textForAttribut) // Поиск значения атрибута 
        {
            ThisAttributeForClass MyAttribute =
                (ThisAttributeForClass)Attribute.GetCustomAttribute(textForAttribut, typeof(ThisAttributeForClass));

            if (MyAttribute == null)
            {
                Console.WriteLine("Атрибут не найден, либо нет значения в атрибуте");
                return MyAttribute.textForThisAttribute = "Null";
            }
            else
            {
                return MyAttribute.textForThisAttribute;

            }
        }
    }

}