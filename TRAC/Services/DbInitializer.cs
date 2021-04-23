using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using TRAC.Areas.Identity.Data;
using TRAC.Common;
using TRAC.Services.IServices;

namespace TRAC.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly TRACIdentityDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(TRACIdentityDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<DbInitializer> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager =roleManager;
            _logger = logger;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                CreateRole(SD.Role_Admin);
                CreateRole(SD.Role_User);
                CreateRole(SD.Role_Validator);

                string pwd = "Admin123*";
                CreateUser("Mathias", "mszatmari@trac.fr", pwd);
                CreateUser("Adrien", "anorroy@trac.fr", pwd);
                CreateUser("Anthony", "asabatella@trac.fr", pwd);
                CreateUser("Christophe", "cvathananonh@trac.fr", pwd);
                CreateUser("Vicky", "vbras@trac.fr", pwd);
                CreateUser("Victoria", "vmeos@trac.fr", pwd);
                CreateUser("Florian", "flolucas@trac.fr", pwd);
                CreateUser("Kevin", "kdanthine@trac.fr", pwd);
                CreateUser("Aurelien", "ahoussier@trac.fr", pwd);
                CreateUser("Antoine", "achwatacz@trac.fr", pwd);
                CreateUser("Geoffrey", "gejeukenne@trac.fr", pwd);
                CreateUser("Aurore", "aauthelet@trac.fr", pwd);
                CreateUser("Thijl", "tduval@trac.fr", pwd);
                CreateUser("Cedric", "creymann@trac.fr", pwd);
                CreateUser("Camille", "ctranchand@trac.fr", pwd);
                CreateUser("Michel", "midossantos@trac.fr", pwd);
                CreateUser("Ophelie", "opassalacqua@trac.fr", pwd);

                List<string> adminRoles = new List<string>
                {
                    SD.Role_Admin,SD.Role_User,SD.Role_Validator
                };
                List<string> validatorRoles = new List<string>
                {
                    SD.Role_User,SD.Role_Validator
                };
                List<string> userRoles = new List<string>
                {
                    SD.Role_User
                };

                AddUserToGroup(adminRoles, "mszatmari@trac.fr");

                AddUserToGroup(validatorRoles, "anorroy@trac.fr");
                AddUserToGroup(validatorRoles, "asabatella@trac.fr");
                AddUserToGroup(validatorRoles, "tduval@trac.fr");
                AddUserToGroup(validatorRoles, "creymann@trac.fr");
                AddUserToGroup(validatorRoles, "cvathananonh@trac.fr");
                AddUserToGroup(validatorRoles, "vmeos@trac.fr");
                AddUserToGroup(validatorRoles, "aauthelet@trac.fr");

                AddUserToGroup(userRoles, "vbras@trac.fr");
                AddUserToGroup(userRoles, "flolucas@trac.fr");
                AddUserToGroup(userRoles, "ahoussier@trac.fr");
                AddUserToGroup(userRoles, "kdanthine@trac.fr");
                AddUserToGroup(userRoles, "achwatacz@trac.fr");
                AddUserToGroup(userRoles, "gejeukenne@trac.fr");
                AddUserToGroup(userRoles, "ctranchand@trac.fr");
                AddUserToGroup(userRoles, "midossantos@trac.fr");
                AddUserToGroup(userRoles, "opassalacqua@trac.fr");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in dbinitializer");
                throw;
            }
        }

        private void AddUserToGroup(IEnumerable<string> roles, string userEmail)
        {
            IdentityUser user = _db.Users.FirstOrDefault(a => a.Email == userEmail);
            if(user ==null)
            {
                _logger.LogError($"User: {userEmail} doesn't not exist");
            }

            foreach(string role in roles)
            {
                if (_userManager.IsInRoleAsync(user, role).GetAwaiter().GetResult())
                {
                    _logger.LogInformation($"User {userEmail} is already in role {role}");
                }
                else
                {
                    _userManager.AddToRoleAsync(user, role).GetAwaiter().GetResult();
                    _logger.LogInformation($"User {userEmail} add in role {role}");
                }
            }
        }

        private void CreateUser(string userName, string email, string pwd)
        {
            if (!_db.Users.Any(a => a.Email == email))
            {
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true,
                    TwoFactorEnabled = false
                    
                }, pwd).GetAwaiter().GetResult();
                _logger.LogInformation($"user {userName} created");

            }
            else
            {
                _logger.LogInformation($"User with email: {email} is already created");
            }
        }

        

        private void CreateRole(string roleName)
        {
            if (!_db.Roles.Any(a => a.Name == roleName))
            {
                _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                _logger.LogInformation($"role {roleName} created");

            }
            else
            {
                _logger.LogInformation($"Role {roleName} is already created");
            }
        }
    }
}
