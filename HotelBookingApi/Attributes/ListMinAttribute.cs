using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Attributes
{
    public class ListMinAttribute : ValidationAttribute
    {
        public long Min { get; set; }
        public ListMinAttribute(long min, string ErrorMessage) : base(ErrorMessage)
        {
            Min = min;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<long> values = (List<long>)value;
            foreach (long v in values)
            {
                if (v < Min)
                    return new ValidationResult(string.IsNullOrWhiteSpace(ErrorMessage) ? $"value must be greater than or equal to {Min}" : ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
