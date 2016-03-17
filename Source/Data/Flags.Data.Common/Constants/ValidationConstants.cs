namespace Flags.Data.Common.Constants
{
    public class ValidationConstants
    {
        // Flags
        public const int FlagNameMinLength = 1;
        public const int FlagNameMaxLength = 250;
        public const string FlagNameMinLengthErrorMessage = "Flag Name cannot be less than 1 character long";
        public const string FlagNameMaxLengthErrorMessage = "Flag Name cannot be longer than 250 characters long";

        public const int FlagImagePathMinLength = 1;
        public const int FlagImagePathMaxLength = 350;
        public const string FlagImagePathMinLengthErrorMessage = "Flag ImagePath cannot be less than 1 character long";
        public const string FlagImagePathMaxLengthErrorMessage = "Flag ImagePath cannot be longer than 350 characters long";
    }
}