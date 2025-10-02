using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP_SalonNamestaja.DTO.KorpaDTO;
using ERP_SalonNamestaja.DTO.StavkaKorpeDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERP_SalonNamestaja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorpaController : ControllerBase
    {
        private readonly IKorpaService _korpaService;
        private readonly IMapper _mapper;

        public KorpaController(IKorpaService korpaService, IMapper mapper)
        {
            _mapper = mapper;
            _korpaService = korpaService;
        }

        [HttpGet("{korisnikId}")]
        public async Task<ActionResult<GetKorpaDto>> GetKorpa(int korisnikId)
        {
            var korpa = await _korpaService.GetOrCreateKorpa(korisnikId);
            var korpaDto = (new GetKorpaDto
            {
                KorpaId = korpa.KorpaId,
                KorisnikId = korisnikId,
                Stavke = korpa.StavkaKorpes.Select(s => new GetStavkaKorpeDto
                {
                    StavkaId = s.StavkaId,
                    ProizvodId = s.ProizvodId,
                    SifraProizvod = s.Proizvod.SifraProizvod,
                    Naziv = s.Proizvod.Naziv,
                    Kolicina = s.Kolicina,
                    Cena = s.Proizvod.Cena
                }).ToList()
            });
            return Ok(korpaDto);
        }

        [HttpPost("{korisnikId}/add/{proizvodId}/quantity/{kolicina}")]
        public async Task<ActionResult<KorpaDto>> AddProizvod(int korisnikId, int proizvodId, int kolicina)
        {
            var korpa = await _korpaService.AddProizvod(korisnikId, proizvodId, kolicina);
            var korpaDto = (new GetKorpaDto
            {
                KorpaId = korpa.KorpaId,
                KorisnikId = korisnikId,
                Stavke = korpa.StavkaKorpes.Select(s => new GetStavkaKorpeDto
                {
                    StavkaId = s.StavkaId,
                    ProizvodId = s.ProizvodId,
                    SifraProizvod = s.Proizvod.SifraProizvod,
                    Naziv = s.Proizvod.Naziv,
                    Kolicina = s.Kolicina,
                    Cena = s.Proizvod.Cena
                }).ToList()
            });
            return Ok(korpaDto);
        }

        [HttpDelete("{korisnikId}/delete/{proizvodId}")]
        public async Task<ActionResult<KorpaDto>> DeleteProizvod(int korisnikId, int proizvodId)
        {
            var korpa = await _korpaService.DeleteProizvod(korisnikId, proizvodId);
            var korpaDto = (new GetKorpaDto
            {
                KorpaId = korpa.KorpaId,
                KorisnikId = korisnikId,
                Stavke = korpa.StavkaKorpes.Select(s => new GetStavkaKorpeDto
                {
                    StavkaId = s.StavkaId,
                    ProizvodId = s.ProizvodId,
                    SifraProizvod = s.Proizvod.SifraProizvod,
                    Naziv = s.Proizvod.Naziv,
                    Kolicina = s.Kolicina,
                    Cena = s.Proizvod.Cena
                }).ToList()
            });
            return Ok(korpaDto);
        }

        [HttpDelete("{korisnikId}/clear")]
        public async Task<ActionResult<KorpaDto>> ClearKorpa(int korisnikId)
        {
            var korpa = await _korpaService.ClearKorpa(korisnikId);
            var korpaDto = (new GetKorpaDto
            {
                KorpaId = korpa.KorpaId,
                KorisnikId = korisnikId,
                Stavke = korpa.StavkaKorpes.Select(s => new GetStavkaKorpeDto
                {
                    StavkaId = s.StavkaId,
                    ProizvodId = s.ProizvodId,
                    SifraProizvod = s.Proizvod.SifraProizvod,
                    Naziv = s.Proizvod.Naziv,
                    Kolicina = s.Kolicina,
                    Cena = s.Proizvod.Cena
                }).ToList()
            });
            return Ok(korpaDto);
        }
    }

}