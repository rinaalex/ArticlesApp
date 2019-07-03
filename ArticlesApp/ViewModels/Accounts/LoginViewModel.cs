using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels.Accounts
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Необходимо ввести логин!")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Логин должен содержать от 6 до 255 символов!")]
        public string Login { get; set; }
        [Required (ErrorMessage = "Необходимо ввести пароль!"), DataType(DataType.Password), StringLength(255, MinimumLength = 6, ErrorMessage = "Пароль должен содержать минимум 6 символов!")]
        public string Password { get; set; }
    }
}
