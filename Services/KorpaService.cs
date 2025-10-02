using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP_SalonNamestaja.DTO.StavkaKorpeDTO;
using ERP_SalonNamestaja.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_SalonNamestaja.Services
{
    public class KorpaService : IKorpaService
    {
        private readonly IMapper _mapper;
        private readonly SalonNamestajaErpContext _context;

        public KorpaService(IMapper mapper, SalonNamestajaErpContext context) {
            _mapper = mapper;
            _context= context;
        }

        public async Task<Korpa> GetOrCreateKorpa(int korisnikId)
        {
            var korpa = await _context.Korpas
            .Include(k => k.StavkaKorpes)
            .ThenInclude(s => s.Proizvod)
            .FirstOrDefaultAsync(k => k.KorisnikId == korisnikId);

            if (korpa == null)
            {
                korpa = new Korpa { KorisnikId = korisnikId };
                _context.Korpas.Add(korpa);
                await _context.SaveChangesAsync();
            }
            return korpa;
        }

        public async Task<Korpa> AddProizvod(int korisnikId, int proizvodId, int kolicina)
        {
            var korpa = await GetOrCreateKorpa(korisnikId);
            var stavka = korpa.StavkaKorpes.FirstOrDefault(s => s.ProizvodId == proizvodId);

            if (stavka == null)
            {
                stavka = new StavkaKorpe { ProizvodId = proizvodId, Kolicina = kolicina };
                korpa.StavkaKorpes.Add(stavka);
            }
            else
            {
                stavka.Kolicina += kolicina;
            }

            await _context.SaveChangesAsync();
            return korpa;
        }

        public async Task<Korpa> DeleteProizvod(int korisnikId, int proizvodId)
        {
            var korpa = await GetOrCreateKorpa(korisnikId);
            var stavka = korpa.StavkaKorpes.FirstOrDefault(s => s.ProizvodId == proizvodId);

            if (stavka != null)
            {
                korpa.StavkaKorpes.Remove(stavka);
                await _context.SaveChangesAsync();
            }

            return korpa;
        }
        
        public async Task<Korpa> ClearKorpa(int korisnikId)
        {
            var korpa = await GetOrCreateKorpa(korisnikId);
            korpa.StavkaKorpes.Clear();
            await _context.SaveChangesAsync();
            return korpa;
        }
    }
}