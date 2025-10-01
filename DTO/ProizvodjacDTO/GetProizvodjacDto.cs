using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.Models;

namespace ERP_SalonNamestaja.DTO.ProizvodjacDTO
{
    public class GetProizvodjacDto
    {
        public int ProizvodjacId { get; set; }

        public string? Naziv { get; set; }

        public List<Proizvod>? Proizvods { get; set;}

    }
}