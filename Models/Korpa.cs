using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Korpa
{
    public int KorpaId { get; set; }

    public int KorisnikId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual ICollection<StavkaKorpe> StavkaKorpes { get; set; } = new List<StavkaKorpe>();
}
