using System;
using System.ComponentModel.DataAnnotations;
using PersAcc.Handlers;
namespace PersAcc.Attributes
{
	public class MatchCheckAttribute : ValidationAttribute
	{
        public override bool IsValid(object? value)
        {
            return !DataBaseHandler.IsEmailInDB(value?.ToString());
        }
    }
}

