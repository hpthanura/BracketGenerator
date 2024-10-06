// See https://aka.ms/new-console-template for more information

using BracketGenerator.Models;
using BracketGenerator.Services;
using BracketGenerator.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

/*
Console.WriteLine("Hello, World!");
TeamService teamService = new TeamService();
TournamentService tournamentService = new TournamentService(teamService);
GroupMatchService groupMatchService = new GroupMatchService(teamService, tournamentService);

//List<Team> teams = teamService.SeedTeams(64, 4);
tournamentService.StartTournament(64, 4);
Console.WriteLine(tournamentService.GetTournamentWinner()?.Name + " is the Tournament Winner!");
foreach (var round in tournamentService.Rounds)
{
    Console.WriteLine(round.Name);
    foreach (var match in round.Matches)
    {
        Console.WriteLine("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name);
    }
    Console.WriteLine();
}

Console.WriteLine("Winning matches for Team " + tournamentService.GetTournamentWinner()?.Name);
foreach (var match in tournamentService.PathToVictory())
{
    Console.WriteLine("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name);
}

Console.WriteLine("*************Group Matches*************");
groupMatchService.InitiateGroupMatches(32, 4);
foreach (var group in groupMatchService.GetGroupMatches())
{
    Console.WriteLine("Group Name - " + group.Item1.ToString());
    foreach (var match in group.Item2)
    {
        Console.WriteLine("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name);
    }
    
}

foreach (var group in groupMatchService.GetWinnersByGroup())
{
    Console.WriteLine("Group Name - " + group.Item1.ToString());
    foreach (var team in group.Item2)
    {
        Console.WriteLine("{0} with points {1} ", team.Name, team.Points);
    }

}



Console.ReadLine();

*/

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
