public enum EventType {Golf, Bowling, AmusementPark, Concert, Miscellaneous}
public class Outing
{

    public EventType EventType {get; set;}

    public int NumberOfPeople {get; set;}

    public string Date {get; set;}

    public double CostPerPerson {get; set;}

    public double TotalCost;
    public Outing(){}

    public Outing(EventType type, int people, string date, double cost){
        EventType = type;
        NumberOfPeople = people;
        Date = date;
        CostPerPerson = cost;
        TotalCost = NumberOfPeople * CostPerPerson;
    }

    public double GetTotalCost(){
        return TotalCost;
    }
}
