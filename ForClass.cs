﻿using System.Reflection;
using Lesson_attribute;

namespace Lesson_attribute
{
    [ThisAttributeForClass("SomeText")]
    public class ForClass                                         // Класс для работы с атрибутами
    {
        /* [ThisAttributeForProp]
         public string ForAttributeProp { get; set; }
         [ThisAttributeForMethod]
        */
        public readonly string text;

        public ForClass(string name)
        {
            text = name;
        }
        public void WorkInClass()                  // Метод, в который передаётся значение атрибута
        {
            Console.WriteLine("Выполнена работа классом, в который было передано значение атрибута: {0}", text);
        }

    }

    [AttributeUsage(AttributeTargets.Method)]  //Аттрибут 1 - Для метода
    public class ThisAttributeForMethod : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]   //Аттрибут 2  - Для класса
    public class ThisAttributeForClass : Attribute
    {
        public ThisAttributeForClass(string text)
        {
            textForThisAttribute = text;
        }
        public string textForThisAttribute { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)] //Аттрибут 3 - Для свойства
    public class ThisAttributeForProp : Attribute
    {
    }

}
