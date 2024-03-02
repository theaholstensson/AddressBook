// AddressBookApp/Program.cs
using AddressBookApp;
using System;

var addressBook = new AddressBook();

//Main menu
while (true)
{
    Console.WriteLine("######## Välkommen till din adressbok! ########");
    Console.WriteLine();
    Console.WriteLine($"Du har {addressBook.NumberOfContacts} kontakter.");
    Console.WriteLine();
    Console.WriteLine("Kontakter:");
    ShowAllContacts(addressBook);
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine();

    Console.WriteLine("[1] Visa detaljerad information om en kontakt");
    Console.WriteLine("[2] Lägg till kontakt");
    Console.WriteLine("[3] Radera kontakt");
    Console.WriteLine("[4] Avsluta");
    Console.Write("Välj ett alternativ: ");
    var option = Console.ReadLine();

    Console.Clear();

    switch (option)
    {
        case "1":
            ShowContactDetails(addressBook);
            break;
        case "2":
            AddContact(addressBook);
            break;
        case "3":
            RemoveContact(addressBook);
            break;
        case "4":
            Environment.Exit(0);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ogiltigt val. Försök igen!");
            Console.ResetColor();
            break;
    }
}

//What the options do
void ShowAllContacts(AddressBook addressBook)
{
    if (addressBook.NumberOfContacts == 0)
    {
        Console.WriteLine("Inga kontakter hittades, lägg till kontakter.");
    }
    else
    {
        addressBook.ListAllContacts();
    }
    Console.WriteLine();
}

void ShowContactDetails(AddressBook addressBook)
{
    Console.WriteLine("Kontakter:");
    addressBook.ListAllContacts();
    Console.WriteLine();
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("## Visa detaljerad information om en kontakt ##");
    Console.WriteLine();
    Console.Write("Ange kontaktens email: ");
    var email = Console.ReadLine();
    Console.WriteLine();

    addressBook.ShowContactDetails(email);
    Console.WriteLine();
    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn...");
    Console.ReadKey();
    Console.Clear();
}

void AddContact(AddressBook addressBook)
{
    Console.WriteLine("## Lägg till kontakt ##");
    Console.WriteLine();
    Console.Write("Ange förnamn: ");
    var firstName = Console.ReadLine();
    Console.Write("Ange efternamn: ");
    var lastName = Console.ReadLine();
    Console.Write("Ange telefonnummer: ");
    var phoneNumber = Console.ReadLine();
    Console.Write("Ange emailadress: ");
    var email = Console.ReadLine();
    Console.Write("Ange adress: ");
    var address = Console.ReadLine();
    Console.Write("Ange stad: ");
    var city = Console.ReadLine();
    Console.Write("Ange postnummer: ");
    var postalNumber = Console.ReadLine();

    var contact = new Contact
    {
        FirstName = firstName,
        LastName = lastName,
        PhoneNumber = phoneNumber,
        Email = email,
        Address = address,
        City = city,
        PostalNumber = postalNumber
    };

    addressBook.AddContact(contact);

    Console.WriteLine("Kontakt har lagts till!");
    Console.WriteLine();
    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn...");
    Console.ReadKey();
    Console.Clear();
}

void RemoveContact(AddressBook addressBook)
{
    Console.WriteLine("Kontakter:");
    addressBook.ListAllContacts();
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine();
    Console.Write("Ange email för den kontakt du vill radera: ");
    var email = Console.ReadLine();

    addressBook.RemoveContactByEmail(email!);

    Console.WriteLine("Kontakt raderad!");
    Console.WriteLine();
    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn...");
    Console.ReadKey();
    Console.Clear();
}