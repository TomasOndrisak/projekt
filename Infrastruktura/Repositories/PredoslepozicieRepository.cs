using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;
using Infrastruktura.Repositories;
namespace Infrastruktura.Repositories
{
 
    public class PredoslepozicieRepository
    {
        private readonly ZamestnanciContext _context;

        public PredoslepozicieRepository(ZamestnanciContext context)
        {
            _context = context;
        }

        
        public async Task <IEnumerable<Predoslepozicie>> GetPredoslepozicie()
        {
            return await _context.Predoslepozicie.ToListAsync();
        }

 
        public async Task <IEnumerable<Predoslepozicie>> GetPredoslepozicie(int idZamestnanca)
        {
            return await _context.Predoslepozicie.Where(id => id.idZamestnanca == idZamestnanca).ToListAsync();
        }



                public async Task PutPredoslepozicie(int id, Predoslepozicie Predoslepozicie)
                {
                    _context.Entry(Predoslepozicie).State = EntityState.Modified;
                    await _context.SaveChangesAsync();    
                }


                public async Task PostPredoslepozicie(Predoslepozicie Predoslepozicie)
                {
                    _context.Predoslepozicie.Add(Predoslepozicie);
                    await _context.SaveChangesAsync();

                   
                }
                public async Task DeletePredoslepozicie(int id)
                {
                    var Predoslepozicie = await _context.Predoslepozicie.FindAsync(id);
                    _context.Predoslepozicie.Remove(Predoslepozicie);
                    await _context.SaveChangesAsync();
                }

        private bool PredoslepozicieExists(int id)
        {
            return _context.Predoslepozicie.Any(e => e.Id == id);
        }
    }
}
