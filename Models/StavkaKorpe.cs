using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class StavkaKorpe
{
    public int StavkaId { get; set; }

    public int KorpaId { get; set; }

    public int ProizvodId { get; set; }

    public int Kolicina { get; set; }

    public virtual Korpa Korpa { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
