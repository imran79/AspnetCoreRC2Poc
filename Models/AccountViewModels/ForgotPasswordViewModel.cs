using System.ComponentModel.DataAnnotations;

namespace AspnetCoreRC2Poc.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
