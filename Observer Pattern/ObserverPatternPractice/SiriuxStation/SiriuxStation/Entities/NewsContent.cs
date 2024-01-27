namespace SiriuxStation.Entities;

public class NewContent: IContent
{
    public NewContent(string headline, string summary, string source)
    {
        Headline = headline;
        Summary = summary;
        Source = source;
    }

    public string Headline { get; set; }
    public string Summary { get; set; }
    public string Source { get; set; }
}