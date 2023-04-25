using FormProject.Entity.Concrate;
using FormProject.Entity.Concrate.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Data.Concrate.EFCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region UserData
            List<User> users = new List<User>
            {
            new User{ UserName="admin", NormalizedUserName="ADMIN", Email="admin@formproject.com", NormalizedEmail="ADMIN.FORMPROJECT.COM",   EmailConfirmed=true },
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region RoleData
            List<Role> roles = new List<Role>
            {
                new Role{Name="Admin", NormalizedName="ADMIN"},               

            };
            modelBuilder.Entity<Role>().HasData(roles);

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id},                
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region PasswordHash
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "admin");
            #endregion

            #region FormData
            List<Form> forms = new List<Form>()
            {
                new Form{Id=1,UserId=users[0].Id,CreatedAt=DateTime.Now ,Name="Test Form1"},
                new Form{Id=2,UserId=users[0].Id,CreatedAt=DateTime.Now ,Name="Test Form2"}

            };
            modelBuilder.Entity<Form>().HasData(forms);

            #endregion

            #region FieldsData
            List<Fields> fields = new List<Fields>()
            {
                new Fields{Id=1,FirstName="Mehmet" ,LastName="Yavaş" ,Age=25 , FormId=1},
                new Fields{Id=2,FirstName = "Ayşe", LastName = "Filiz", Age = 26,FormId=2},                

            };
            modelBuilder.Entity<Fields>().HasData(fields);
            #endregion
        }
    }
}
