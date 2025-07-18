using System;
using System.Collections.Generic;
using MyApp.Utilities; // namespace externo ficticio

namespace MyApp
{
    public interface IService
    {
        void Execute();
    }

    public abstract class BaseService : IService
    {
        public abstract void Execute();
    }

    public class MyService<T> : BaseService where T : class, new()
    {
        // Campo privado
        private readonly string _internalName;

        // Propiedad pública
        public int Counter { get; set; }

        // Constante
        private const double Pi = 3.14159;

        // Evento
        public event Action<string>? OnProcessed;

        // Constructor
        public MyService(string name)
        {
            _internalName = name;
            Counter = 0;
        }

        // Método override
        public override void Execute()
        {
            Counter++;
            Log<T>(_internalName);
            OnProcessed?.Invoke(_internalName);
        }

        // Método genérico con parámetro
        private void Log<U>(U item) where U : notnull
        {
            Console.WriteLine($"Processed: {item}");
        }

        // Método estático
        public static MyStruct DoStaticWork(MyEnum option)
        {
            return new MyStruct { Value = (int)option };
        }
    }

    // Estructura
    public struct MyStruct
    {
        public int Value;
    }

    // Enumeración
    public enum MyEnum
    {
        Low,
        Medium,
        High
    }
}
