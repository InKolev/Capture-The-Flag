namespace Flags.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Constants;

    public class Score
    {
        public Score()
        {
            this.DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.ScorePlayerNameMinLength, ErrorMessage = ValidationConstants.ScorePlayerNameMinLengthErrorMessage)]
        [MaxLength(ValidationConstants.ScorePlayerNameMaxLength, ErrorMessage = ValidationConstants.ScorePlayerNameMaxLengthErrorMessage)]
        public string PlayerName { get; set; }

        [Required]
        [Range(ValidationConstants.ScoreValueMinLength, ValidationConstants.ScoreValueMaxLength, ErrorMessage = ValidationConstants.ScoreValueLengthErrorMessage)]
        public int Value { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = ValidationConstants.ScoreDateCreatedErrorMessage)]
        public DateTime DateCreated { get; set; }
    }
}