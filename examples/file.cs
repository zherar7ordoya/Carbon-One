global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Text.RegularExpressions;
global using static System.Math;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SysAlias = System;

/// <summary>
/// Comprehensive semantic highlighting test class.
/// Tests types, keywords, constructs, APIs, unsafe, dynamic, lambdas, generics, interpolated strings, pattern matching, and more.
/// </summary>
public sealed partial class ColorizationShowcase<T> : ITestable, IDisposable where T : struct
{
    // Fields
    private readonly string _name;
    private int _counter = 0;
    private const int MaxCount = 100;
    private static readonly Regex _regex = new(@"^\d{2,3}$");

    // Events & Delegates
    public delegate TResult Transformer<TInput, TResult>(TInput input);
    public event Action<string>? OnNotify;

    // Required Property (init-only)
    public required string Description { get; init; }

    // Indexer
    public int this[int index] => _data[index];

    // Unsafe buffer
    private unsafe fixed int _unsafeBuffer[10];

    // Static constructor
    static ColorizationShowcase() => Console.WriteLine("Static initialized");

    // Constructor
    public ColorizationShowcase(string name) => _name = name;

    // Generic method with dynamic and nullable
    public TResult? Process<TResult>(dynamic input, Func<dynamic, TResult> processor) where TResult : class
    {
        if (input is null) return null;
        return processor(input);
    }

    // Yield return + switch + pattern matching
    public IEnumerable<string> Describe(object? item)
    {
        switch (item)
        {
            case int i when i > 0: yield return $"Positive integer: {i}"; break;
            case string s: yield return $"String of length {s.Length}"; break;
            case null: yield return "Null value"; break;
            default: yield return $"Unknown type: {item?.GetType().Name}"; break;
        }
    }

    // Using regex, exception filters and unsafe code
    public unsafe void RunDemo()
    {
        Span<byte> span = stackalloc byte[10];
        for (int i = 0; i < span.Length; i++) span[i] = (byte)(i * 2);

        try
        {
            if (_regex.IsMatch("123"))
            {
                OnNotify?.Invoke($"Regex matched at {DateTime.Now:HH:mm}");
            }
        }
        catch (ArgumentException ex) when (ex.Message.Contains("regex"))
        {
            Console.WriteLine($"Regex error: {ex.Message}");
        }

        fixed (int* p = _unsafeBuffer)
        {
            for (int i = 0; i < 10; i++) p[i] = i * i;
        }

        Console.WriteLine($"Counter: {_counter++}");
    }

    // Lambda expression and LINQ
    public List<string> TransformList(List<int> input)
        => input.Where(x => x % 2 == 0).Select(x => $"Even: {x}").ToList();

    // Interpolated strings and null-coalescing
    public string Format(string? msg) => $"[{_name.ToUpper()}] {msg ?? "<no message>"}";

    // Dispose pattern
    public void Dispose() => GC.SuppressFinalize(this);
}

// Record types (mutable & immutable)
public readonly record struct Point(int X, int Y);
public record class Person(string Name, int Age);

// Interface
public interface ITestable
{
    void RunDemo();
}

// Enum + Flags
[Flags]
public enum FileAccess
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    All = Read | Write | Execute
}

// Top-level statement simulation
internal static class EntryPoint
{
    public static void Main()
    {
        var tester = new ColorizationShowcase<Point>("Test")
        {
            Description = "Full semantic colorization test"
        };

        tester.OnNotify += msg => Console.WriteLine(msg);
        tester.RunDemo();

        foreach (var info in tester.Describe(42))
        {
            Console.WriteLine(info);
        }

        var result = tester.Process("data", d => d.ToUpperInvariant());
        Console.WriteLine($"Processed: {result}");

        var evens = tester.TransformList(new() { 1, 2, 3, 4, 5, 6 });
        evens.ForEach(Console.WriteLine);

        tester.Dispose();
    }
}
