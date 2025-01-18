﻿using GestorTecnicos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTecnicos.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Tecnicos> Tecnicos { get; set; }

    }
}
