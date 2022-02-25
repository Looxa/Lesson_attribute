using System.Reflection;
using Lesson_attribute;

namespace Lesson_AttributeTest
{
    public class Programm
    {
        public static void Main()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var enumType = types.FirstOrDefault(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ThisAttributeForClass))); //Поиск необходимого класса 

            var attributeForClass = enumType.GetCustomAttributes<ThisAttributeForClass>();
            Console.WriteLine(attributeForClass);
            var textFromAttribute = GetAttribute(typeof(ForClass)); //Передача текста в переменную

            Type thisClass = typeof(ForClass);  // Cоздание класса с помощью рефлексии
            Type[] parameters = new Type[] { typeof(string) };
            object[] values = new object[] { textFromAttribute };
            object obj = CreateClass(thisClass, parameters, values);
            ((ForClass)obj).WorkInClass();


            /*
             var newClass = new ForClass();

             newClass.WorkInClass(textFromAttribute);  // Передача найденного значения атрибута в метод 
            */
            Console.ReadKey();
        }

        static object CreateClass(Type thisType, Type[] parameters, object[] values)
        {
            ConstructorInfo info = thisType.GetConstructor(parameters);
            object thisObj = info.Invoke(values);
            return thisObj;
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