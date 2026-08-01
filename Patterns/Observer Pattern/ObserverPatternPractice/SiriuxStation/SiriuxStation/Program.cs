// See https://aka.ms/new-console-template for more information

using SiriuxStation.Entities;
using SiriuxStation.Observers;
using SiriuxStation.Subject;

Console.WriteLine("Hello, World!");



IContent musicContent = new MusicContent("Title", "Album", "Summary");

ISubject musicStation = new MusicStation();

IObserver radioMirchi = new RadioMirchiStation(musicStation);

musicStation.StateChanged(musicContent);


