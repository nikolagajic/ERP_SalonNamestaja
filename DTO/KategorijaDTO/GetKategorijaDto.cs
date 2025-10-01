using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_SalonNamestaja.DTO.ProizvodDTO;

namespace ERP_SalonNamestaja.DTO.KategorijaDTO
{
    public class GetKategorijaDto
    {
        public int KategorijaId { get; set; }

        public string? NazivKat { get; set; }

        public int? ProstorijaId { get; set; }

        public List<GetProizvodDto>? Proizvods { get; set;}

    }
}