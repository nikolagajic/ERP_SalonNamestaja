﻿using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Proizvod
{
    public int ProizvodId { get; set; }

    public string SifraProizvod { get; set; } = null!;

    public double? Cena { get; set; }

    public string? Opis { get; set; }

    public string? Materijal { get; set; }

    public string? SlikaUrl { get; set; }

    public string? Naziv { get; set; }

    public bool StatusAktivan { get; set; }

    public DateTime DatumDodavanja { get; set; }

    public int? KategorijaId { get; set; }

    public int? ProizvodjacId { get; set; }

    public int Stanje { get; set; }

    public virtual Kategorija? Kategorija { get; set; }

    public virtual Proizvodjac? Proizvodjac { get; set; }

    public virtual ICollection<StavkaPorudzbine> StavkaPorudzbines { get; set; } = new List<StavkaPorudzbine>();
}
