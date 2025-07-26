










// === C# Advanced Features Test ===

using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Console; // Using static

namespace AdvancedCSharpTest
{
    // 1. Records (C# 9+)
    public record Person(string Name, int Age);
    
    // 2. Primary constructor (C# 12+)
    public class BankAccount(string accountNumber, decimal initialBalance)
    {
        // 3. Auto-properties with primary constructor
        public string AccountNumber { get; } = accountNumber;
        public decimal Balance { get; private set; } = initialBalance;
        
        // 4. Init-only properties
        public string? Owner { get; init; }
        
        // 5. Pattern matching with switch expressions
        public string GetAccountType() => AccountNumber[..2] switch
        {
            "SA" => "Savings",
            "CH" => "Checking",
            _ => "Unknown"
        };
        
        // 6. Null-forgiving operator
        public void Transfer(BankAccount? destination, decimal amount)
        {
            if (destination is null) throw new ArgumentNullException(nameof(destination));
            
            // 7. Range and index operators
            var last4 = AccountNumber[^4..];
            
            // 8. Target-typed new expressions
            var transactions = new List<Transaction>
            {
                new(amount, DateTime.Now),
                new() { Amount = -amount, Timestamp = DateTime.Now } // Target-typed
            };
        }
    }
    
    // 9. Struct with ref readonly methods
    public readonly struct Point(ref int x, ref readonly int y) // ref readonly parameters
    {
        public readonly int X { get; } = x;
        public int Y { get; } = y;
        
        // 10. ReadOnlySpan<T> and ref readonly return
        public readonly ref readonly int GetYRef() => ref Y;
    }
    
    // 11. Generic attributes (C# 11+)
    [GenericTypeConstraintTest<string>]
    public class Transaction(decimal amount, DateTime timestamp)
    {
        public decimal Amount { get; } = amount;
        public DateTime Timestamp { get; } = timestamp;
        
        // 12. Required modifier (C# 11+)
        public required string TransactionId { get; set; }
        
        // 13. Raw string literals (C# 11+)
        public string ToJson() => $$"""
        {
            "amount": {{Amount}},
            "timestamp": "{{Timestamp:yyyy-MM-dd HH:mm:ss}}"
        }
        """;
        
        // 14. File-scoped namespace and global using
        public async Task<string> ProcessAsync()
        {
            // 15. Async streams
            await foreach (var item in GetDataStream())
            {
                yield return item.ToString();
            }
        }
        
        private async IAsyncEnumerable<int> GetDataStream()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
    
    // 16. Generic attribute
    [AttributeUsage(AttributeTargets.Class)]
    public class GenericTypeConstraintTest<T> : Attribute where T : class
    {
        public Type GenericType { get; } = typeof(T);
    }
    
    // 17. Function pointers and unsafe code
    public unsafe class UnsafeExample
    {
        public delegate*<int, int, int> AddFunctionPointer;
        
        public int ExecuteOperation(int a, int b)
        {
            // 18. Pointer arithmetic
            int* ptr = stackalloc int[2] { a, b };
            return ptr[0] + ptr[1];
        }
    }
    
    // 19. Implicit usings and top-level statements (Program.cs style)
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 20. Pattern matching with relational patterns (C# 9+)
            var person = new Person("John", 25);
            var category = person.Age switch
            {
                < 18 => "Minor",
                >= 18 and < 65 => "Adult",
                >= 65 => "Senior"
            };
            
            // 21. With expressions for records
            var olderPerson = person with { Age = person.Age + 1 };
            
            // 22. Null-coalescing assignment
            string? message = null;
            message ??= "Default message";
            
            // 23. Throw expressions
            var value = args.Length > 0 ? args[0] : throw new ArgumentException("No args");
            
            WriteLine($"Category: {category}");
        }
    }
}