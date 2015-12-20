namespace Sample.Server.DataTransferModels.Events
{
    using Common.Mappings.Contracts;
    using Data.Common.Constants;
    using Data.Models.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventDataTransferModel : IMapFrom<Event>
    {
        [Required]
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
        public DateTime StartDate
        {
            get { return this.StartDate; }
            set
            {
                if (DateTime.Compare(value, DateTime.UtcNow) >= 0)
                {
                    this.StartDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(ValidationConstants.EventStartDateExceptionMessage);
                }
            }
        }

        [Required]
        public DateTime EndDate
        {
            get { return this.EndDate; }
            set
            {
                if (DateTime.Compare(value, this.StartDate) > 0)
                {
                    this.EndDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(ValidationConstants.EventEndDateExceptionMessage);
                }
            }
        }
    }
}