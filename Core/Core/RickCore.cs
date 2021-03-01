using Core.Contracts;
using Core.Core.Base;
using Core.Server;
using System;
using System.Net;
using RickDimensao.Domain.Entities;
using System.Collections.Generic;
using Core.ViewModels;

namespace Core.Core
{
    public class RickCore : EntityCoreBase<Rick>, IRickCore
    {
        #region [ Propriedades / Construtor ]

        private IEntityCoreBase<Rick> _rickCore;

        public RickCore()
        {

        }

        internal RickCore(ServerContainer serverContainer)
            : base(serverContainer) { }

        #endregion [ Propriedades / Construtor ]

        #region [ Configurações de Conexão ]

        protected override void StartDependenciesConnections()
        {
            _rickCore = new EntityCoreBase<Rick>(_Server);
        }

        #endregion [ Configurações de Conexão ]

        public object GetRick()
        {
            IEnumerable<Rick> rick = _rickCore.GetAll();
            return rick;
        }

        public object GetRickById(int id)
        {
            IEnumerable<Rick> rick = _rickCore.Select(r => r.Id == id);
            return rick;
        }

        public LocalizacaoRickResult PostRick(RickViewModel rickVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    if (rickVM != null)
                    {
                        Rick rick = new Rick()
                        {
                            NomeRick = rickVM.NomeRick,
                            NomeMorty = rickVM.NomeMorty,
                            Origem = rickVM.Origem,
                            Descricao = rickVM.Descricao,
                            DataCriacao = DateTime.Now,
                        };
                        var rickInsert = _rickCore.Insert(rick, dbContext);
                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Rick adicionado com sucesso.", rickInsert);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao cadastrar o Rick.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao cadastrar o Rick. " + ex.Message);
            }
        }

        public LocalizacaoRickResult UpdateRick(RickViewModel rickVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Rick rick = _rickCore.SelectFirst(p => p.Id == rickVM.Id);

                    if (rick != null)
                    {
                        rick.NomeRick = rickVM.NomeRick;
                        rick.NomeMorty = rickVM.NomeMorty;
                        rick.Origem = rickVM.Origem;
                        rick.Descricao = rickVM.Descricao;
                        rick.DataAlteracao = DateTime.Now;

                        var rickUpdate = _rickCore.Update(rick, dbContext);
                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Rick alterado com sucesso.", rickUpdate);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao alterar o Rick.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao alterar o Rick. " + ex.Message);
            }
        }

        public LocalizacaoRickResult DeleteRick(int id)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Rick rick = _rickCore.SelectFirst(p => p.Id == id);

                    if (rick != null)
                    {
                        var rickDelete = _rickCore.DeletePermanent(rick, dbContext);
                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Rick excluído com sucesso.", rickDelete);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao excluir o Rick.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao excluir o Rick. " + ex.Message);
            }
        }
    }
}
