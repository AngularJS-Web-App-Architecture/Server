namespace Sample.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.DescriptionMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.DescriptionMinLengthErrorMessage)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ValidationConstants.HostMaxLength, ErrorMessage = ValidationConstants.HostMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.HostMinLength, ErrorMessage = ValidationConstants.HostMinLengthErrorMessage)]
        public string Host { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}