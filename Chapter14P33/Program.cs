using System.Security.Cryptography;
using System.Xml.Linq;

namespace Chapter14P33
{
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


            phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; 
                var parsed = Int32.TryParse(keyChar.ToString(), out int page);
                Console.Clear(); 
                if (!parsed || page < 1 || page > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var toShow = phoneBook.Skip((page - 1) * 2).Take(2);
                    foreach (var t in toShow)
                    {
                        Console.WriteLine($"{t.Name} {t.LastName} {t.PhoneNumber} {t.Email}");
                    }

                }


            }
        }
    }
}