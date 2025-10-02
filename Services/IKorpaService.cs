using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.StavkaKorpeDTO;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.Services
{
    public interface IKorpaService
    {
        Task<Korpa> GetOrCreateKorpa(int korisnikId);
        Task<Korpa> AddProizvod(int korisnikId, int proizvodId, int kolicina);
        Task<Korpa> DeleteProizvod(int korisnikId, int proizvodId);
        Task<Korpa> ClearKorpa(int korisnikId);
        
    }
}