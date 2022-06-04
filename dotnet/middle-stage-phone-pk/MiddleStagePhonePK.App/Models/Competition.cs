namespace MiddleStagePhonePK.App.Models;

public record Competition(
    string ID,
    DateTime Date,
    IEnumerable<string> Participants,
    string Challenge,
    IEnumerable<string> Winners
);
