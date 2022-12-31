namespace Poker;
public abstract class Return<T> : IArgument<T>, Iprintable
{
    protected Return(Token open_parenthesis, Token signature, Token closed_parenthesis)
    {
        Open_Parenthesis = open_parenthesis;
        Signature = signature;
        Closed_Parenthesis = closed_parenthesis;
    }
    public Token Open_Parenthesis { get; }
    public Token Signature { get; }
    public Token Closed_Parenthesis { get; }
    public string valor => "Acción " + Signature.Text;
    public abstract IEnumerable<Iprintable> GetChildrenIprintables();
    public abstract T Evaluate(IGlobal_Contexto contexto);
    public T Get_Object(IEnumerable<T> list, IGlobal_Contexto contexto)
    {
        return Evaluate(contexto);
    }
}

