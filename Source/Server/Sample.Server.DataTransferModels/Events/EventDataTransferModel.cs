namespace Sample.Server.DataTransferModels.Events
{
    using Common.Mappings.Contracts;
    using Countries;
    using Data.Common.Constants;
    using Data.Models.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class EventDataTransferModel : IMapFrom<Event> , IHaveCustomMappings
    {
        [Required]
        public string Country { get; set; }

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

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Event, EventDataTransferModel>()
                .ForMember(c => c.Country, opt => opt.MapFrom(c => c.Country.Name));
        }
    }
}