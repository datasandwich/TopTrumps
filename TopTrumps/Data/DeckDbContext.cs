using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopTrumps.Models;

namespace TopTrumps.Data
{
    public class DeckDbContext : DbContext
    {
        public DeckDbContext (DbContextOptions<DeckDbContext> options)
            : base(options)
        {
        }

        public DbSet<TopTrumps.Models.Deck>? Decks { get; set; }

        public DbSet<TopTrumps.Models.Card>? Cards { get; set; }
    }
}
