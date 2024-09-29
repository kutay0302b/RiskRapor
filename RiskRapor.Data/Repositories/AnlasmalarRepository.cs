//using Microsoft.EntityFrameworkCore;
//using RiskRapor.Models;

//namespace RiskRapor.Data.Repositories
//{
//    public class AnlasmalarRepository : IAnlasmalarRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public AnlasmalarRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Anlasmalar>> GetAllAsync()
//        {
//            return await _context.Anlasmalar.ToListAsync();
//        }

//        public async Task<Anlasmalar> GetByIdAsync(int id)
//        {
//            return await _context.Anlasmalar.FindAsync(id);
//        }

//        public async Task AddAsync(Anlasmalar anlasma)
//        {
//            await _context.Anlasmalar.AddAsync(anlasma);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Anlasmalar anlasma)
//        {
//            _context.Anlasmalar.Update(anlasma);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var anlasma = await _context.Anlasmalar.FindAsync(id);
//            if (anlasma != null)
//            {
//                _context.Anlasmalar.Remove(anlasma);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
