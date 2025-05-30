using Jcf.WhereToPark.Api.Application.User.Entities;
using Jcf.WhereToPark.Api.Core.Constants;
using Jcf.WhereToPark.Api.Core.Uties;
using Microsoft.EntityFrameworkCore;

namespace Jcf.WhereToPark.Api.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    (
                        Guid.Parse("08dbd59a-2683-4c67-8e16-689ba2648545"),
                        "Administrador Usuário",
                        "admin@email.com",
                        PasswordUtil.CreateHashMD5("10203040"),
                        "admin@email.com",
                        RolesConstants.ADMIN,
                        null
                    ),
                    new User
                    (
                        Guid.Parse("08dbdc08-56e1-4e90-805f-db29361e075e"),
                        "Básico Usuário",
                        "basico@email.com",
                        PasswordUtil.CreateHashMD5("10203040"),
                        "basico@email.com",
                        RolesConstants.BASIC,
                        null
                    )
                );
        }
    }
}
