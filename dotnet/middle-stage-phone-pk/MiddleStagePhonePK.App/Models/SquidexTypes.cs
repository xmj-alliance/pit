namespace MiddleStagePhonePK.App.Models;

public record SquidexQueryContentType<T>(
    string? Id,
    T? Data
);

public record SquidexI18NType(
     string? En
);
