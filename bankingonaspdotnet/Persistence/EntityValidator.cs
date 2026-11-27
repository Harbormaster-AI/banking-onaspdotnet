using System.ComponentModel.DataAnnotations;

namespace bankingonaspdotnet.Persistence;

public static class EntityValidator
{
    public static void Validate<T>(T entity) where T : class
    {
        Validator.ValidateObject(
            entity,
            new ValidationContext(entity),
            validateAllProperties: true
        );
    }
}