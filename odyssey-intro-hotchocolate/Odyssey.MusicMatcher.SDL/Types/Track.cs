using SpotifyWeb;

namespace Odyssey.MusicMatcher.SDL.Types;

public class Track
{
    public string Id { get; }

    public string Name { get; set; }

    public double DurationMs { get; set; }

    public bool Explicit { get; set; }

    public string Uri { get; set; }

    public Track(string id, string name, string uri)
    {
        Id = id;
        Name = name;
        Uri = uri;
    }

    public Track(PlaylistTrackItem item)
    {
        Id = item.Id;
        Name = item.Name;
        Uri = item.Uri;
        DurationMs = item.Duration_ms;
        Explicit = item.Explicit;
    }
}
