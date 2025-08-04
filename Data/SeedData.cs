using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Final1.Usuarios;

namespace Proyecto_Final1.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // 1. Crear los roles si no existen
            string[] roleNames = { "Admin", "Client" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 2. Crear el usuario Administrador y asignarle el rol
            await CreateUserWithRole(userManager, "admin@tienda.com", "AdminPassword123!", "Admin");

            // 3. Crear los usuarios Clientes y asignarles el rol
            await CreateUserWithRole(userManager, "cliente1@tienda.com", "ClientPassword123!", "Client");
            await CreateUserWithRole(userManager, "cliente2@tienda.com", "ClientPassword123!", "Client");
        }

        private static async Task CreateUserWithRole(UserManager<ApplicationUser> userManager, string email, string password, string role)
        {
            // Verifica si el usuario ya existe para evitar duplicados
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    Nombre = role == "Admin" ? "Administrador" : "Cliente",
                    Apellido = "Apellido", // Puedes personalizar esto si lo necesitas
                    FechaRegistro = DateTime.Now,
                    Activo = true // Asegura que el usuario esté activo al crearse
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    // En un entorno de producción, aquí podrías querer loggear los errores
                    // foreach (var error in result.Errors)
                    // {
                    //     Console.WriteLine($"Error al crear usuario {email}: {error.Description}");
                    // }
                }
            }
        }
    }
}
