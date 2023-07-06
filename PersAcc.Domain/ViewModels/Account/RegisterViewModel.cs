using System.ComponentModel.DataAnnotations;
using PersAcc.Attributes;

namespace PersAcc.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
         [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше 2 символов")]
        [MaxLength(50, ErrorMessage = "Длина не должна превышать больше 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите Фамилию")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше 2 символов")]
        [MaxLength(50, ErrorMessage = "Длина не должна превышать больше 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите Почту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [MatchCheckAttribute(ErrorMessage = "Пользователь с такой почтой уже зарегистрирован")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(70, MinimumLength = 6, ErrorMessage = "Диапазон длины пароля должен входить от 6 до 70 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfrim { get; set; }
    }
}