using SpotifyWeb;

namespace Odyssey.MusicMatcher.Types;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public class Playlist
{
    private List<Track>? _tracks;


    [ID, GraphQLDescription("The ID for the playlist.")]
    public string Id { get; }
    
    [GraphQLDescription("The name of the playlist.")]
    public string Name { get; set; }
    
    [GraphQLDescription("Describes the playlist, what to expect and entices the user to listen.")]
    public string? Description { get; set; }

    [GraphQLDescription("The playlist's tracks.")]
    public async Task<List<Track>> Tracks(SpotifyService spotifyService)
    {
        if(_tracks == null)
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
