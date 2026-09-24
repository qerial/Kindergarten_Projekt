using Kindergarten.ApplicationServices;
using Kindergarten.Core;
using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;
using Kindergarten.Core.ServiceInterface;
using Kindergarten.Data;
using Microsoft.EntityFrameworkCore;


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
        public async Task<KindergartenDomain> Create(KindergartenDto dto)
        {
            KindergartenDomain domain = new();
            {
                domain.Id = dto.Id;
                domain.GroupName = dto.GroupName;
                domain.ChildrenCount = dto.ChildrenCount;
                domain.KindergartenName = dto.KindergartenName;
                domain.TeacherName = dto.TeacherName;
                domain.CreatedAt = DateTime.Now;
                domain.UpdatedAt = DateTime.Now;
            }
            ;
            _context.Kindergartens.Add(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<KindergartenDomain> Details(Guid id)
        {
            var domain = await _context.Kindergartens.FindAsync(id);
            return domain;
        }
        public async Task<KindergartenDomain> Delete(Guid id)
        {

            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            _context.Kindergartens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<KindergartenDomain> Update(KindergartenDto dto)
        {
            KindergartenDomain kindergarten = new();
            {
                kindergarten.Id = dto.Id;
                kindergarten.GroupName = dto.GroupName;
                kindergarten.ChildrenCount = dto.ChildrenCount;
                kindergarten.KindergartenName = dto.KindergartenName;
                kindergarten.TeacherName = dto.TeacherName;
                kindergarten.CreatedAt = dto.CreatedAt;
                kindergarten.UpdatedAt = DateTime.Now;
            }

            _context.Kindergartens.Update(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
    }
}
