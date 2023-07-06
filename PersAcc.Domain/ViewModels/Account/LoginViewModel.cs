﻿using System.ComponentModel.DataAnnotations;

namespace PersAcc.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите Почту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(70, MinimumLength = 6, ErrorMessage = "Диапазон длины пароля должен входить от 6 до 70 символов")]
        public string Password { get; set; }
    }
}