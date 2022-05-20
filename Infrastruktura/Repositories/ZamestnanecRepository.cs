using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;



namespace Infrastruktura.Repositories
{
   
    public class ZamestnanecRepository
    {
        private readonly ZamestnanciContext _context;

        public ZamestnanecRepository(ZamestnanciContext context)
        {
            _context = context;
        }

        
        public async Task <IEnumerable<Zamestnanci>> GetZamestnanci()
        {
            return await _context.Zamestnanci.ToListAsync();
        }

        public async Task <Zamestnanci> GetZamestnanciId(int id)
        {
            var zamestnanci = await _context.Zamestnanci.FindAsync(id);
            return zamestnanci;

        }

        public async Task Put(int id, Zamestnanci zamestnanci)
        {
              _context.Entry(zamestnanci).State = EntityState.Modified;
                
            try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!ZamestnanciExists(id))
                 {
                    throw new ArgumentOutOfRangeException(nameof(id), "Nespravne ID");
                 }
             }
         }

            private bool ZamestnanciExists(int id)
            {
                return _context.Zamestnanci.Any(e => e.Id == id);
            }
       
        public async Task PostZamestnanci(Zamestnanci zamestnanci)
        {
             _context.Zamestnanci.Add(zamestnanci);
             await _context.SaveChangesAsync();
        }

         public async Task DeleteZamestnanci(int id)
         {
             var zamestnanci = await _context.Zamestnanci.FindAsync(id);
             _context.Zamestnanci.Remove(zamestnanci);
             await _context.SaveChangesAsync();
         }
 

    }
}
