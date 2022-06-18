namespace MiddleStagePhonePK.App.Models;

public record Phone(
    string ID,
    string Name,
    string Description
);

public record PhoneQueryContentType(
     string? Id,
     PhoneGraphDataType? Data
): SquidexQueryContentType<PhoneGraphDataType>(Id, Data);

public record PhoneGraphDataType(
    SquidexI18NType? Name,
    SquidexI18NType? Description
); 
