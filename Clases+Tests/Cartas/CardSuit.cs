using NeoSmart.Unicode;
/*
Enums have default values.
*/
namespace Poker;
public enum CardSuit
{
    CorazónRojo,
    Pica,
    Trébol,
    Diamante,
}

internal static class tool
{
    public static NeoSmart.Unicode.SingleEmoji GetEmoji(this CardSuit suit)
    {
        switch (suit)
        {
            case CardSuit.CorazónRojo:
                return Emoji.RedHeart;
            case CardSuit.Diamante:
                return Emoji.DiamondSuit;
            case CardSuit.Trébol:
                return Emoji.SpadeSuit;
            default:
                return Emoji.ClubSuit;
        }
    }
}