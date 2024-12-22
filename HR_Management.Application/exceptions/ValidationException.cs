using FluentValidation.Results;

namespace HR_Management.Application.exceptions;

public class ValidationException : ApplicationException
{
    public List<string>? ErrorList { get; set; } = new List<string>();

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            ErrorList.Add(error.ErrorMessage);
        }
    }
}