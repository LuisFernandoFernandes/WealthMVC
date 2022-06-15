using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Wealth.Tools.database;
using WealthMVC.Enums;
using WealthMVC.Models;
using WealthMVC.Repository;
using WealthMVC.Services.Interfaces;

namespace WealthMVC.Services
{
    public class OperacoesService : GenericService<Operacoes>, IOperacoesService
    {
        #region Variáveis
        private IValidationDictionary _validatonDictionary;
        private OperacoesRepository _repository;

        ModelStateDictionary modelState = new ModelStateDictionary();
        #endregion

        #region Construtor
        public OperacoesService(IValidationDictionary validatonDictionary, OperacoesRepository repository)
        {
            _validatonDictionary = validatonDictionary;
            _repository = repository;
        }

        #endregion

        #region Lista Operações
        public async Task<List<Operacoes>> GetOperacoes(Contexto context)
        {
            var operacoes = await _repository.ListaOperacoes();

            List<Operacoes> operacoesList = new List<Operacoes>();
            foreach (var operacao in operacoes)
            {
                var ativo = context.Ativos.AsQueryable()
                     .Where(a => a.Id == operacao.AtivosId).FirstOrDefault();

                operacao.Ativos = ativo;
                operacoesList.Add(operacao);
            }
            return operacoesList;

        }
        #endregion

        #region Get Operação By Id
        public async Task<Operacoes> GetOperacaoById(string id, Contexto context)
        {
            return await context.Operacoes.FirstOrDefaultAsync(a => a.Id == id);
        }
        #endregion

        #region Valida Model State
        public async Task<eResult> ValidaModelState(string id, Operacoes operacoes)
        {
            return (id == operacoes.Id && !modelState.IsValid) ? eResult.Invalid : eResult.Ok;
        }
        #endregion

        #region OperacoesExists
        public bool OperacoesExists(string id, Contexto context)
        {
            return (context.Operacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion

        #region Create
        public async Task<eResult> Create(Operacoes operacao, Ativos ativos, Contexto context)
        {

            ativos.Codigo = ativos.Codigo.ToUpper();

            ativos = context.Ativos.AsQueryable().Where(a => a.Codigo == ativos.Codigo).FirstOrDefault();

            operacao.Ativos = ativos;

            operacao.AtivosId = operacao.Ativos.Id;

            operacao.Id = context.ValidaId(operacao.Id);

            var operacoes = context.Operacoes.AsQueryable().Where(a => a.AtivosId == ativos.Id).ToList();

            var queryPortifolio = context.Portifolio.AsQueryable().Where(a => a.AtivosId == ativos.Id).FirstOrDefault();

            Portifolio portifolio = (queryPortifolio is null) ? new Portifolio() : queryPortifolio;

            if (modelState.IsValid)
            {
                if (operacoes.Count == 0)
                {
                    portifolio.Id = GeraId();
                    portifolio.AtivosId = ativos.Id;
                    portifolio.Ativos = ativos;
                    portifolio.Quantidade = operacao.Quantidade;
                    portifolio.Preco = operacao.Preco;
                }
                else
                {


                    double quantidadeAtual = 0;
                    double quantidadeComprada = 0;
                    double valorTotal = 0;


                    foreach (var item in operacoes)
                    {
                        if (item.Tipo == eOperacoesTipo.Compra)
                        {
                            valorTotal = (item.Preco * item.Quantidade) + valorTotal;
                            quantidadeComprada = quantidadeComprada + item.Quantidade;
                            quantidadeAtual = quantidadeAtual + item.Quantidade;
                        }
                        else if (item.Tipo == eOperacoesTipo.Venda)
                        {
                            quantidadeAtual = quantidadeAtual - item.Quantidade;
                        }
                    }

                    if (operacao.Tipo == eOperacoesTipo.Compra)
                    {
                        valorTotal = (operacao.Preco * operacao.Quantidade) + valorTotal;
                        quantidadeComprada = quantidadeComprada + operacao.Quantidade;
                        quantidadeAtual = quantidadeAtual + operacao.Quantidade;
                    }
                    else if (operacao.Tipo == eOperacoesTipo.Venda)
                    {
                        quantidadeAtual = quantidadeAtual - operacao.Quantidade;
                    }

                    var precoMedio = valorTotal / quantidadeComprada;

                    portifolio.Quantidade = quantidadeAtual;
                    portifolio.Preco = precoMedio;
                }

                context.Add(operacao);
                if (operacoes.Count == 0) { context.Add(portifolio); }
                else { context.Update(portifolio); }
                await context.SaveChangesAsync();
                return eResult.Ok;
            }
            return eResult.Invalid;
        }
        #endregion

        #region Get Edit
        public async Task<eResult> GetEdit(string id, Contexto context)
        {
            if (id == null || context.Operacoes == null)
            {
                return eResult.NotFound;
            }

            var operacoes = await context.Operacoes.FindAsync(id);
            if (operacoes == null)
            {
                return eResult.NotFound;
            }
            return eResult.Ok;
        }
        #endregion

        #region Post Edit
        public async Task<eResult> PostEdit(string id, Operacoes operacoes, Contexto context)
        {
            if (id != operacoes.Id) { return eResult.NotFound; }

            try
            {
                context.Update(operacoes);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacoesExists(operacoes.Id, context)) return eResult.NotFound;
                else throw;
            }
            return eResult.Ok;
        }
        #endregion

        #region Delete
        public async Task<eResult> Delete(string id, Contexto context)
        {
            if (id == null || _repository == null) { return eResult.NotFound; }

            var operacoes = await context.Operacoes.FirstOrDefaultAsync(a => a.Id == id);

            if (operacoes == null) { return eResult.NotFound; }

            return eResult.Ok;
        }
        #endregion

        #region Delete Confirmed
        public async Task<eResult> DeleteConfirmed(string id, Contexto context)
        {
            if (context.Operacoes == null) { return eResult.Invalid; }

            var operacoes = await context.Operacoes.FindAsync(id);

            if (operacoes != null) { context.Operacoes.Remove(operacoes); }

            await context.SaveChangesAsync();

            return eResult.Ok;
        }
        #endregion
    }
}
