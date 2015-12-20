namespace Sample.Server.DataTransferModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mappings.Contracts;
    using Data.Common.Constants;
    using Data.Models.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class UserDataTransferModel : IMapFrom<User>
    {
        [Required]
        [MaxLength(ValidationConstants.UserEmailMaxLength, ErrorMessage = ValidationConstants.UserEmailMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.UserEmailMinLength, ErrorMessage = ValidationConstants.UserEmailMinLengthErrorMessage)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserDisplayNameMaxLength, ErrorMessage = ValidationConstants.UserDisplayNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.UserDisplayNameMinLength, ErrorMessage = ValidationConstants.UserDisplayNameMinLengthErrorMessage)]
        public string DisplayName { get; set; }
    }
}