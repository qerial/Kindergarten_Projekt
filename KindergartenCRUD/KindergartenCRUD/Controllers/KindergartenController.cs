using Kindergarten.Core.Dto;
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
        // tagastab kasutajale vormi, kuhu saab sisestada andmed
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // kui oled teinud vormi, siis see meetod käivitatakse
        // saadab andmed serverisse, kus need salvestatakse andmebaasi
        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new KindergartenDto
                {
                    Id = vm.Id,
                    GroupName = vm.GroupName,
                    ChildrenCount = vm.ChildrenCount,
                    KindergartenName = vm.KindergartenName,
                    TeacherName = vm.TeacherName,
                    CreatedAt = vm.CreatedAt,
                    UpdatedAt = vm.UpdatedAt
                };


                var result = await _kindergartenServices.Create(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}

