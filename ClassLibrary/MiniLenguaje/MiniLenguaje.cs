namespace Poker;
public class Mini_Lenguaje
{
    internal Mini_Lenguaje(Player A, IGlobal_Contexto contexto)
    {
        Contexto = contexto;
    }
    private IGlobal_Contexto Contexto { get; }
    public void Evaluate(string? line)
    {
        // check if user is on the clouds
        if (string.IsNullOrEmpty(line))
        {
            return;
        }
        // get tokens from the string.
        Lexer lexer = new Lexer(line);
        List<Token> tokens = lexer.Lex();
        Parser parser = new Parser(tokens);
        var signature = tokens[1].Text;
        var tree = Factory.CreateAction(tokens[1].Text, parser);
        print_tree.print((Iprintable)tree);
        try
        {
            if ( ((IFirst)tree).Evaluate_Top(Contexto))
            {
                Console.WriteLine("El efecto se pudo realizar sin problemas");
            }
            else
            {
                Console.WriteLine("Hubo un problema con el efecto");
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Hubo un problema con el efecto");
        }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.ResetColor();
    }
}

