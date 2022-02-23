using System.Reflection;
using Lesson_attribute;

namespace Lesson_AttributeTest
{
    public class Programm
    {
        private static Assembly textForAttribut;

        public static void Main()
        {
            var attributeForClass = typeof(ForClass).GetCustomAttribute<ThisAttributeForClass>();
            Console.WriteLine(attributeForClass);
            var newClass = new ForClass();
            var textFromAttribute = GetAttribute(typeof(ForClass));
            newClass.WorkInClass(textFromAttribute);
            Console.ReadKey();
        }



        public static string GetAttribute(Type textForAttribut)
        {
            // Get instance of the attribute.
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