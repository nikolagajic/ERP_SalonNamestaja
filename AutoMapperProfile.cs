using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP_SalonNamestaja.DTO.ProstorijaDTO;
using ERP_SalonNamestaja.DTO.KategorijaDTO;
using ERP_SalonNamestaja.DTO.ProizvodDTO;
using ERP_SalonNamestaja.DTO.ProizvodjacDTO;
using ERP_SalonNamestaja.DTO.StavkaPorudzbineDTO;
using ERP_SalonNamestaja.DTO.PorudzbinaDTO;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.DTO.StavkaKorpeDTO;

namespace ERP_SalonNamestaja
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prostorija, GetProstorijaDto>();
            CreateMap<AddProstorijaDto, Prostorija>();

            CreateMap<Kategorija, GetKategorijaDto>();
            CreateMap<AddKategorijaDto, Kategorija>();

            CreateMap<Porudzbina, GetPorudzbinaDto>();
            CreateMap<AddPorudzbinaDto, Porudzbina>();

            CreateMap<Proizvodjac, GetProizvodjacDto>();
            CreateMap<AddProizvodjacDto, Proizvodjac>();

            CreateMap<Proizvod, GetProizvodDto>();
            CreateMap<AddProizvodDto, Proizvod>();

            CreateMap<StavkaPorudzbine, GetStavkaPorudzbineDto>();
            CreateMap<AddStavkaPorudzbineDto, StavkaPorudzbine>();

            CreateMap<KorpaDto, Korpa>();
            CreateMap<Korpa, KorpaDto>();
        }
    }
}