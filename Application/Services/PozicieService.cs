using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Models;
using Infrastruktura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class PozicieService
    {
        private readonly PozicieRepository _pozicieRepository;

        public PozicieService(PozicieRepository pozicieRepository)
        {
            this._pozicieRepository = pozicieRepository;
        }
        public async Task<IEnumerable<Pozicie>> GetPozicieService()
        {
             return await _pozicieRepository.GetPozicieRepo();
        }

        public async Task<Pozicie> GetPozicieService(int id)
        {
            return await _pozicieRepository.GetPozicieRepo(id);
        }
        public async Task PostPozicieService(Pozicie pozicie)
        {
             await _pozicieRepository.PostPozicieRepo(pozicie);
        }
        public async Task PutPozicieService(int id, Pozicie pozicie)
        {
            await _pozicieRepository.PutPozicieRepo(id, pozicie);
        }
        public async Task DeletePozicieService(int id)
        {
            await _pozicieRepository.DeletePozicieRepo(id);
        }

    }
}
