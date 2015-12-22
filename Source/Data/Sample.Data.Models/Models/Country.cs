namespace Sample.Data.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class Country
    {
        private HashSet<Event> events;

        public Country()
        {
            this.events = new HashSet<Event>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.CountryNameMinLength, ErrorMessage = ValidationConstants.CountryNameMinLengthErrorMessage)]
        [MaxLength(ValidationConstants.CountryNameMaxLength, ErrorMessage = ValidationConstants.CountryNameMaxLengthErrorMessage)]
        [JsonProperty]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.CountryCodeLength, ErrorMessage = ValidationConstants.CountryCodeLengthErrorMessage)]
        [MaxLength(ValidationConstants.CountryCodeLength, ErrorMessage = ValidationConstants.CountryCodeLengthErrorMessage)]
        [JsonProperty]
        public string Code { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = (HashSet<Event>)value; }
        }
    }
}