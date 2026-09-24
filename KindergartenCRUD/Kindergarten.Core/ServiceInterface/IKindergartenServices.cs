using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;


namespace Kindergarten.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<KindergartenDomain> Create(KindergartenDto dto);
        Task<KindergartenDomain> Details(Guid id);
        Task<KindergartenDomain> Delete(Guid id);
        Task<KindergartenDomain> Update(KindergartenDto dto);

    }
}
