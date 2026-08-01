using SiriuxStation.Entities;
using SiriuxStation.Subject;

namespace SiriuxStation.Observers;

public class RadioMirchiStation: IObserver
{
    private readonly ISubject _subject;

    public RadioMirchiStation(ISubject subject)
    {
        _subject = subject;
        _subject.RegisterObserver(this);
    }

    public void Update(IContent content)
    {
        Console.WriteLine(content.ToString());
    }

    public void PullLatestContent()
    {
        var updatedContent = _subject.PullLatestInformation();
        Console.WriteLine(updatedContent.ToString());
    }
}