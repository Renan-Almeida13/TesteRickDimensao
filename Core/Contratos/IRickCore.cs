using Core.Core;
using Core.ViewModels;
using RickDimensao.Domain.Entities;

namespace Core.Contracts
{
    public interface IRickCore : IEntityCoreBase<Rick>
    {
        object GetRick();
        object GetRickById(int id);
        LocalizacaoRickResult PostRick(RickViewModel rick);
        LocalizacaoRickResult UpdateRick(RickViewModel rick);
        LocalizacaoRickResult DeleteRick(int id);
    }
}
