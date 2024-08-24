
using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Recipe
{
    [ID, HotChocolate.ApolloFederation.Types.Key]
    public string Id { get; }
    
    [External]
    public string? Name { get; }
    public Recipe(string id, string? name)
    {
        Id = id;
        if (name is not null)
        {
            Name = name;
        }
    }
    
    [ReferenceResolver]
    public static Recipe GetRecipeById(string id, string name)
    {
        return new Recipe(id, name);
    }

    [Requires("name")]
    [GraphQLDescription("A list of recommended playlists for this particular recipe.  Returns 1 to 3 playlists.")]
    public async Task<List<Playlist>> RecommendedPlaylists(SpotifyService spotifyService)
    {
        var response =
            await spotifyService.SearchAsync(this.Name, new List<SearchType> { SearchType.Playlist }, 3, 0, null);

        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }
}