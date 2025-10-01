using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Transakcija
{
    public int TransakcijaId { get; set; }

    public int PorudzbinaId { get; set; }

    public string StripeId { get; set; } = null!;

    public decimal Iznos { get; set; }

    public DateTime Datum { get; set; }

    public string Status { get; set; } = null!;

    public virtual Porudzbina Porudzbina { get; set; } = null!;
}
