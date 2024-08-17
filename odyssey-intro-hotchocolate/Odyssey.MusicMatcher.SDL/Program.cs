using Odyssey.MusicMatcher.SDL.Types;
using SpotifyWeb;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SpotifyService>();

var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Types\schema.graphql";

builder.Services.AddGraphQLServer()
    .AddDocumentFromFile(path)
    .BindRuntimeType<Query>()
    .BindRuntimeType<Mutation>()
    .RegisterService<SpotifyService>();

var app = builder.Build();
app.MapGraphQL();

app.Run();


