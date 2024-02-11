using SiriuxStation.Entities;
using SiriuxStation.Observers;

namespace SiriuxStation.Subject;

public class MusicStation: ISubject
{
    private readonly IList<IObserver> _musicObservers = new List<IObserver>();
    
    
    // TODO: Check the possibility of refactoring this part
    private string _headline { get; set; }
    private string _summary { get; set; }
    private string _source { get; set; }
    
    
    public void RegisterObserver(IObserver observer)
    {
        if (_musicObservers.Any(o => o == observer)) throw new ArgumentException("Observer is already subscribed");
        _musicObservers.Add(observer);
    }

    public bool RemoveObserver(IObserver observer)
    {
        return _musicObservers.Remove(observer);
    }

    public void NotifyObserver(IContent content)
    {
        foreach (var observer in _musicObservers)
        {
            observer.Update(content);
        }
    }

    public IContent PullLatestInformation()
    {
        return new NewsContent(_headline, _summary, _source);
    }

    public void StateChanged(IContent content)
    {
        if (content is not MusicContent musicContent) throw new ArgumentException("Content is not type of music content");
        _headline = musicContent.SongTitle;
        _source = musicContent.Album;
        _summary = musicContent.Artist;
        var newsContent = new MusicContent(_headline, _source, _summary);
        NotifyObserver(newsContent);
    }
}