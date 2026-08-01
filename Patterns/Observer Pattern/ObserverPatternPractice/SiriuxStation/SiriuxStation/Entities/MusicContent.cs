namespace SiriuxStation.Entities;

public class MusicContent: IContent
{
    public MusicContent(string songTitle, string album, string artist)
    {
        SongTitle = songTitle;
        Album = album;
        Artist = artist;
    }

    public string SongTitle { get; set; }
    public string Album { get; set; }
    public string Artist { get; set; }

    public override string ToString()
    {
        return $"{SongTitle} -- {Artist} -- {Album}";
    }
}