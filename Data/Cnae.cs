using System.ComponentModel.DataAnnotations;

namespace CnaeCrud.Data
{
	public class Cnae
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(100)]
		public int CnaeID { get; set; }

		[MaxLength(100)]
		public string? Descricao { get; set; }

		[MaxLength(100)]
		public string? Atividade { get; set; }
	}
}
