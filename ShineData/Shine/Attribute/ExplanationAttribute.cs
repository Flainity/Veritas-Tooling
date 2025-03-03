namespace ShineData.Shine.Attribute;

public class ExplanationAttribute : System.Attribute
{
    public string Explanation { get; }
    
    public ExplanationAttribute(string explanation)
    {
        Explanation = explanation;
    }
}