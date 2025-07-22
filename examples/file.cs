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