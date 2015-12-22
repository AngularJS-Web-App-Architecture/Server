namespace Sample.Server.DataTransferModels.Countries
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mappings.Contracts;
    using Data.Common.Constants;
    using Data.Models.Models;
    using Newtonsoft.Json;

    public class CountryDataTransferModel : IMapFrom<Country>
    {
        [Required]
        [MinLength(ValidationConstants.CountryNameMinLength, ErrorMessage = ValidationConstants.CountryNameMinLengthErrorMessage)]
        [MaxLength(ValidationConstants.CountryNameMaxLength, ErrorMessage = ValidationConstants.CountryNameMaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}