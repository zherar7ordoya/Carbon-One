










// TestTextMate.cs
// 🚀 Explorando al máximo TextMate con C#

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;

// ==== 1. Atributos y Mixins ====
// En C# los decoradores son atributos
[AttributeUsage(AttributeTargets.Method)]
public class LogAttribute : Attribute
{
    public void OnMethodExecuting(string methodName, object[] args)
    {
        Console.WriteLine($"📝 Llamada a {methodName} con {string.Join(", ", args)}");
    }
}

// Ejemplo de mixin con herencia múltiple es limitado en C#,
// pero se puede usar interfaces y composición.

// ==== 2. Namespaces y Módulos ====

namespace Utils
{
    public static class Helpers
    {
        public static bool IsString(object x) => x is string;
        public const double PI = 3.1415;
    }
}

// ==== 3. Clases, Abstractas, Genéricas y Herencia ====

public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public override double Area() => Width * Height;
}

// Timestamped mixin equivalente: herencia con composición
public class TimestampedRectangle : Rectangle
{
    public long Timestamp { get; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    public TimestampedRectangle(double width, double height) : base(width, height) { }
}

// ==== 4. Interfaces, Tipos Genéricos y Restricciones ====

public interface IPoint
{
    double X { get; }
    double Y { get; }
}

// readonly no existe como tal, pero se puede hacer con solo get;
public struct ReadonlyPoint : IPoint
{
    public double X { get; }
    public double Y { get; }
    public ReadonlyPoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}

// Nullable
public class NullableExample<T> where T : class
{
    public T? Value { get; set; }
}

// ==== 5. Enums y Constantes ====

public enum Direction { Up, Down, Left, Right }
public static class Color
{
    public const string Red = "#f00";
    public const string Green = "#0f0";
    public const string Blue = "#00f";
}

// ==== 6. Diccionarios, Tuplas, Uniones e Intersecciones ====

public class Examples
{
    // Record equivalente: Dictionary con keys fijos no es posible, se usa Dictionary<string,int>
    public Dictionary<string, int> StringNumberRecord = new() { ["a"] = 1, ["b"] = 2, ["c"] = 3 };

    // Tuplas con longitud fija y resto variable no es posible, pero sí con ValueTuple:
    public (int, int) PointTuple = (1, 2);

    // Union: C# no tiene directamente, se puede usar herencia o discriminated unions con records (C# 9+)
    public abstract record ShapeUnion;
    public record Circle(double Radius) : ShapeUnion;
    public record Rect(double Width, double Height) : ShapeUnion;

    // Intersection: se puede usar interfaces múltiples o composición
    public interface IId { string Id { get; } }
    public interface IMeta { object Meta { get; } }
    public class IntersectionType : IId, IMeta
    {
        public string Id { get; set; }
        public object Meta { get; set; }
    }
}

// ==== 7. Literales, Interpolación y Regex ====

public class Literals
{
    public int Binary = 0b1010;
    public int Hex = 0xdeadbeef;
    public decimal BigInt = 123m; // No hay BigInt, decimal es cercano

    public string Msg => $"Valor es {Binary} y hex {Hex}";

    public Regex Regex = new(@"^(?<year>\d{4})-(\d{2})-(\d{2})$");
}

// ==== 8. Sobrecarga de Métodos y Lambdas ====

public class Overloads
{
    public string Combine(string a, string b) => a + b;
    public int Combine(int a, int b) => a + b;

    public T[] Arrow<T>(T x) => new T[] { x };
}

// ==== 9. Overrides y Casting ====

public class Base
{
    public override string ToString() => "base";
}

public class Sub : Base
{
    public override string ToString() => "sub";
}

// ==== 10. Comentarios y Regiones ====

public class Magic
{
    #region Código “mágico”
    public static T Magical<T>(T obj) where T : class
    {
        return obj; // Solo para ejemplo
    }
    #endregion
}

// ==== Uso de todo ====

class Program
{
    /// <summary>
    /// Ejemplo de uso de las características de C# y TextMate.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var rect = new TimestampedRectangle(3, 4);

        Console.WriteLine($"Área: {rect.Area()}, Timestamp: {rect.Timestamp}");
        Console.WriteLine(Utils.Helpers.IsString("hola"));

        var overload = new Overloads();

        Console.WriteLine(overload.Combine(5, 10));
        Console.WriteLine(new Literals().Msg);
    }
}
