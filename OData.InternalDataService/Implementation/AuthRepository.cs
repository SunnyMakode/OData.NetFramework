using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OData.Business.DomainClasses;
using OData.InternalDataService.Interface;
using OData.ORM.Abstractions.RepositoryPattern;
using OData.ORM.Abstractions.UnitOfWorkPattern;

namespace OData.InternalDataService.Implementation
{
    public class AuthRepository : Service<User>, IAuthRepository
    {
        private readonly IGenericRepository<User> _authRepository;

        public AuthRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._authRepository = unitOfWork.Repository<User>();
        }

        public async Task<User> Register(User user, string password)
        {
            try
            {
                byte[] passwordHash, passwordSalt;

                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _authRepository.Add(user);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _authRepository.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }


        public async Task<bool> IsUserExist(string username)
        {
            if (await _authRepository.ExistAsync(x => x.Username == username))
            {
                return true;
            }

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                var hmacStringifySalt = Encoding.ASCII.GetString(passwordSalt);
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + hmacStringifySalt));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmacStringifySalt = Encoding.ASCII.GetString(passwordSalt);
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + hmacStringifySalt));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
