// AddressBookApp/AddressBook.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AddressBookApp
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
            LoadContacts();
        }

        public int NumberOfContacts => contacts.Count;

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            SaveContacts();
        }

        public void RemoveContactByEmail(string email)
        {
            contacts.RemoveAll(c => c.Email == email);
            SaveContacts();
        }

        public void ListAllContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.Email}");
            }
        }

        public void ShowContactDetails(string email)
        {
            var contact = contacts.Find(c => c.Email == email);
            if (contact != null)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"Stad: {contact.City}");
                Console.WriteLine($"Postnummer: {contact.PostalNumber}");
            }
            else
            {
                Console.WriteLine("Kontakt hittades ej.");
            }
        }

        private void LoadContacts()
        {
            if (File.Exists("contacts.json"))
            {
                var json = File.ReadAllText("contacts.json");
                contacts = JsonSerializer.Deserialize<List<Contact>>(json);
            }
        }

        private void SaveContacts()
        {
            var json = JsonSerializer.Serialize(contacts);
            File.WriteAllText("contacts.json", json);
        }
    }
}
