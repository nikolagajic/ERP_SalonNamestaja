using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.StavkaKorpeDTO
{
    public class StavkaKorpeDto

    {
        public int StavkaId { get; set; }

        public int KorpaId { get; set; }

        public int ProizvodId { get; set; }

        public int Kolicina { get; set; }
    }
}