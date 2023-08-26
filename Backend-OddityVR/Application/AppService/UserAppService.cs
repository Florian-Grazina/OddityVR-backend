using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;
using Bcr = BCrypt.Net;

namespace Backend_OddityVR.Application.AppService
{
    public class UserAppService : IUserAppService
    {
        // properties
        private readonly UserRepo _userRepo;
        public readonly RoleRepo _roleRepo;
        public readonly DepartmentRepo _departmentRepo;
        public readonly CompanyRepo _companyRepo;


        // constructor
        public UserAppService(UserRepo userRepo, RoleRepo roleRepo, DepartmentRepo departmentRepo, CompanyRepo companyRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _departmentRepo = departmentRepo;
            _companyRepo = companyRepo;
        }


        // create
        public UserDetailsDTO CreateNewUser(CreateUserCmd newUser)
        {
            if (!CmdFieldsChecker.Check(newUser))
                throw new Exception("Cmd is not complete");

            if(_userRepo.GetUserByEmail((User) newUser.ToModel()) != null)
                throw new Exception("User already exists");

            string passwordHash = Bcr.BCrypt.HashPassword(newUser.Password);
            newUser.Password = passwordHash;

            User user = _userRepo.CreateNewUser((User)newUser.ToModel());
            return GetUserById(user.Id);
        }

        public int CreateUsersWithCSV()
        {
            List<string[]> data = ImportCSV.ImportData("users.csv");
            int affectedRows = 0;
            
            foreach(var line in data)
            {
                try
                {
                    affectedRows++;
                    CreateNewUser(new CreateUserCmd
                    {
                        Email = line[0],
                        Password = line[1],
                        Birthdate = DateTime.Parse(line[2]),
                        RoleId = int.Parse(line[3]),
                        DepartmentId = int.Parse(line[4]),
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong with the insertion of " + line[0]);
                }
            }
            return affectedRows;
        }


        // get all
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUser();
        }

        public List<UserDetailsDTO> GetAllUsersFromDepartmentId(int id)
        {
            List<User> users = _userRepo.GetAllUsersFromDepartmentId(id);
            List<Role> roles = _roleRepo.GetAllRoles();
            List<UserDetailsDTO> usersToReturn = new();

            foreach (User user in users)
            {
                Role role = roles.Where(role => role.Id == user.RoleId).ToList().First();

                usersToReturn.Add(new UserDetailsDTO(user, role.Name));
            }
            return usersToReturn;
        }


        // get id
        public UserDetailsDTO GetUserById(int id)
        {
            User user = _userRepo.GetUserById(id);
            Role role = _roleRepo.GetRoleById(user.RoleId);

            return new UserDetailsDTO(user, role.Name);
        }


        // update
        public UserDetailsDTO UpdateUser(UpdateUserCmd updateUser)
        {
            if(!CmdFieldsChecker.Check(updateUser))
                throw new Exception("Cmd is not complete");

            if(_userRepo.GetUserById(updateUser.Id) == null)
                throw new Exception("User doesn't exist");

            User user = (User)updateUser.ToModel();
            _userRepo.UpdateUser(user);
            return GetUserById(user.Id);
        }


        // delete
        public void DeleteUser(int id)
        {
            if (_userRepo.GetUserById(id) != null)
            {
                _userRepo.DeleteUser(id);
            }
            else
                throw new Exception("User doesn't exist");
        }


        // Login
        public User? Login(LoginUserDTO loginUser)
        {
            User? userInDatabase = _userRepo.GetUserByEmail((User)loginUser.ToModel());

            if (userInDatabase == null)
            {
                throw new Exception("User doesn't exist");
            }

            var isLogged = Bcr.BCrypt.Verify(loginUser.Password, userInDatabase.Password);

            if (!isLogged)
            {
                throw new Exception("Wrong Credentials");
            }

            return userInDatabase;
        }
    }
}
