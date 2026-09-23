using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<KindergartenDomain> Create(KindergartenDto dto);

    }
}
