using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CnaeCrud.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
		}



		public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
		{
			public DataContext CreateDbContext(string[] args)
			{
				DbContextOptionsBuilder<DataContext>? optionsBuilder = new DbContextOptionsBuilder<DataContext>();
				optionsBuilder.UseSqlite("Data Source=Cnae.db");

				return new DataContext(optionsBuilder.Options);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cnae>().HasData(
				new Cnae { Id = 1, CnaeID = 3250709, Descricao = "SERVIÇO DE LABORATÓRIO ÓPTICO", Atividade = "LABORATÓRIOS ÓPTICOS; SERVIÇOS DE" },
				new Cnae { Id = 2, CnaeID = 4512901, Descricao = "REPRESENTANTES COMERCIAIS E AGENTES DO COMÉRCIO DE VEÍCULOS AUTOMOTORES", Atividade = "INTERMEDIÁRIOS NA VENDA DE VEÍCULOS AUTOMOTORES, ATACADISTA E VAREJISTA" }
			);
		}

		public DbSet<Cnae> Cnae { get; set; }
	}
}
