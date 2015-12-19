namespace Sample.Data.Common.Constants
{
    public class ValidationConstants
    {
        // Sample
        public const int SampleDescriptionMaxLength = 180;
        public const int SampleDescriptionMinLength = 10;
        public const string SampleDescriptionLengthErrorMessage = "Sample description must have length between 10 and 180 chars inclusive.";

        // User
        public const int UserDisplayNameMaxLength = 50;
        public const int UserDisplayNameMinLength = 3;
        public const string UserDisplayNameMaxLengthErrorMessage = "DisplayName Max length cannot exceed 50 characters.";
        public const string UserDisplayNameMinLengthErrorMessage = "DisplayName Min length cannot be less than 3 characters.";

        public const int UserEmailMaxLength = 50;
        public const int UserEmailMinLength = 3;
        public const string UserEmailMaxLengthErrorMessage = "Email Max length cannot exceed 50 characters.";
        public const string UserEmailMinLengthErrorMessage = "Email Min length cannot be less than 3 characters.";

        // AccountController
        public const string CannotFindAuthenticatedUserErrorMessage = "GetIdentity() method should never return NULL object, because it requires user authentication to be called in the first place. If a user is authenticated but not found in the database - we have major security problem.";
    }
}