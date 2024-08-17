using SpotifyWeb;

namespace Odyssey.MusicMatcher.SDL.Types;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public class Playlist
{
    private List<Track>? _tracks;


    public string Id { get; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public async Task<List<Track>> Tracks(SpotifyService spotifyService)
    {
        if (_tracks == null)
        {
            var response = await spotifyService.GetPlaylistsTracksAsync(this.Id);
            return response.Items.Select(item => new Track(item.Track)).ToList();
        }
        else
        {
            return _tracks;
        }
    }

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public Playlist(SpotifyWeb.Playlist playlist)
    {
        Id = playlist.Id;
        Name = playlist.Name;
        Description = playlist.Description;

        var paginatedTracks = playlist.Tracks.Items;
        _tracks = paginatedTracks.Select(item => new Track(item.Track)).ToList();
    }
}
