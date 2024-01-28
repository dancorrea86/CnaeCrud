
namespace CnaeCrud.Data
{
	public interface ICnaeService
	{
		List<Cnae> Cnaes { get; set; }

        Task CarregarCnaes();

        Task<Cnae> GetCnaeUnico(int CnaeID);

        Task CreateCnae(Cnae cnae);

		Task UpdateCnae(Cnae cnae, int id);

		Task DeleteCnae(int id);

		void BaixarCnaeApi(int CnaeID);
	}
}
