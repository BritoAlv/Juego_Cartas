namespace Poker;
/// <summary>
/// This class represent the Context that a player may use to determine its decision. From the Player point the Context
/// is an immutable object.
/// </summary>
public class Global_Contexto : IGlobal_Contexto
{
    public Global_Contexto(Ronda_Context ronda_Context, params Player[] players)
    {
        Players = players;
        Ronda_Context = ronda_Context;
        Active_Players = Players.ToList();
    }
    public IEnumerable<Player> Players { get; }
    private Ronda_Context Ronda_Context { get; }
    public Bet Apuestas
    {
        get
        {
            return Ronda_Context.Apuestas;
        }
        set
        {
            Ronda_Context.Apuestas = value;
        }
    }
    public List<Player> Active_Players { get; set; }
    public List<Mini_Ronda_Contexto> Contextos => Ronda_Context.Contextos;
    public CardManager CardsManager
    {
        get
        {
            return Ronda_Context.CardsManager;
        }
        set
        {
            Ronda_Context.CardsManager = value;
        }
    }
    public void Config()
    {
        this.Apuestas = new Bet(this.Active_Players);
        this.CardsManager = new CardManager(this.Active_Players);
    }
}