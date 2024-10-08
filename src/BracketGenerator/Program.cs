// See https://aka.ms/new-console-template for more information

using BracketGenerator.Models;
using BracketGenerator.Services;
using BracketGenerator.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<IApplication, Application>();
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ITournamentService, TournamentService>();
        services.AddScoped<IEliminationMatchService, EliminationMatchService>();
        services.AddScoped<IGroupMatchService, GroupMatchService>();
    })
    .Build();

var app = _host.Services.GetRequiredService<IApplication>();
app.Main();
