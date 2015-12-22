namespace Sample.Data.Common.Constants
{
    public class ValidationConstants
    {
        // Sample
        public const int SampleDescriptionMaxLength = 180;
        public const int SampleDescriptionMinLength = 10;
        public const string SampleDescriptionLengthErrorMessage = "Sample description must have length between 10 and 180 chars inclusive.";

        // Country
        public const int CountryNameMaxLength = 100;
        public const int CountryNameMinLength = 2;
        public const string CountryNameMinLengthErrorMessage = "Country name cannot be less than 2 characters.";
        public const string CountryNameMaxLengthErrorMessage = "Country name cannot exceed 100 characters.";

        public const int CountryCodeLength = 2;
        public const string CountryCodeLengthErrorMessage = "Country code must contain only 2 characters";

        // Event
        public const int DescriptionMaxLength = 360;
        public const int DescriptionMinLength = 10;
        public const string DescriptionMinLengthErrorMessage = "Event description cannot be less than 10 characters.";
        public const string DescriptionMaxLengthErrorMessage = "Event description cannot exceed 360 characters.";

        public const int HostMaxLength = 150;
        public const int HostMinLength = 2;
        public const string HostMinLengthErrorMessage = "Event host cannot be less than 2 characters.";
        public const string HostMaxLengthErrorMessage = "Event host cannot exceed 150 characters.";

        public const string EventStartDateExceptionMessage = "Event StartDate cannot be set to a date earlier than today.";
        public const string EventEndDateExceptionMessage = "Event EndDate cannot be set to date earlier than Event StartDate.";

        public const int EventInsertionFailed = -1;
        // User
        public const int UserDisplayNameMaxLength = 50;
        public const int UserDisplayNameMinLength = 3;
        public const string UserDisplayNameMaxLengthErrorMessage = "DisplayName cannot exceed 50 characters.";
        public const string UserDisplayNameMinLengthErrorMessage = "DisplayName cannot be less than 3 characters.";

        public const int UserEmailMaxLength = 50;
        public const int UserEmailMinLength = 3;
        public const string UserEmailMaxLengthErrorMessage = "Email Max length cannot exceed 50 characters.";
        public const string UserEmailMinLengthErrorMessage = "Email Min length cannot be less than 3 characters.";

        // AccountController
        public const string CannotFindAuthenticatedUserErrorMessage = "GetIdentity() method should never return NULL object, because it requires user authentication to be called in the first place. If a user is authenticated but not found in the database - we have major security problem.";
    }
}