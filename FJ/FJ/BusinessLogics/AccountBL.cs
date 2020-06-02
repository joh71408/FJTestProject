using FJ.Data.EntityFrameworks;
using FJ.Data.SearchModels;
using FJ.Data.ViewModels;
using FJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.BusinessLogics
{
    public class AccountBL : BaseBL
    {
        public bool GetLogin(LoginIndexViewModel viewModel)
        {
            Account table = AdapterFJRepository.AccountRepository
                .GetSingle(p => p.AccountUser == viewModel.Account && p.Password == viewModel.Password);
            SessionModel.LoginDate = new LoginModel()
            {
                AccountUser = table.AccountUser,
                IdentityCode = table.IdentityCode,
                UserName = table.UserName
            };
            if (table != null) 
            {
                return true;
            }
            return false;
        }

        public IQueryable<AccountIndexViewModel> GetAccountTable(AccountSearchModel searchModel)
        {
            IQueryable<Account> table = AdapterFJRepository.AccountRepository.GetAll();

            var Atable = table.Select(p => new AccountIndexViewModel
            {
                AccountUser = p.AccountUser,
                IdentityCode = p.IdentityCode,
                Winery = p.Winery.WineryName,
                UserName = p.UserName
            });

            return Atable;
        }

        public bool Create(AccountCreateUpdateViewModel viewModel)
        {
            try
            {
                Account account = new Account()
                {
                    AccountUser = viewModel.AccountUser,
                    Password = viewModel.Password,
                    UserName = viewModel.UserName,
                    IdentityCode = viewModel.IdentityCode,
                    WineryId = viewModel.WineryId,
                    Crt_Date = DateTime.Now,
                    Crt_User = SessionModel.LoginDate.UserName
                };
                AdapterFJRepository.AccountRepository.Create(account);
                AdapterFJRepository.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}