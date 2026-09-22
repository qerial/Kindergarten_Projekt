using Kindergarten.Data;
using Kindergarten.Core;
using Kindergarten.ApplicationServices;


namespace Kindergarten.ApplicationServices.Services
{
    internal class KindergartenServices
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
