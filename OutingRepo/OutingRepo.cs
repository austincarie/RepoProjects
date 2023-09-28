public class OutingRepo
{
    List<Outing> _outings = new List<Outing>();

    public OutingRepo(){
        Seed();
    }
    public void Seed(){
        //? EventType type, int people, string date, double cost
        Outing IceSpice = new Outing(EventType.Concert, 4, "6/9", 20);
        _outings.Add(IceSpice);

        Outing Bowling = new Outing(EventType.Bowling, 28, "4/20", 30);
        _outings.Add(Bowling);
    }

    public void AddOuting(Outing outing){
        _outings.Add(outing);
    }
    
    public List<Outing> ShowOutings(){
        return _outings;
    }
}
