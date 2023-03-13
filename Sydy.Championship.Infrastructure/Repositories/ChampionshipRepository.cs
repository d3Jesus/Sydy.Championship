using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.CoreBusiness.Helpers;
using Sydy.Championship.CoreBusiness.Interfaces;
using Sydy.Championship.Infrastructure.Data;

namespace Sydy.Championship.Infrastructure.Repositories
{
    public class ChampionshipRepository : IChampionshipRepository
    {
        private readonly ChampionshipDbContext _context;
        private readonly ITeamRepository _teamRepository;

        public ChampionshipRepository(ChampionshipDbContext context, ITeamRepository teamRepository)
        {
            _context = context;
            _teamRepository = teamRepository;
        }
        public async Task<string> AddAsync(ChampionshipModel championship)
        {
            try
            {
                #region Checks if there are two or more registered teams
                var teams = await _teamRepository.GetAsync();

                if (teams is null)
                    return "Register at least two teams.";
                #endregion

                #region Register Championship
                var championshipModel = new ChampionshipModel
                {
                    Name = championship.Name,
                    Year = DateTime.Now.Year,
                    Champion = string.Empty,
                    Vice = string.Empty,
                    ThirdPlace = string.Empty
                };
                _context.Championships.Add(championshipModel);
                _context.SaveChanges();
                #endregion

                await StartChampionship(teams, championshipModel.Id);
                //await StartChampionship(teams, 3);

                return "Championship created successfuly and starded!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<ChampionshipModel>> GetChampionshipAsync()
        {
            return await _context.Championships
                .Include(x => x.Matches)
                .Select(x => new ChampionshipModel
                {
                    Name = x.Name,
                    Year = x.Year,
                    Champion = string.IsNullOrEmpty(x.Champion) ? "NOT AVAILABLE" : x.Champion,
                    Vice = string.IsNullOrEmpty(x.Vice) ? "NOT AVAILABLE" : x.Vice,
                    ThirdPlace = string.IsNullOrEmpty(x.ThirdPlace) ? "NOT AVAILABLE" : x.ThirdPlace,
                    MatchesResult = x.MatchesResult
                })
                .ToListAsync();
        }

        private static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next(0, 11);
        }

        private async Task StartChampionship(IEnumerable<TeamModel> teams, int championshipId)
        {
            List<Billboard> billboard = new();

            var listOfTeams = teams.ToList();
            var numberOfTeams = listOfTeams.Count;
            //listOfTeams.RemoveAt(numberOfTeams - 1);

            var listOfOpponents = teams.ToList();

            for (int i = 0; i < numberOfTeams; i++)
            {
                var team = listOfTeams[i];

                int matchesMade = 1;
                while (matchesMade < listOfOpponents.Count)
                {
                    var opponent = listOfOpponents[matchesMade];

                    MatchModel match = new()
                    {
                        FirstTeamId = team.Id,
                        FirstTeamGoals = GetRandomNumber(),
                        SecondTeamId = opponent.Id,
                        SecondTeamGoals = GetRandomNumber(),
                        Date = DateTime.Now,
                        ChampionshipId = championshipId
                    };

                    _context.Matches.Add(match);
                    _context.SaveChanges();

                    SetScores(match, billboard);
                    matchesMade++;
                }
                listOfOpponents.RemoveAt(0);
            }

            await SetWinners(billboard, championshipId);
        }

        private async Task SetWinners(List<Billboard> billboard, int championshipId)
        {
            billboard = billboard.OrderByDescending(x => x.Score).ToList();

            string firstPlace = _teamRepository.GetByIdAsync(billboard.ElementAt(0).TeamId).Result.Name;
            string secondPlace = _teamRepository.GetByIdAsync(billboard.ElementAt(1).TeamId).Result.Name;
            string thirdPlace = _teamRepository.GetByIdAsync(billboard.ElementAt(2).TeamId).Result.Name;

            var championship = await GetChampionshipByIdAsync(championshipId);
            championship.Champion = firstPlace;
            championship.Vice = secondPlace;
            championship.ThirdPlace = thirdPlace;

            if (championship is not null) UpdateChampionship(championship);
        }

        private async Task<ChampionshipModel?> GetChampionshipByIdAsync(int championshipId)
        {
            return await _context.Championships.FindAsync(championshipId);
        }

        private void UpdateChampionship(ChampionshipModel championship)
        {
            _context.Championships.Update(championship);
            _context.SaveChanges();
        }

        private static void SetScores(MatchModel match, List<Billboard> scores)
        {
            if (match.FirstTeamGoals == match.SecondTeamGoals)
            {
                var firstScore = scores.Where(sc => sc.TeamId == match.FirstTeamId).FirstOrDefault();
                if (firstScore is null)
                    AddToScore(scores, match.FirstTeamId, MatchScoreHelper.TIE);
                else
                    UpdateScore(scores, match.FirstTeamId, MatchScoreHelper.TIE);

                var secondScore = scores.Where(sc => sc.TeamId == match.SecondTeamId).FirstOrDefault();
                if (secondScore is null)
                    AddToScore(scores, match.SecondTeamId, MatchScoreHelper.TIE);
                else
                    UpdateScore(scores, match.SecondTeamId, MatchScoreHelper.TIE);
            }
            if (match.FirstTeamGoals > match.SecondTeamGoals)
            {
                var firstScore = scores.Where(sc => sc.TeamId == match.FirstTeamId).FirstOrDefault();
                if (firstScore is null)
                    AddToScore(scores, match.FirstTeamId, MatchScoreHelper.VICTORY);
                else
                    UpdateScore(scores, match.FirstTeamId, MatchScoreHelper.VICTORY);

                var secondScore = scores.Where(sc => sc.TeamId == match.SecondTeamId).FirstOrDefault();
                if (secondScore is null)
                    AddToScore(scores, match.SecondTeamId, MatchScoreHelper.DEFEAT);
                else
                    UpdateScore(scores, match.SecondTeamId, MatchScoreHelper.DEFEAT);
            }
            if (match.FirstTeamGoals < match.SecondTeamGoals)
            {
                var firstScore = scores.Where(sc => sc.TeamId == match.FirstTeamId).FirstOrDefault();
                if (firstScore is null)
                    AddToScore(scores, match.FirstTeamId, MatchScoreHelper.DEFEAT);
                else
                    UpdateScore(scores, match.FirstTeamId, MatchScoreHelper.DEFEAT);

                var secondScore = scores.Where(sc => sc.TeamId == match.SecondTeamId).FirstOrDefault();
                if (secondScore is null)
                    AddToScore(scores, match.SecondTeamId, MatchScoreHelper.VICTORY);
                else
                    UpdateScore(scores, match.SecondTeamId, MatchScoreHelper.VICTORY);
            }
        }

        public static void AddToScore(List<Billboard> matchScores, int teamId, int score)
        {
            matchScores.Add(new Billboard
            {
                TeamId = teamId,
                Score = score
            });
        }

        public static void UpdateScore(List<Billboard> matchScores, int teamId, int score)
        {
            matchScores.Where(sc => sc.TeamId == teamId).ToList().ForEach(sc => sc.Score += score);
        }
    }
}
