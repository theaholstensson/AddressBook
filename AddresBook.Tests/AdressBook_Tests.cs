using AddressBookApp;

namespace AddresBook.Tests;

public class AdressBook_Tests
{
    [Fact]
    public void AddContact_IfAddMultipleContacts_ShouldUpdateNumberOfContacts()
    {
        // Arrange
        var addressBook = new AddressBook();
        var contact1 = new Contact
        {
            FirstName = "Bertil",
            LastName = "Andersson",
            PhoneNumber = "123456789",
            Email = "bertil.andersson@hotmail.com",
            Address = "Kungsgatan 13",
            City = "Stockholm",
            PostalNumber = "123 45"
        };
        var contact2 = new Contact
        {
            FirstName = "Anna",
            LastName = "Svensson",
            PhoneNumber = "987654321",
            Email = "anna.svensson@hotmail.com",
            Address = "Köpmangatan 1",
            City = "Göteborg",
            PostalNumber = "543 21"
        };

        // Act
        addressBook.AddContact(contact1);
        addressBook.AddContact(contact2);

        // Assert
        Assert.Equal(2, addressBook.NumberOfContacts);
    }
}

