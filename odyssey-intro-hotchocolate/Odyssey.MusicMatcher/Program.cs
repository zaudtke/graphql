using Odyssey.MusicMatcher.Types;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://studio.apollographql.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient<SpotifyService>();


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()

    .AddMutationType<Mutation>()
    .RegisterService<SpotifyService>();

var app = builder.Build();
app.UseCors();
app.MapGraphQL();

app.Run();
