using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace CnaeCrud.Data
{

	public class CnaeService : ICnaeService
	{
			
		private readonly DataContext _context;
		private readonly NavigationManager _navigationManager;

        // Propriedades

        public class Grupo
        {
            public string id { get; set; }
            public string descricao { get; set; }
        }

        public class Divisao
        {
            public string id { get; set; }
            public string descricao { get; set; }
            public Grupo grupo { get; set; }
        }

        public class Secao
        {
            public string id { get; set; }
            public string descricao { get; set; }
        }

        public class ObservacoesItem
        {
            public string observacoes { get; set; }
        }

        public class Classe
        {
            public string id { get; set; }
            public string descricao { get; set; }
            public Divisao divisao { get; set; }
            public string[] atividades { get; set; }
            public List<string> observacoes { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public string descricao { get; set; }
            public Classe classe { get; set; }
            public string[] atividades { get; set; }
            public List<string> observacoes { get; set; }
        }


        public CnaeService(DataContext context, NavigationManager navigationManager)
		{
			_context = context;
			_navigationManager = navigationManager;
		}

		public List<Cnae> Cnaes { get; set; } = new List<Cnae>();

		public async Task CarregarCnaes()
		{
			Cnaes = await _context.Cnae.ToListAsync();
		}

		public async Task CreateCnae(Cnae cnae)
		{
			_context.Add(cnae);
			await _context.SaveChangesAsync();
			_navigationManager.NavigateTo("cnaes");
		}

		public async Task DeleteCnae(int CnaeID)
		{
			Cnae? dbCnae = await _context.Cnae.FirstOrDefaultAsync(c => c.CnaeID == CnaeID);
			if (dbCnae == null)
			{
				throw new Exception("Cnae não cadastrado");
			}

			_context.Remove(dbCnae);
			await _context.SaveChangesAsync();
			_navigationManager.NavigateTo("cnaes");
		}

		public async Task<Cnae> GetCnaeUnico(int CnaeID)
		{
			Cnae Cnae = await _context.Cnae.FirstOrDefaultAsync(x => x.CnaeID == CnaeID);

			if (Cnae == null)
			{
				throw new Exception("Cnae não cadastrado");
			} 

			return Cnae;
		}

		public async Task UpdateCnae(Cnae cnae, int CnaeID)
		{
			Cnae? dbCnae = await _context.Cnae.FirstOrDefaultAsync(c => c.CnaeID == CnaeID);
			if (dbCnae == null)
			{
				throw new Exception("Cnae não cadastrado");
			}

            dbCnae.CnaeID = cnae.CnaeID;
			dbCnae.Atividade = cnae.Atividade;
			dbCnae.Descricao = cnae.Descricao;

			await _context.SaveChangesAsync();
			_navigationManager.NavigateTo("cnaes");
		}

		public async void BaixarCnaeApi(int CnaeID)
		{
			var subclasse = string.Concat("subclasses/", CnaeID);

			RestClient? client = new RestClient("https://servicodados.ibge.gov.br/api/v2/cnae/");
			RestRequest? request = new RestRequest(subclasse);

			
			RestResponse? response = client.ExecuteGet(request);

            List<Item>? cnaes = JsonSerializer.Deserialize<List<Item>>(response.Content);

			if (cnaes != null)
			{
				foreach (Item item in cnaes)
				{
                    Cnae cnae = new Cnae();
                    cnae.CnaeID = int.Parse(item.id);
                    cnae.Atividade = item.atividades[0];
                    cnae.Descricao = item.descricao;

                    await this.CreateCnae(cnae);
                }
			}

		}

    }
}
