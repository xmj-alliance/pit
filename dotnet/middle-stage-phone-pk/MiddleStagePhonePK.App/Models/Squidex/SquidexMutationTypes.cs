namespace MiddleStagePhonePK.App.Models.Squidex;

public record SquidexMutationTypes(
    PhoneQueryContentType? CreatePhoneContent,
    PhoneQueryContentType? UpdatePhoneContent,
    SquidexEntitySavedResultDto? DeletePhoneContent
);
