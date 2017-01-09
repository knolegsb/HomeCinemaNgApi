using HomeCinemaNgApi.Data.Configurations;
using HomeCinemaNgApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinemaNgApi.Data
{
    public class HomeCinemaNgApiDbContext : DbContext
    {
        public HomeCinemaNgApiDbContext() : base("HomeCinemaNgApi")
        {
            Database.SetInitializer<HomeCinemaNgApiDbContext>(null);
        }

        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Customer> CustomerSet { get; set; }
        public IDbSet<Movie> MovieSet { get; set; }
        public IDbSet<Genre> GenreSet { get; set; }
        public IDbSet<Stock> StockSet { get; set; }
        public IDbSet<Rental> RentalSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());
        }

        //public System.Data.Entity.DbSet<HomeCinemaNgApi.Web.Models.MovieViewModel> MovieViewModels { get; set; }

        //public System.Data.Entity.DbSet<HomeCinemaNgApi.Entities.Movie> Movies { get; set; }

        //public System.Data.Entity.DbSet<HomeCinemaNgApi.Entities.Genre> Genres { get; set; }
    }
}
