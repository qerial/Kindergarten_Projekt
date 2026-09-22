using Kindergarten.Core.ServiceInterface;
using Kindergarten.Data;
using KindergartenCRUD.Models.Kindergarten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KindergartenCRUD.Controllers
{
    public class KindergartenController : Controller
    {

        private readonly IKindergartenServices _kindergartenServices;
        private readonly KindergartenContext _context;

        public KindergartenController
            (
            IKindergartenServices KindergartenServices,
            KindergartenContext context
            )
        {
            _kindergartenServices = KindergartenServices;
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Kindergartens
            .Select(x => new KindergartenIndexViewModel
            {
                Id = x.Id,
                GroupName = x.GroupName,
                ChildrenCount = x.ChildrenCount,
                KindergartenName = x.KindergartenName,
                TeacherName = x.TeacherName,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt

            });



            return View(result);
        }
    }
}
