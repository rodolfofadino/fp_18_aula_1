﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_web_aula_1.Models
{
    public class CopaContext : DbContext
    {
        public CopaContext(DbContextOptions<CopaContext> options)
            : base(options)
        { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
    }

    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }

        public List<Jogador> Jogadores { get; set; }
    }

    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }

    }
}
