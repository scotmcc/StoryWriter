using Microsoft.EntityFrameworkCore;
using StoryWriter.Components;
using StoryWriter.Data;
using StoryWriter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<StoryWriterContext>(options =>
    options.UseSqlite("Data Source=storywriter.db"));

builder.Services.AddTransient<AIService>();
builder.Services.AddTransient<ChapterService>();
builder.Services.AddTransient<CharacterService>();
builder.Services.AddTransient<SceneService>();
builder.Services.AddTransient<ItemService>();
builder.Services.AddTransient<OllamaService>();
builder.Services.AddTransient<StoryService>();
builder.Services.AddTransient<LocationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
