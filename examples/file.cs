










namespace EmployeeManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    // Atributo personalizado
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuditableAttribute : Attribute
    {
        public string Description { get; }
        public AuditableAttribute(string description) => Description = description;
    }

    // Enumeración
    public enum Department
    {
        HR,
        IT,
        Finance
    }

    // Interfaz genérica
    public interface IEntity<T>
    {
        T Id { get; }
        string GetDetails();
    }

    // Clase abstracta
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; protected set; }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract string GetRole();
    }

    // Clase concreta con herencia
    [Auditable("Employee class for tracking")]
    public class Employee : Person, IEntity<int>
    {
        // Campos y propiedades
        private readonly int _employeeId;
        public int Id => _employeeId;
        public Department Department { get; set; }
        public double? Salary { get; set; }
        public static int EmployeeCount { get; private set; }
        public List<string> Skills { get; } = new List<string>();

        // Constructor
        public Employee(int id, string name, int age, Department department, double? salary)
            : base(name, age)
        {
            _employeeId = id;
            Department = department;
            Salary = salary;
            EmployeeCount++;
        }

        // Propiedad automática
        public string Title { get; set; } = "Employee";

        // Método sobrescrito
        public override string GetRole() => $"Employee in {Department}";

        // Método con expresión lambda
        public Func<int, string> GetIdDescription = id => $"Employee ID: {id}";

        // Método genérico
        public T ComputeBonus<T>(T baseBonus) where T : struct
        {
            if (Salary.HasValue)
            {
                return baseBonus;
            }
            return default;
        }

        // Método asíncrono
        public async Task<string> FetchDetailsAsync()
        {
            await Task.Delay(100); // Simula operación asíncrona
            return await Task.FromResult(GetDetails());
        }

        // Implementación de interfaz
        public string GetDetails() => $"{Name}, {Age} years old, {Department}, Salary: {Salary?.ToString() ?? "N/A"}";

        // Método estático
        public static Employee CreateDefault() => new Employee(0, "Unknown", 0, Department.HR, null);
    }

    // Clase estática para métodos de extensión
    public static class EmployeeExtensions
    {
        public static string GetSummary(this Employee employee) => $"Summary: {employee.GetDetails()}";
    }

    // Clase principal para pruebas
    public class Program
    {
        #region Main Program
        public static async Task Main()
        {
            try
            {
                // Variables y constantes
                const int MaxEmployees = 10;
                var employees = new List<Employee>
                {
                    new Employee(1, "Alice", 30, Department.IT, 75000.50),
                    new Employee(2, "Bob", 25, Department.Finance, null)
                };

                // Bucle foreach
                foreach (var emp in employees.Where(e => e.Age > 20))
                {
                    Console.WriteLine(emp.GetDetails());
                    Console.WriteLine(emp.GetSummary());
                }

                // Switch expression
                string departmentName = employees[0].Department switch
                {
                    Department.HR => "Human Resources",
                    Department.IT => "Information Technology",
                    Department.Finance => "Finance",
                    _ => "Unknown"
                };
                Console.WriteLine($"Department: {departmentName}");

                // Lambda y LINQ
                var seniorEmployees = employees.Where(e => e.Age >= 30).ToList();
                Console.WriteLine($"Senior employees: {seniorEmployees.Count}");

                // Asincronía
                var details = await employees[0].FetchDetailsAsync();
                Console.WriteLine($"Async details: {details}");

                // Operador condicional nulo
                double? totalSalary = employees.Sum(e => e.Salary ?? 0);
                Console.WriteLine($"Total salary: {totalSalary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion
    }
}

/* |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| */

namespace SemanticHighlighting
{
    // type (custom type)
    using CustomAlias = System.Collections.Generic.List<int>;

    // type.defaultLibrary (built-in types)
    using System;
    using System.Threading.Tasks;

    // enum
    public enum Color
    {
        // enumMember
        Red,
        Green,
        Blue
    }

    // interface
    public interface IVehicle
    {
        // property (readwrite)
        string Brand { get; set; }

        // property.readonly
        int Wheels { get; }

        // event
        event EventHandler Started;

        // method (interface method)
        void Start();
    }

    // class
    public class Car : IVehicle
    {
        // variable.readonly (instance, readonly)
        private readonly string _model = "Sedan";

        // variable.readonly.defaultLibrary (const from system)
        private const int MaxSpeed = 200;

        // property (readwrite)
        public string Brand { get; set; }

        // property.readonly
        public int Wheels => 4;

        // event
        public event EventHandler Started;

        // constructor (treated as method)
        public Car(string brand)
        {
            Brand = brand;
        }

        // method
        public void Start()
        {
            // parameter
            LogMessage("Engine started.");

            // variable (readwrite, local)
            var status = "Running";

            // function.defaultLibrary (built-in function)
            Console.WriteLine($"Car {Brand} is {status}");

            // Raise event
            Started?.Invoke(this, EventArgs.Empty);
        }

        // function (static method)
        public static void LogMessage(string message)
        {
            // parameter
            System.Diagnostics.Debug.WriteLine(message);
        }

        // property (auto, readonly)
        public DateTime CreatedAt { get; } = DateTime.Now;

        // struct (inside class)
        public struct EngineInfo
        {
            // field (variable)
            public double Horsepower;

            // property
            public string Type { get; set; }
        }

        // variable (readonly, local in method)
        public void DisplayEngine()
        {
            // variable.readonly (local readonly)
            var info = new EngineInfo
            {
                Horsepower = 150.0,
                Type = "V6"
            };

            // variable (readwrite, local)
            var output = $"Engine: {info.Horsepower} HP, Type: {info.Type}";
            Console.WriteLine(output);
        }
    }

    // struct
    public struct Point
    {
        // field (variable)
        public int X;
        public int Y;

        // method (in struct)
        public double DistanceToOrigin()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    // class.defaultLibrary (inherits from System.Object)
    public class Logger : IDisposable
    {
        // variable (instance)
        private bool _disposed = false;

        // method (override)
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }

    // macro (preprocessor directive)
    #region Helper Utilities
    // This region is not a macro, but preprocessor directives can simulate it
#if DEBUG
        // function.defaultLibrary
        Console.WriteLine("Debug mode enabled.");
#endif
    #endregion

    // Main function (entry point)
    public static class Program
    {
        // function
        public static async Task Main(string[] args)
        {
            // variable (readwrite)
            var car = new Car("Toyota");

            // method call
            car.Start();

            // variable.readonly.defaultLibrary (literal treated as const-like)
            const string AppName = "SemanticHighlightingTester";

            // await (uses built-in types)
            await Task.Delay(1000);

            // Display app name
            Console.WriteLine($"App: {AppName}");
        }
    }
}