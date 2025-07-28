










using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public record UserRecord(string Name, UserRole Role, Address Address)
{
    public int Id { get; init; } = new Random().Next(1, 1000);
    public string Email { get; init; } = $"{Name.ToLower().Replace(" ", ".")}@example.com";
    public UserRecord() : this("Default Name", UserRole.Viewer, new Address { Street = "Default Street", City = "Default City", ZipCode = "00000" }) { }
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Role: {Role}, Address: {Address.Street}, {Address.City}, {Address.ZipCode}");
    }
}


/// <summary>
/// Enum que representa los roles de los usuarios.
/// </summary>
public enum UserRole
{
    Admin,
    Editor,
    Viewer
}

/// <summary>
/// Struct que representa una dirección.
/// </summary>
public struct Address
{
    public string Street;
    public string City;
    public string ZipCode;
}

/// <summary>
/// Interfaz que define las propiedades y métodos de un usuario.
/// </summary>
public interface IUser
{
    string Name { get; set; }
    UserRole Role { get; set; }
    Address Address { get; set; }
    void DisplayInfo();
}

/// <summary>
/// Clase que representa a un usuario y implementa la interfaz IUser.
/// </summary>
public class User : IUser
{
    public string Name { get; set; }
    public UserRole Role { get; set; }
    public Address Address { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Role: {Role}, Address: {Address.Street}, {Address.City}, {Address.ZipCode}");
    }
}

/// <summary>
/// Clase genérica para manejar una colección de elementos.
/// </summary>
/// <typeparam name="T">Tipo de los elementos en la colección.</typeparam>
public class GenericCollection<T> where T : class
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerable<T> GetItems()
    {
        return _items;
    }
}

public class Program
{
    /// <summary>
    /// Método que usa LINQ para buscar usuarios por rol.
    /// </summary>
    /// <param name="users">Colección de usuarios.</param>
    /// <param name="role">Rol a buscar.</param>
    /// <returns>Lista de usuarios con el rol especificado.</returns>
    public static List<IUser> FindUsersByRole(GenericCollection<IUser> users, UserRole role)
    {
        return users.GetItems().Where(u => u.Role == role).ToList();
    }

    /// <summary>
    /// Método que usa regex para validar un código postal.
    /// </summary>
    /// <param name="zipCode">Código postal a validar.</param>
    /// <returns>True si el código postal es válido, false en caso contrario.</returns>
    public static bool ValidateZipCode(string zipCode)
    {
        string pattern = @"^\d{5}$"; // Valida un código postal de 5 dígitos
        return Regex.IsMatch(zipCode, pattern);
    }

    /// <summary>
    /// Método que demuestra el uso de punteros en código unsafe.
    /// </summary>
    public static unsafe void UnsafeMethod()
    {
        int value = 10;
        int* pointer = &value;
        Console.WriteLine($"Value: {value}, Pointer: {(int)pointer}, Dereferenced: {*pointer}");
    }

    /// <summary>
    /// Método que demuestra el uso de labels y goto.
    /// </summary>
    public static void GotoExample()
    {
        int i = 0;
    start:
        if (i < 5)
        {
            Console.WriteLine($"Goto iteration: {i}");
            i++;
            goto start;
        }
    }

    public static void Main(string[] args)
    {
        // Crear una colección de usuarios
        GenericCollection<IUser> users = new GenericCollection<IUser>();

        // Crear algunos usuarios
        User user1 = new User 
        { 
            Name = "Alice", 
            Role = UserRole.Admin, 
            Address = new Address { Street = "123 Main St", City = "Anytown", ZipCode = "12345" } 
        };
        User user2 = new User 
        { 
            Name = "Bob", 
            Role = UserRole.Editor, 
            Address = new Address { Street = "456 Elm St", City = "Othertown", ZipCode = "67890" } 
        };

        // Agregar usuarios a la colección
        users.Add(user1);
        users.Add(user2);

        // Mostrar información de los usuarios
        Console.WriteLine("Todos los usuarios:");
        foreach (var user in users.GetItems())
        {
            user.DisplayInfo();
        }

        // Buscar usuarios por rol usando LINQ
        var admins = FindUsersByRole(users, UserRole.Admin);
        Console.WriteLine("\nAdministradores:");
        foreach (var admin in admins)
        {
            admin.DisplayInfo();
        }

        // Validar un código postal con regex
        string zipCode = "12345";
        bool isValid = ValidateZipCode(zipCode);
        Console.WriteLine($"\n¿Es {zipCode} un código postal válido? {isValid}");

        // Demostración de código unsafe con punteros
        Console.WriteLine("\nDemostración de punteros:");
        UnsafeMethod();

        // Demostración de labels y goto
        Console.WriteLine("\nDemostración de goto:");
        GotoExample();
    }
}