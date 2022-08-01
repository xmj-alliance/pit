using MiddleStagePhonePK.App.Models.Squidex;

namespace MiddleStagePhonePK.App.Models;

public record Phone(
    string ID,
    string Name,
    string Description
);

public record PhoneQueryContentType(
    string Id,
    int Version,
    DateTime Created,
    string CreatedBy,
    PhoneGraphDataType? Data
): SquidexContent<PhoneGraphDataType>(Id, Version, Created, CreatedBy, Data);

public record PhoneGraphDataType(
    SquidexI18NDto Name,
    SquidexI18NDto Description
); 
