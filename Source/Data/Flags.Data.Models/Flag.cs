namespace Flags.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Constants;

    public class Flag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.FlagNameMinLength, ErrorMessage = ValidationConstants.FlagNameMinLengthErrorMessage)]
        [MaxLength(ValidationConstants.FlagNameMaxLength, ErrorMessage = ValidationConstants.FlagNameMaxLengthErrorMessage)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.FlagImagePathMinLength, ErrorMessage = ValidationConstants.FlagImagePathMinLengthErrorMessage)]
        [MaxLength(ValidationConstants.FlagImagePathMaxLength, ErrorMessage = ValidationConstants.FlagImagePathMaxLengthErrorMessage)]
        public string ImagePath { get; set; }
    }
}
