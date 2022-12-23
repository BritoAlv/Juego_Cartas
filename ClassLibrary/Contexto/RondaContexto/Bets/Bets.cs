namespace Poker;
public class Bet
{
    /// <summary>
    /// This holds the information about the Bets in each round.
    /// </summary>
    /// <param name="participants"></param>
    internal Bet(IEnumerable<Player> participants)
    {
        Bets = new Dictionary<Ideable, List<int>>();
        foreach (var participant in participants)
        {
            Bets[participant] = new List<int>();
        }
    }
    /*
    To each player (id) I assign in a List all the bets it does in a List, last element of the list,
    is the last element he bets.
    */
    public Dictionary<Ideable, List<int>> Bets { get; private set; }
    internal void Apostar(Player A, int dinero)
    {
        A.Dinero -= dinero;
        Bets[A].Add(dinero);
    }
    internal void Pasar(Player A)
    {
        Apostar(A, 0);
    }
    internal List<int> this[Ideable index]
    {
        get { return Bets[index]; }
    }
    public int Get_Dinero_Apostado(Ideable A)
    {
        return Bets[A].Sum();
    }
    public int Get_Last_Apuesta(Ideable A)
    {
        return Bets[A].Last();
    }
    public int Get_Dinero_Total_Apostado()
    {
        return Bets.Values.Aggregate(0, (actual, next) => actual + next.Sum());
        // other way of do the same process. 
        // return Bets.Values.Select(x => x.Sum()).Sum();
    }

    public int Get_Max_Apuesta()
    {
        IEnumerable<List<int>> result = Bets.Values.Where(x => x.Count > 0);
        if (result.Count() == 0)
        {
            return 0;
        }
        return result.Select(x => x.Max()).Max();
    }

    public int Get_Max_Sum_Apuesta()
    {
        IEnumerable<List<int>> result = Bets.Values.Where(x => x.Count > 0);
        if (result.Count() == 0)
        {
            return 0;
        }
        return this.Bets.Keys.Select(x => this.Get_Dinero_Apostado(x)).Max();
    }
}