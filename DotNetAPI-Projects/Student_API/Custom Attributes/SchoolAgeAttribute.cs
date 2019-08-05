using System;
using System.ComponentModel.DataAnnotations;


namespace Student_API.CustomAttributes
{
    public class SchoolAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        private int _maxAge;

        public SchoolAgeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthdate = (DateTime)value;
            int age = DateTime.Now.Year - birthdate.Year;
            if (age < _minAge && age <= _maxAge)
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return $"The student must be between the ages of {_minAge} and {_maxAge}.";
        }
    }
}
