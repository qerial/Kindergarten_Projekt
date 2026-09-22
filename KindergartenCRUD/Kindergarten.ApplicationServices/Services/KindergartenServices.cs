using Kindergarten.ApplicationServices;
using Kindergarten.Core;
using Kindergarten.Core.ServiceInterface;
using Kindergarten.Data;


namespace Kindergarten.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly KindergartenContext _context;
        public KindergartenServices
        (
        KindergartenContext context
        )
        {
            _context = context;
        }
    }
}
