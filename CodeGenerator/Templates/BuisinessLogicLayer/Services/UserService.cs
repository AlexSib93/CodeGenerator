using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.Dto;
using System.Security.Cryptography;

namespace BuisinessLogicLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unit) : base(unit)
        {
            Add(new User() { Name = "admin", Login = "admin", Password = GetMd5Hash("Pasw0rd"), Barcode = "AdminBarc0d"});
        }

        private string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        public User Add(User user)
        {
            Unit.RepUser.Add(user);

            return user;
        }

        public User Get(int id)
        {
            User t = Unit.RepUser.GetById(id);

            return t;
        }

        public User GetByBarcode(string barcode)
        {
            User t = Unit.RepUser.GetAll().FirstOrDefault( u => u.Barcode.Equals(barcode));

            return t;
        }

        public User GetByLogin(string login)
        {
            User t = Unit.RepUser.GetAll().FirstOrDefault(u => u.Login.Equals(login));

            return t;
        }

        public IEnumerable<User> Get()
        {
            IEnumerable<User> users = Unit.RepUser.GetAll();

            return users;
        }

        public void Delete(int id)
        {
            User t = Unit.RepUser.Get(p => p.Id == id);
            Unit.RepUser.Delete(t);
        }
    }
}
