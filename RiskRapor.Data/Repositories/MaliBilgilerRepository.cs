//using Microsoft.EntityFrameworkCore;
//using RiskRapor.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace RiskRapor.Data.Repositories
//{
//    public class MaliBilgilerRepository : IMaliBilgilerRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public MaliBilgilerRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<MaliBilgiler>> GetAllAsync()
//        {
//            return await _context.MaliBilgiler.Include(m => m.Anlasma).ToListAsync();
//        }

//        public async Task<MaliBilgiler> GetByIdAsync(int id)
//        {
//            return await _context.MaliBilgiler.FindAsync(id);
//        }

//        public async Task AddAsync(MaliBilgiler maliBilgiler)
//        {
//            await _context.MaliBilgiler.AddAsync(maliBilgiler);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(MaliBilgiler maliBilgiler)
//        {
//            _context.MaliBilgiler.Update(maliBilgiler);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var maliBilgiler = await _context.MaliBilgiler.FindAsync(id);
//            if (maliBilgiler != null)
//            {
//                _context.MaliBilgiler.Remove(maliBilgiler);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
