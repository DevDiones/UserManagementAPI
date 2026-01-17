using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Data
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateOnly dateValue)
            {
                // Date should not be in the future
                if (dateValue > DateOnly.FromDateTime(DateTime.Now))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
