namespace QuickBite.Domain.Common.Errors;

using ErrorOr;

public partial class Errors
{
    public class User
    {
        public static Error DuplicateEmail => Error.Validation(
            code: "User.DuplicateEmail",
            description: "User already exist!"
        );

        public static Error NotExist => Error.Failure(
            code: "User.NotExist",
            description: "User doesn't exist!"
        );
    }
}