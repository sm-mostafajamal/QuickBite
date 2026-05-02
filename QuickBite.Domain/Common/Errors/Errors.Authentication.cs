using ErrorOr;

namespace QuickBite.Domain.Common.Errors;

public partial class Errors
{
    public class Authentication
    {
        public static Error WrongCredential => Error.Validation(
            code: "User.WrongCredential",
            description : "Incorrect password"
        );
    }
}