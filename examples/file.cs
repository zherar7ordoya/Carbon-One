#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AliasDictionary = System.Collections.Generic.Dictionary<string, int>;
using static System.Console;


namespace MegaNamespace
{
    public interface IVolatile
    {
        event Action<string>? OnNotify;
    }

    public readonly struct ImmutableData<T> where T : unmanaged
    {
        public readonly T Value;
        public ImmutableData(T value) => Value = value;
    }

    public delegate TResult MagicFunc<in T, out TResult>(T input);

    public static class UnsafeUtilities
    {
        [DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string lpOutputString);

        public static unsafe void ModifyBuffer(byte* buffer, int length)
        {
            for (int i = 0; i < length; i++)
                buffer[i] = (byte)(buffer[i] ^ 0xFF);
        }
    }

    public class Hyper<T> where T : class, IVolatile, new()
    {
        public event EventHandler? SomethingHappened;
        public T Instance { get; } = new();
        public string this[int index] => $"[{index}]";

        public void Trigger() => SomethingHappened?.Invoke(this, EventArgs.Empty);
    }

    public record struct Position(int X, int Y);

    public record Planet(string Name, double Mass);

    public class EverythingEverywhere
    {
        private readonly List<Planet> _planets = new() { new("Alderaan", 1.0e24), new("Mustafar", 2.0e24) };
        private const string Banner = "🧠 C# al infinito y más allá";

        public dynamic RunAll()
        {
            WriteLine(Banner);

            (int x, int y) = (42, 99);
            var p = new Position(x, y);
            object boxed = p;
            if (boxed is Position { X: var px, Y: var py })
                WriteLine($"Match: {px}, {py}");

            AliasDictionary counts = new() { ["code"] = 10, ["lines"] = 999 };
            var total = counts.Values.Sum();

            var task = Task.Run(async () =>
            {
                await Task.Delay(100);
                WriteLine("🌠 Async done.");
            });

            using var enumerator = _planets.GetEnumerator();
            while (enumerator.MoveNext())
                WriteLine(enumerator.Current.Name);

            Expression<Func<int, int>> square = n => n * n;
            var compiled = square.Compile();
            WriteLine($"Square(9) = {compiled(9)}");

            return new { total, position = p };
        }

        public void UseUnsafeStuff()
        {
            unsafe
            {
                byte* buffer = stackalloc byte[10];
                for (int i = 0; i < 10; i++) buffer[i] = (byte)i;
                UnsafeUtilities.ModifyBuffer(buffer, 10);
                for (int i = 0; i < 10; i++) Write($"{buffer[i]} ");
                WriteLine();
            }
        }

        public void UseArglist()
        {
            var typedRef = __makeref(this);
            var type = __reftype(typedRef);
            WriteLine($"Type: {type}");
        }
    }

    interface ILogger
    {
        void Log(string message) => WriteLine(message);
    }

    /// <summary>
    /// Entry point for the application.
    /// </summary>
    public static class EntryPoint : ILogger
    {
        public static void Main(string[] args)
        {
            var engine = new EverythingEverywhere();
            engine.RunAll();
            engine.UseUnsafeStuff();
            engine.UseArglist();

            global::System.Console.WriteLine("🌌 Fin del viaje galáctico");
        }
    }
}
