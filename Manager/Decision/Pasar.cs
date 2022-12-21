namespace Poker;

public interface IPasable{

}
internal class Pasar : IDecision
{
    public Pasar()
    {
    }

    public string Id => "Pasar";

    public string Help => "No puedes pasar el primer turno";

    public bool DoDecision(Player player, Contexto contexto)
    { 
        if (contexto.Apuestas.Get_Dinero_Apostado(player)==0) return false;
        contexto.Apuestas.Pasar(player);
        Tools.ShowColoredMessage($"{player.Id} pasó su turno \n", ConsoleColor.Yellow);
        return true;
    }
}