using System;

namespace ColorTestApp
{
    public enum UserRole
    {
        Admin,
        Guest,
        User
    }

    public interface IUser
    {
        string Name { get; }
        UserRole Role { get; }
        void Login();
    }

    public readonly struct UserData
    {
        public readonly int Id;
        public readonly string Email;

        public UserData(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }

    public class BaseUser : IUser
    {
        public string Name { get; private set; }
        public UserRole Role { get; private set; }

        public BaseUser(string name, UserRole role)
        {
            Name = name;
            Role = role;
        }

        public virtual void Login()
        {
            Console.WriteLine($"{Name} has logged in as {Role}");
        }
    }

    public class AdminUser : BaseUser
    {
        public AdminUser(string name) : base(name, UserRole.Admin) { }

        public void AccessAdminPanel() =>
            Console.WriteLine($"{Name} accessing admin panel...");
    }

    public record OperationResult<T>(bool Success, T Result);

    public class Processor<T>
    {
        public OperationResult<T> Process(Func<T> task)
        {
            try
            {
                var result = task();
                return new OperationResult<T>(true, result);
            }
            catch
            {
                return new OperationResult<T>(false, default!);
            }
        }
    }

    public delegate void UserCallback(IUser user);

    public class Program
    {
        public static void Main()
        {
            IUser user = new AdminUser("Alice");
            user.Login();

            Processor<int> processor = new Processor<int>();
            var result = processor.Process(() => 42);
            Console.WriteLine($"Success: {result.Success}, Value: {result.Result}");

            UserCallback callback = u => Console.WriteLine($"Callback for {u.Name}");
            callback(user);
        }

        // *********************************************************************



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<T> ExecuteQuery<T>(
            IEnumerable<T> source,
            Func<T, bool> predicate,
            Func<IEnumerable<T>, IOrderedEnumerable<T>> orderBy,
            int page,
            int pageSize,
            bool useCache = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (page < 1) throw new ArgumentOutOfRangeException(nameof(page));
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            IEnumerable<T> query = source.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
