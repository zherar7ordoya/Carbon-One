using System;
using System.Text.RegularExpressions;

namespace TokenTest
{
    // Ejemplo de record struct (recordStruct)
    public record struct Point(int X, int Y);

    // Ejemplo de atributo (decorator)
    [Serializable]
    public class MyClass
    {
        // Modificador (modifier)
        private string _name;

        public MyClass(string name)
        {
            _name = name;
        }

        // Expresión regular (regexp)
        public bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Tipo personalizado (type)
        public Point GetPoint()
        {
            return new Point(10, 20);
        }
    }

    // Otro ejemplo de tipo (type)
    public struct MyStruct
    {
        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass("Test");

            // Uso de expresión regular
            Console.WriteLine(obj.IsValidEmail("test@example.com"));

            // Uso de record struct
            var point = obj.GetPoint();
            Console.WriteLine($"Point: ({point.X}, {point.Y})");
        }
    }
}