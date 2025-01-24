public class Reference
{
    public string Text { get; set; }

    public Reference(string reference)
    {
        Text = reference;
    }

    public bool IsRange()
    {
        return Text.Contains("-");
    }
}
