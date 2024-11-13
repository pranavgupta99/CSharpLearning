using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.UserInfoViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName Can't Be empty")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    //Different Anotations
    //[Required(ErrorMessage = "The field is required.")]

    //[StringLength(50, MinimumLength = 2, ErrorMessage = "The field must be between 2 and 50 characters.")]

    //[Range(1, 100, ErrorMessage = "The field must be between 1 and 100.")]

    //[RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "The field must contain only alphanumeric characters.")]

    //[EmailAddress(ErrorMessage = "Invalid email address.")]

    //[Compare("OtherPropertyName", ErrorMessage = "The field does not match.")]


    //DataType.Date: Represents a date value without a time component.
    //DataType.Time: Represents a time value without a date component.
    //DataType.DateTime: Represents a date and time value.
    //DataType.Duration: Represents a time interval or duration.
    //DataType.PhoneNumber: Represents a phone number.
    //DataType.Currency: Represents a currency value.
    //DataType.Text: Represents a plain text value.
    //DataType.Html: Represents an HTML-encoded string.
    //DataType.MultilineText: Represents a multi-line text value.
    //DataType.EmailAddress: Represents an email address.
    //DataType.Password: Represents a password.
    //DataType.Url: Represents a URL.
    //DataType.ImageUrl: Represents an image URL.
    //DataType.CreditCard: Represents a credit card number.
    //DataType.PostalCode: Represents a postal code.

}
