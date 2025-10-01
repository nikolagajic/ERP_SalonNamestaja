﻿using System;
using System.Collections.Generic;

namespace ERP_SalonNamestaja.Models;

public partial class Uloga
{
    public int UlogaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
