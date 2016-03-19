namespace Flags.Data.Common.Constants
{
    public class ValidationConstants
    {
        // Flag
        public const int FlagNameMinLength = 1;
        public const int FlagNameMaxLength = 250;
        public const string FlagNameMinLengthErrorMessage = "Flag Name cannot be less than 1 character long";
        public const string FlagNameMaxLengthErrorMessage = "Flag Name cannot be longer than 250 characters long";

        public const int FlagImagePathMinLength = 1;
        public const int FlagImagePathMaxLength = 350;
        public const string FlagImagePathMinLengthErrorMessage = "Flag ImagePath cannot be less than 1 character long";
        public const string FlagImagePathMaxLengthErrorMessage = "Flag ImagePath cannot be longer than 350 characters long";

        // Score
        public const int ScorePlayerNameMinLength = 2;
        public const int ScorePlayerNameMaxLength = 120;
        public const string ScorePlayerNameMinLengthErrorMessage = "ScorePlayerName cannot be less than 2 character long";
        public const string ScorePlayerNameMaxLengthErrorMessage = "ScorePlayerName cannot be longer than 120 characters long";

        public const int ScoreValueMinLength = -200000;
        public const int ScoreValueMaxLength = 200000;
        public const string ScoreValueLengthErrorMessage = "ScoreValue cannot be a number less than -200 000 or greater than 200 000";
        public const string ScoreDateCreatedErrorMessage = "Score DateCreated must be of type \"DateTime\"";
    }
}