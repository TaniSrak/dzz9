using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactsManager manager = new ContactsManager();

            try
            {
                manager.AddContact("Alice", "123-456-7890");
                manager.AddContact("Bob", "098-765-4321");

                manager.AddContact("", "123-456-7890");
            }
            catch (InvalidContactException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Все контакты:");
            manager.DisplayContacts();

            var contact = manager.FindContact("Alice");
            if (contact != null)
            {
                Console.WriteLine($"\nКонтакт: {contact}");
            }
            else
            {
                Console.WriteLine("\nНет контакта.");
            }

            manager.RemoveContact("Bob");

        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString() //для удобства
        {
            return $"Name: {Name}, PhonenUmber: {PhoneNumber}";
        }
    }

    public class ContactsManager
    {
        private List<Contact> contacts;

        public ContactsManager()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(string name, string phoneNumber) //добавили
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new InvalidContactException("Имя и номер не могут быть пустыми.");
            }
            contacts.Add(new Contact(name, phoneNumber));
        }

        public void RemoveContact(string name) //удалили
        {
            var contact = contacts.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            else
            {
                Console.WriteLine("Такого контакта нет");
            }
        }

        public Contact FindContact(string name) //поиск
        {
            return contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayContacts() //отобразили всех
        {
            if(contacts.Count == 0)
            {
                Console.WriteLine("Нет контактов");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }

    public class InvalidContactException : Exception
    {
        public InvalidContactException() { }

        public InvalidContactException(string message) : base(message) { }

        public InvalidContactException(string message, Exception inner) : base(message, inner) { }
    }
}
