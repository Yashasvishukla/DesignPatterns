using SiriuxStation.Entities;

namespace SiriuxStation.Observers;

public interface IObserver
{
    void Update(IContent content);
    void PullLatestContent();
}