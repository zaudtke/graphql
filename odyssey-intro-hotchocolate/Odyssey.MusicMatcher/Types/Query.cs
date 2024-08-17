using SpotifyWeb;

namespace Odyssey.MusicMatcher.Types;

public class Query
{
    // where Query resolver functions go
    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();

        return response.Playlists.Items.Select(item => new Playlist(item.Id, item.Name) { Description = item.Description }).ToList();
    }

    [GraphQLDescription("Retrieves a specific playlist.")]
    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        return new Playlist(response);
    }
}
