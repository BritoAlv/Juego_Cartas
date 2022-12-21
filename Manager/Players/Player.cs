namespace Poker;
public abstract class Player : Ideable
{
    public string Id { get; }
    internal int Dinero { get; set; }

    private Hand? _hand;
    internal Hand Hand
    {
        get
        {
            if (_hand is  null)
            {
                throw new Exception("IDK");
            }
            else
            {
                return _hand;
            }

        }
        set
        {
            _hand = value;
        }
    }
    public abstract IDecision parse_decision(Contexto contexto);
    protected Player(string id, int dinero)
    {
        Id = id;
        Dinero = dinero;
    }
}