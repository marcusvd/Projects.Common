
namespace Projects.Common.Validations;

using System.Text.RegularExpressions;
using Projects.Common.Validations.Exceptions.Global;


public class EmailAssertionConcern
{
    public static void AssertIsValid(string email)
    {
        if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            throw new Exception(Errors.InvalidEmail);
    }
}