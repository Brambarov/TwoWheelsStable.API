namespace api.Helpers
{
    public static class ErrorMessages
    {
        public const string RegistrationError = "Registration failed!";
        public const string LoginError = "Login failed!";
        public const string UserNameOrPasswordIncorrectError = "Username/password is incorrect!";
        public const string UnauthorizedError = "Unauthorized access!";
        public const string HttpConnectionError = "Http connection failed!";
        public const string ExternalApiError = "Error occured while calling an external API!";
        public const string UnexpectedError = "Unexpected error occurred!";
        public const string JWTSigningKeyError = "JWT Signing key exception!";
        public const string SoftDeletionError = "{0} deletion failed!";
        public const string TokenCreationError = "{0} token creation failed!";
        public const string EntityWithPropertyDoesNotExistError = "{0} with {1} {2} does not exist!";
        public const string PropertyIsInvalidError = "{0} {1} is invalid!";
        public const string NotFoundError = "{0} not found!";
        public const string NotFoundOnError = "{0} not found on {1}!";
    }
}
