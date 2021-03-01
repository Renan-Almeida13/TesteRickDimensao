using Core.Core;
using Core.ViewModels;
using RickDimensao.Domain.Entities;

namespace Core.Contracts
{
    public interface IUniversoCore : IEntityCoreBase<Universo>
    {
        object GetUniverso();
        object GetUniversoById(int id);
        object GetHistoricoUniversoRick(int id);
        LocalizacaoRickResult PostUniverso(UniversoViewModel rick);
        LocalizacaoRickResult UpdateUniverso(UniversoViewModel rick);
        LocalizacaoRickResult DeleteUniverso(int id);
    }
}
