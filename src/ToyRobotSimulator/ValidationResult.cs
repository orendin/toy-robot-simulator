using System.ComponentModel.DataAnnotations;

namespace ToyRobotSimulator
{
    public struct ValidationResult
    {
        public bool IsValid { get; set; }
        public string? ValidationError { get; set; }

        private ValidationResult(bool success, string? validationError)
        {
            this.IsValid = success;
            ValidationError = validationError;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, null);
        }

        public static ValidationResult Failure(string validationError)
        {
            return new ValidationResult(false, validationError);
        }

        public override string? ToString()
        {
            return IsValid ? null : ValidationError;
        }
    }
}