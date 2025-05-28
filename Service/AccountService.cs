using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService
    {
        private readonly AccountRepository _repo;

        public AccountService()
        {
            _repo = new AccountRepository();
        }

        public async Task<SystemAccount> Login(string email, string password)
        {
            return await _repo.Login(email, password);
        }

        public async Task<SystemAccount> GetAccountById(short id)
        {
            return await _repo.GetAccountById(id);
        }

        public async Task<bool> CreateAccount(string Fullname, string Email, string Password, int Role)
        {
            if (await _repo.CheckExistEmail(Email))
            {
                return false;
            }

            var l = await _repo.GetAllAsync();

            await _repo.CreateAsync(new SystemAccount
            {
                AccountEmail = Email,
                AccountName = Fullname,
                AccountPassword = Password,
                AccountRole = Role,
                AccountId = (short)(l.Count + 1)
            });
            return true;
        }
    }
}
