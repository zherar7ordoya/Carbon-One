#define DEBUG
#undef RELEASE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;
using System;
using System.Runtime.InteropServices;

// Alias - alias
using AliasDictionary = System.Collections.Generic.Dictionary<string, int>;

namespace SemanticTokenTest
{
    // Enviar un mensaje a la terminal de depuración.
    [Conditional("DEBUG")]
    public static void DebugMessage(string message)
    {
        Debug.WriteLine($"DEBUG: {message}");
    }


    // Decorator - attribute
    [Conditional("DEBUG")]
    class NativeInterop
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Beep(uint frequency, uint duration);

        public static void PlaySound()
        {
            // Hacer sonar un beep (en Windows)
            Beep(1000, 500); // 1000 Hz por 500 ms
        }
    }

    /// <summary>
    /// Esto es un comentario XML para probar <see cref="xmlDocCommentName"/>.
    /// </summary>
    public class Program
    {
        // Campo de clase - field
        private int _counter = 0;

        // Constante - constant
        private const string Greeting = "Hello, world!"; // string

        // Propiedad - property
        public int Counter
        {
            get => _counter;
            set => _counter = value; // parameter 'value'
        }

        // Método - method
        public void Run()
        {
            // Llamada a método externo
            NativeInterop.PlaySound();

            // Variable local - variable
            string message = $"El contador es: {Counter}"; // interpolatedString

            // Número - number
            double pi = 3.14159;
            int hexValue = 0x1A;
            int binaryValue = 0b1010_1010;

            // Operador - operator
            int sum = 5 + 3;

            // Comentario - comment
            // Esto es un comentario de línea

            /* 
             * Esto es un comentario multilínea
             */

            // Enum - enum, enumMember
            LogLevel level = LogLevel.Debug;

            // Switch - controlKeyword
            switch (level)
            {
                case LogLevel.Debug:
                    WriteLine("Debug mode");
                    break;
                default:
                    goto Finish; // label
            }

            // Bucle - controlKeyword
            for (int i = 0; i < 5; i++) // parameter 'i'
            {
                if (i == 3) continue; // controlKeyword
                WriteLine(i);
            }

            // Try-catch - controlKeyword
            try
            {
                int result = 10 / 0;
            }
            catch (DivideByZeroException ex) when (ex.Message != null) // catch filter
            {
                Console.WriteLine("No se puede dividir por cero.");
            }
            finally
            {
                WriteLine("Finalizando...");
            }

            // Lock - controlKeyword
            object lockObj = new();
            lock (lockObj)
            {
                WriteLine("Bloque sincronizado");
            }

            // Using - controlKeyword
            using (var writer = new StringWriter())
            {
                writer.WriteLine("Texto");
            }

            // Llamada a método
            PrintMessage(message);

            // Expresión lambda - function
            Func<int, int> square = x => x * x;

            // Interfaz - interface
            ILogger logger = new ConsoleLogger();

            // Struct - struct
            Point point = new(10, 20);

            // Record struct - recordStruct
            var position = new Position(5, 10);

            // Record class - recordClass
            var user = new User("Alice");

            // Patrón de tipo - controlKeyword
            if (user is User alice)
            {
                WriteLine(alice.Name);
            }

            // Declaración de alias - alias
            AliasDictionary dict = new();
            dict["key"] = 42;

            // Atributo - attribute
            [Conditional("DEBUG")]
            void DebugOnlyMethod()
            {
                WriteLine("Solo en DEBUG");
            }

            // fixed - modifier
            unsafe
            {
                int value = 10;
                fixed (int* ptr = &value)
                {
                    *ptr = 20;
                }
            }

            // stackalloc - modifier
            unsafe
            {
                int* numbers = stackalloc int[5] { 1, 2, 3, 4, 5 };
            }

            // sizeof - keyword
            int size = sizeof(int);

            // typeof - keyword
            Type type = typeof(string);

            // nameof - keyword
            string name = nameof(Counter);

            // checked/unchecked - modifier
            int overflow = checked(int.MaxValue + 1); // throw

            // async/await - modifier
            var result = GetDataAsync().Result;

            // yield - controlKeyword
            foreach (var item in GetSequence())
            {
                WriteLine(item);
            }

            // Regex - regexp
            var match = Regex.Match("abc123", @"\d+");

        // goto - label
        Finish:
            WriteLine("Fin del programa.");
        }

        // Método con parámetro - parameter
        public void PrintMessage(string msg) => WriteLine(msg);

        // Método estático - method
        public static async Task<int> GetDataAsync()
        {
            await Task.Delay(100);
            return 42;
        }

        // Extension method - extensionMethod
        public static class StringExtensions
        {
            public static string ToTitleCase(this string s) =>
                string.IsNullOrEmpty(s) ? s : char.ToUpper(s[0]) + s[1..];
        }

        // Método con yield - yield
        public IEnumerable<int> GetSequence()
        {
            yield return 1;
            yield return 2;
            yield break;
        }
    }

    // Enum - enum
    public enum LogLevel
    {
        Info,
        Warning,
        Debug
    }

    // Interface - interface
    public interface ILogger
    {
        void Log(string message);
    }

    // Struct - struct
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

    // Record struct - recordStruct
    public record struct Position(int X, int Y);

    // Record class - recordClass
    public record User(string Name);

    // Delegate - delegate
    public delegate void NotifyHandler(string message);
}