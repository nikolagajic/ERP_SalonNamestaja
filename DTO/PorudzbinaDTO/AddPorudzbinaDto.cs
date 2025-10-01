using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.PorudzbinaDTO
{
    public class AddPorudzbinaDto
    {
        public DateOnly? DatumKreiranja { get; set; }

        public TimeOnly? VremeKreiranja { get; set; }

        public double? UkupnaCena { get; set; }

        public string? AdresaIsporuke { get; set; }

        public int KorisnikId { get; set; }

    }
}