namespace Odyssey.MusicMatcher.SDL.Types;

public class AddItemsToPlaylistInput
{
    public string PlaylistId { get; set; }

    public List<string> Uris { get; set; }


    public AddItemsToPlaylistInput(string playlistId, List<string> uris)
    {
        PlaylistId = playlistId;
        Uris = uris;
    }
}
