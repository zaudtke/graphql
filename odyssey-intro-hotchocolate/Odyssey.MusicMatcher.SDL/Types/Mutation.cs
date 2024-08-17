using SpotifyWeb;

namespace Odyssey.MusicMatcher.SDL.Types;

public class Mutation
{
    public async Task<AddItemsToPlaylistPayload> AddItemsToPlaylist(AddItemsToPlaylistInput input, SpotifyService spotifyService)
    {
        try
        {
            var snapshotId = await spotifyService.AddTracksToPlaylistAsync(input.PlaylistId, null, string.Join(",", input.Uris));

            var response = await spotifyService.GetPlaylistAsync(input.PlaylistId);
            var playlist = new Playlist(response);

            return new AddItemsToPlaylistPayload(200, true, "Successfully added items to playlist.", playlist);
        }
        catch (Exception ex)
        {
            return new AddItemsToPlaylistPayload(500, false, ex.Message, null);
        }
    }
}
