using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContextModel : IdentityDbContext<ApplicationUserModel>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContextModel()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContextModel Create()
        {
            return new ApplicationDbContextModel();
        }
    }
}