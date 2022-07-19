namespace Mota.Game.Languages;

public class TextWithLan : ICloneable
{
    public Dictionary<ELanguages, string> Texts;
    
    public TextWithLan()
    {
        Texts = new Dictionary<ELanguages, string>();
    }
    
    public object Clone()
    {
        var obj = new TextWithLan
        {
            Texts = new Dictionary<ELanguages, string>(Texts)
        };
        
        return obj;
    }

    public override string ToString()
    {
        return LanguageConsole.GetText(this);
    }

    public override bool Equals(object obj)
    {
        return ToString() == obj.ToString();
    }

    protected bool Equals(TextWithLan other)
    {
        return Equals(Texts, other.Texts);
    }

    public override int GetHashCode()
    {
        return Texts != null ? Texts.GetHashCode() : 0;
    }

    public char ToChar()
    {
        return Convert.ToChar(ToString());
    }
}