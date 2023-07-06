using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PersAcc.Domain.Entity;
using PersAcc.Domain.Enum;
using PersAcc.Domain.Helpers;
using PersAcc.Domain.Response;
using PersAcc.Domain.ViewModels.Account;
using PersAcc.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersAcc.Handlers;

namespace PersAcc.Service.Implementations
{
    public class AccountService : IAccountService
    {
       
        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            
            try
            {
                
                if (DataBaseHandler.IsEmailInDB(model.Email))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                    };
                }

                var user = new User(model.FirstName, model.LastName, HashPasswordHelper.HashPassowrd(model.Password), model.Email);
          
                
                DataBaseHandler.AddUser(user);
                var result = Authenticate(user.Email);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                if (!DataBaseHandler.IsEmailInDB(model.Email))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (DataBaseHandler.GetPasswordPertainingToEmail(model.Email) != HashPasswordHelper.HashPassowrd(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или логин"
                    };
                }
                
                var result = Authenticate(model.Email);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        private ClaimsIdentity Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}