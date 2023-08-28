using Market.Shared.Entities;
using Microsoft.EntityFrameworkCore;



namespace Market.API.Data
{
    public class DataContext:DbContext
    {
        //Esta clase hace inyección de la BD
        //El proyecto que maneja las entidades es el Shared 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Notación diamante es el nombre de la entidad <>, luego de esto se debe agregar la misma clase en plural
        public DbSet<Country> Countries { get; set; } //la base de datos se crea con este nombre en plural


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
