using System.ComponentModel.DataAnnotations;

namespace QLTX.ViewModels;

public class LoginVM
{
        [Required(ErrorMessage = "Nhập Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Nhập Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
}

