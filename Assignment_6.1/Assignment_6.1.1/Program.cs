//Implement a single linked list with each node representing a house. 
// Create a house class with properties for the number of bedrooms, bathrooms, and price.
// Allow user to search for and display any house

// House Class
// public properties for the number of address, type, House Next; 
// House Constructor(int number, string address, string type)
// {
//     assign parameters to properties
//  }

// Node Class HouseList to handle linked list functionality
// private House head;
// public HouseList() { head = null; }

// func void Add(int number, string address, string type)
//  {
//     House newHouse = new House(number, address, type);
//  } 
// func House Search(int number)

class House //this will be my data type for each node in the linked list
{
    public int HouseNumber { get; set; }
    public string Address { get; set; }
    public string HouseType { get; set; }
    public House Next { get; set; }

    public House(int houseNumber, string address, string houseType)
    {
        HouseNumber = houseNumber;
        Address = address;
        HouseType = houseType;
        Next = null;
    }
}

// Class to manage linked list functionality
class HouseList
{
    private House _head;

    public HouseList()
    {
        _head = null;
    }

    
    public void AddHouse(int houseNumber, string address, string houseType)
    {
        House newHouse = new House(houseNumber, address, houseType);//create the new house

        if (_head == null) // If the list is empty, add the new house as the head
        {
            _head = newHouse;
            return;
        }

        House current = _head; //_head is the first node in the list and is a House object. we create the 'current' variable to point to it.
        while (current.Next != null)//while we are not at the end of the list, keep moving to the next node
        {
            current = current.Next; //current is now pointing to the next node in the list until it reaches the end or the Node where next = null
        }
        current.Next = newHouse; //this will assign the new house at the end of the list since current is pointing to the last node in the list.
    }

    // Search for a house by its number
    public House FindHouse(int houseNumber)
    {
        House current = _head; //current is the first node in the list
        while (current != null) //continue until we reach the end of the list
        {
            if (current.HouseNumber == houseNumber) // search for first match
            {
                return current; //return the first match
            }
            current = current.Next;//move to the next node in the list if no match is found
        }
        return null;
    }

    // Display all houses
    public void DisplayAllHouses()
    {
        if (_head == null)
        {
            Console.WriteLine("No houses in the list.");
            return;
        }

        House current = _head;
        while (current != null)
        {
            DisplayHouseDetails(current);
            current = current.Next;
        }
    }

    // Display details of a specific house
    public void DisplayHouseDetails(House house)
    {
        Console.WriteLine("\n----- House Details -----");
        Console.WriteLine($"House Number: {house.HouseNumber}");
        Console.WriteLine($"Address: {house.Address}");
        Console.WriteLine($"Type: {house.HouseType}");
        Console.WriteLine("------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        HouseList linkedListOfHouses = new HouseList();
        
        // pre load some houses
        linkedListOfHouses.AddHouse(101, "123 Main St, Cityville", "Apartment");
        linkedListOfHouses.AddHouse(102, "456 Oak Ave, Townsburg", "Modern");
        linkedListOfHouses.AddHouse(103, "789 Pine Rd, Villageton", "Victorian");
        linkedListOfHouses.AddHouse(104, "321 Elm St, Nightmare", "Rancher");

        bool exit = false;
        
        //UI to allow user to use the house list functionality
        while (!exit)
        {
            Console.WriteLine("\n===== House Management System =====");
            Console.WriteLine("1. Add a new house");
            Console.WriteLine("2. Search for a house by number");
            Console.WriteLine("3. Display all houses");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewHouse(linkedListOfHouses);
                    break;
                case "2":
                    SearchHouseByNumber(linkedListOfHouses);
                    break;
                case "3":
                    linkedListOfHouses.DisplayAllHouses();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddNewHouse(HouseList houses)
    {
        Console.Write("Enter house number: ");
        if (!int.TryParse(Console.ReadLine(), out int houseNumber))//check if the input is a valid integer
        {
            Console.WriteLine("Invalid house number!");
            return;
        }

        Console.Write("Enter address: ");
        string address = Console.ReadLine();

        Console.Write("Enter house type (Rancher, Modern, etc.): ");
        string houseType = Console.ReadLine();

        houses.AddHouse(houseNumber, address, houseType);
        Console.WriteLine("House added successfully!");
    }

    static void SearchHouseByNumber(HouseList houses)
    {
        Console.Write("Enter house number to search: ");
        if (!int.TryParse(Console.ReadLine(), out int houseNumber))//check if the input is a valid integer
        {
            Console.WriteLine("Invalid house number!");
            return;
        }

        House foundHouse = houses.FindHouse(houseNumber);
        if (foundHouse != null)
        {
            Console.WriteLine("House found!");
            houses.DisplayHouseDetails(foundHouse);
        }
        else
        {
            Console.WriteLine($"No house with number {houseNumber} was found.");
        }
    }
}
    