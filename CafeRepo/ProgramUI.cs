//! Displays the menu for the app
using System.Net;
using System.Numerics;
using System.Reflection;
public class ProgramUI
{
    private readonly MenuRepo _menuItems = new MenuRepo();
    
    public void Run() {
        RunMenu();
    }

    public void RunMenu() {
        bool loopMenu = true;
        while(loopMenu){
            Console.Clear();
            Console.WriteLine("Please select a number");
            Console.WriteLine("1. Add a menu item \n" +
                            "2. Show all menu items \n" +
                            "3. Get a menu item by number \n" +
                            "4. Get a menu item by name \n" +
                            "5. Update a menu item \n" +
                            "6. Delete a menu item \n" +
                            "7. Exit");
            string input = Console.ReadLine();
            switch (input){
                case "1":
                    AddMenuItem();
                    break;
                case "2":
                    ListAllMenuItems();
                    break;
                case "3":
                    GetMenuItemByNumber();
                    break;
                case "4":
                    GetMenuItemByName();
                    break;
                case "5":
                    UpdateItem();
                    break;
                case "6":
                    DeleteMenuItem();
                    break;
                case "7":
                    //Exit the app
                    loopMenu = false;
                    break;
                default: 
                    Console.WriteLine("Please enter a valid number");
                    WaitForKeypress();
                    break;
            }
        }
    }

    public void AddMenuItem(){
        Console.Clear();
        Console.WriteLine("Item #: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Ingredients(separated by commas): ");
        string ingredients = Console.ReadLine();
        Console.WriteLine("price: ");
        double price = double.Parse(Console.ReadLine());
        MenuItem item = new MenuItem(number, name, description, ingredients, price);
        _menuItems.AddContentToDirectory(item);
        
    }
    
    public void ListAllMenuItems(){
        Console.Clear();
        List<MenuItem> menu = _menuItems.GetAllMenuItems();
        foreach(MenuItem item in menu){
            DisplayMenuItem(item);
        }
        WaitForKeypress();
    }

    public void GetMenuItemByNumber(){
        Console.Clear();
        Console.WriteLine("Please enter a menu number: ");
        int numberSelection = int.Parse(Console.ReadLine());
        MenuItem itemToDisplay = _menuItems.GetItemByNumber(numberSelection);
        Console.Clear();
        DisplayMenuItem(itemToDisplay);
        WaitForKeypress();
    }

    public void GetMenuItemByName(){
        Console.Clear();
        Console.WriteLine("Please enter the menu item's name: ");
        string nameSelection = Console.ReadLine();
        MenuItem itemToDisplay = _menuItems.GetItemByName(nameSelection);
        Console.Clear();
        DisplayMenuItem(itemToDisplay);
        WaitForKeypress();
    }

    public void UpdateItem(){
        Console.Clear();

        bool validInput = false;
        int numberToUpdate = 0;
        while(!validInput){
            Console.WriteLine("Please enter the number of the item you'd like to update: ");
            numberToUpdate = int.Parse(Console.ReadLine());
            if(_menuItems.GetItemByNumber(numberToUpdate) == default){
                Console.WriteLine("Please enter a valid menu item number");
            }
            else{
                validInput = true;
            }
        }

        Console.Clear();
        Console.WriteLine("What would you like to update?");
        Console.WriteLine("1. Number \n" +
                        "2. Name \n" +
                        "3. Description \n" +
                        "4. Ingredients \n" +
                        "5. Price \n");
        string selection = Console.ReadLine();
        validInput = false;
        while(!validInput){
            switch(selection){
                case "1":
                    Console.Clear();
                    Console.WriteLine("Please enter a new number: ");
                    int number = int.Parse(Console.ReadLine());
                    _menuItems.UpdateNumber(number, _menuItems.GetItemByNumber(numberToUpdate));
                    validInput = true;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please enter a new name: ");
                    string name = Console.ReadLine();
                    _menuItems.UpdateName(name, _menuItems.GetItemByNumber(numberToUpdate));
                    validInput = true;
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Please enter a new description: ");
                    string description = Console.ReadLine();
                    _menuItems.UpdateDescription(description, _menuItems.GetItemByNumber(numberToUpdate));
                    validInput = true;
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Please enter the new ingredients: ");
                    string ingredients = Console.ReadLine();
                    _menuItems.UpdateIngredients(ingredients, _menuItems.GetItemByNumber(numberToUpdate));
                    validInput = true;
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Please enter a new price: ");
                    double price = double.Parse(Console.ReadLine());
                    _menuItems.UpdatePrice(price, _menuItems.GetItemByNumber(numberToUpdate));
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-5");
                    WaitForKeypress();
                    break;
            }
        }
    }

    public void DeleteMenuItem(){
        Console.Clear();

        bool validInput = false;
        int numberToDelete = 0;
        while(!validInput){
            Console.WriteLine("Please enter the number of the item you'd like to delete: ");
            numberToDelete = int.Parse(Console.ReadLine());
            if(_menuItems.GetItemByNumber(numberToDelete) == default){
                Console.WriteLine("Please enter a valid menu item number");
            }
            else{
                validInput = true;
                _menuItems.DeleteItem(_menuItems.GetItemByNumber(numberToDelete));
            }
        }
    }

    public void WaitForKeypress() {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public void DisplayMenuItem(MenuItem item) {
        Console.WriteLine($"#{item.MealNumber} \n" +
        $"Name: {item.MealName} \n" +
        $"Description: {item.Description} \n" +
        $"Ingredients: {item.Ingredients} \n" +
        $"Price: ${item.Price} \n");
    }

    /*
    public bool ValidMenuNumber(int number){
        foreach(MenuItem item in _menuItems){
            if(item.MealNumber == number){
                return true;
            }
        }
        return false;
    }
    */
}