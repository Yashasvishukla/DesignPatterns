using SiriuxStation.Entities;
using SiriuxStation.Observers;

namespace SiriuxStation.Subject;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    bool RemoveObserver(IObserver observer);
    void NotifyObserver(IContent content);
    IContent PullLatestInformation();
    
    void StateChanged(IContent content);
}