using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class WordGameContext : DbContext
{
    public WordGameContext()
    {
    }

    public WordGameContext(DbContextOptions<WordGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Definition> Definitions { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Word> Words { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
