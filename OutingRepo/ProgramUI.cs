public class ProgramUI
{   
    private readonly OutingRepo _outingsList = new OutingRepo();
    public void Run(){
        RunMenu();
    }

    public void RunMenu(){
        

        bool loopMenu = true;
        while(loopMenu){
            
            Console.Clear();
            Console.WriteLine("Please select a number: ");
            Console.WriteLine("1. Display Outings ");
            Console.WriteLine("2. Add Outing ");
            Console.WriteLine("3. Display Costs ");
            Console.WriteLine("4. Exit ");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    DisplayOutingsList();
                    break;
                case "2":
                    CreateOuting();
                    break;
                case "3":
                    DisplayCosts();
                    break;
                case "4":
                    loopMenu = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-4");
                    WaitForKeypress();
                    break;

            }
        }
    }

    public void CreateOuting(){
        //? Display each piece one by one and store into variables
        
        bool LoopMenu = true;
        EventType type = EventType.Miscellaneous;
        while(LoopMenu){
            Console.Clear();
            Console.WriteLine("Please select an event type: ");
            Console.WriteLine("1. Golf ");
            Console.WriteLine("2. Bowling ");
            Console.WriteLine("3. Amusement Park ");
            Console.WriteLine("4. Concert ");

            string selection = Console.ReadLine();
            switch(selection){
                case "1":
                    type = EventType.Golf;
                    LoopMenu = false;
                    break;
                case "2":
                    type = EventType.Bowling;
                    LoopMenu = false;
                    break;
                case "3":
                    type = EventType.AmusementPark;
                    LoopMenu = false;
                    break;
                case "4":
                    type = EventType.Concert;
                    LoopMenu = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-4");
                    WaitForKeypress();
                    break;

            }
        }
            Console.WriteLine("Enter the number of people: ");
            int numOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date (Ex: 2/27): ");
            string date = Console.ReadLine();
            Console.WriteLine("Enter the cost per person: ");
            double cost = double.Parse(Console.ReadLine());
            Outing newOuting = new Outing(type, numOfPeople, date, cost);
            _outingsList.AddOuting(newOuting);
        
        //? Create a new Outing object with those variables
        //? Pass that Outing to the AddOuting method
    }
    
    public void DisplayOutingsList(){
        Console.Clear();
        List<Outing> outings = _outingsList.ShowOutings();
        foreach(Outing outing in outings){
            DisplayOuting(outing);
        }
        WaitForKeypress();
    }

    public void DisplayCosts(){
        Console.Clear();
        List<Outing> outings = _outingsList.ShowOutings();
        double TotalCostSum = 0;
        double GolfCost = 0, BowlingCost = 0, AmusementCost = 0, ConcertCost = 0;
        foreach(Outing outing in outings){
            TotalCostSum += outing.GetTotalCost();
            switch(outing.EventType){
                case EventType.Golf:
                    GolfCost += outing.GetTotalCost();
                    break;
                case EventType.Bowling:
                    BowlingCost += outing.GetTotalCost();
                    break;
                case EventType.AmusementPark:
                    AmusementCost += outing.GetTotalCost();
                    break;
                case EventType.Concert:
                    ConcertCost += outing.GetTotalCost();
                    break;
            }
        }
        Console.WriteLine($"Golf Outing Cost: ${GolfCost}");
        Console.WriteLine($"Bowling Outing Cost: ${BowlingCost}");
        Console.WriteLine($"Amusement Park Outing Cost: ${AmusementCost}");
        Console.WriteLine($"Concert Outing Cost: ${ConcertCost}");
        Console.WriteLine($"The total cost of all outings is ${TotalCostSum}");
        WaitForKeypress();
    }


    public void WaitForKeypress() {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }        

    public void DisplayOuting(Outing outing) {
        Console.WriteLine($"Event Type: {outing.EventType} \n" +
        $"Number of People: {outing.NumberOfPeople} \n" +
        $"Date: {outing.Date} \n" +
        $"Cost per Person: ${outing.CostPerPerson} \n" +
        $"Total Cost: ${outing.GetTotalCost()} \n");
    }
}