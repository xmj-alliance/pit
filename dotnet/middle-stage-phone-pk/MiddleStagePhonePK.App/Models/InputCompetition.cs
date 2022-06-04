namespace MiddleStagePhonePK.App.Models;

public record InputCompetition(
    string? ID,
    DateTime? Date,
    IEnumerable<string> Participants,
    string Challenge,
    IEnumerable<string> Winners
);
