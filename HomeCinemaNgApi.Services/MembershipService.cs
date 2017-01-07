using HomeCinemaNgApi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCinemaNgApi.Entities;
using HomeCinemaNgApi.Services.Utilities;
using HomeCinemaNgApi.Data.Repositories;
using HomeCinemaNgApi.Data.Infrastructure;

namespace HomeCinemaNgApi.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        public MembershipService(IEntityBaseRepository<User> userRepository, IEntityBaseRepository<Role> roleRepository, IEntityBaseRepository<UserRole> userRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        public User CreateUser(string username, string email, string password, int[] roles)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetUserRoles(string username)
        {
            throw new NotImplementedException();
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipContext = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
        }
    }
}
