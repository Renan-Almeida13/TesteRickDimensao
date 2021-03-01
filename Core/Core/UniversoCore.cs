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
    public class UniversoCore : EntityCoreBase<Universo>, IUniversoCore
    {
        #region [ Propriedades / Construtor ]

        private IEntityCoreBase<Universo> _universoCore;
        private IEntityCoreBase<Rick> _rickCore;

        public UniversoCore()
        {

        }

        internal UniversoCore(ServerContainer serverContainer)
            : base(serverContainer) { }

        #endregion [ Propriedades / Construtor ]

        #region [ Configurações de Conexão ]

        protected override void StartDependenciesConnections()
        {
            _universoCore = new EntityCoreBase<Universo>(_Server);
            _rickCore = new EntityCoreBase<Rick>(_Server);
        }

        #endregion [ Configurações de Conexão ]

        public object GetUniverso()
        {
            IEnumerable<Universo> universo = _universoCore.GetAll();
            return universo;
        }

        public object GetUniversoById(int id)
        {
            IEnumerable<Universo> universo = _universoCore.Select(r => r.Id == id);
            return universo;
        }

        public object GetHistoricoUniversoRick(int id)
        {
            IEnumerable<Universo> universo = _universoCore.Select(r => r.IdRick == id);
            return universo;
        }

        public LocalizacaoRickResult PostUniverso(UniversoViewModel universoVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    if (universoVM != null)
                    {
                        Universo universo = new Universo()
                        {
                            NomeUniverso = universoVM.NomeUniverso,
                            Descricao = universoVM.Descricao,
                            IdRick = universoVM.IdRick,
                            DataCriacao = DateTime.Now,
                        };

                        var universoInsert = _universoCore.Insert(universo, dbContext);

                        Rick rick = _rickCore.SelectFirst(r => r.Id == universoVM.IdRick);

                        if (rick != null)
                        {
                            rick.IdUniverso = universoInsert.Id;
                            _rickCore.Update(rick, dbContext);
                        }

                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Universo adicionada com sucesso.", universoInsert);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao cadastrar o universo.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao cadastrar o universo. " + ex.Message);
            }
        }

        public LocalizacaoRickResult UpdateUniverso(UniversoViewModel universoVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Universo universo = _universoCore.SelectFirst(d => d.Id == universoVM.Id);

                    if (universo != null)
                    {
                        universo.NomeUniverso = universoVM.NomeUniverso;
                        universo.Descricao = universoVM.Descricao;
                        universo.IdRick = universoVM.IdRick;
                        universo.DataAlteracao = DateTime.Now;

                        var universoUpdate= _universoCore.Update(universo, dbContext);

                        Rick rick = _rickCore.SelectFirst(r => r.Id == universoVM.IdRick);

                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Universo alterada com sucesso.", universoUpdate);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao alterar o universo.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao alterar o universo. " + ex.Message);
            }
        }

        public LocalizacaoRickResult DeleteUniverso(int id)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Universo universo = _universoCore.SelectFirst(d => d.Id == id);


                    if (universo != null)
                    {
                        Rick rick = _rickCore.SelectFirst(r => r.Id == universo.IdRick);

                        if (rick != null)
                        {
                            rick.IdUniverso = null;
                            _rickCore.Update(rick, dbContext);
                        }

                        var universoDelete = _universoCore.DeletePermanent(universo, dbContext);
                        dbContext.Commit();
                        return new LocalizacaoRickResult(HttpStatusCode.OK, true, "Universo deletada com sucesso.", universoDelete);
                    }
                    else
                    {
                        return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao deletar o universo.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new LocalizacaoRickResult(HttpStatusCode.OK, false, "Erro ao deletar o universo. " + ex.Message);
            }
        }
    }
}

