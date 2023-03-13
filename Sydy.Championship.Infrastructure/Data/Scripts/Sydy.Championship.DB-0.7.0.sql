-- Get the result of the matches
CREATE VIEW VwChampionshipResults
AS
SELECT Match.Id, Championship.Id as ChampionshipId, CONCAT(FirstTeam.Name, ' x ', SecondTeam.Name) as Teams,
	CONCAT(Match.FirstTeamGoals, ' x ', Match.SecondTeamGoals) as Results, Match.Date
FROM Championship
	LEFT JOIN Match
	ON Championship.Id = Match.ChampionshipId
	INNER JOIN Team FirstTeam
	ON Match.FirstTeamId = FirstTeam.Id
	INNER JOIN Team SecondTeam
	ON Match.SecondTeamId = SecondTeam.Id
GO