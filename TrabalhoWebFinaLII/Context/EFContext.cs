using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrabalhoWebFinaLII.Models;

namespace TrabalhoWebFinaLII.Context
{
    public class EFContext: DbContext
    {
        public EFContext() : base("Projeto")
        {
            Database.SetInitializer<EFContext>
                (new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Loja> Lojas { get; set; }

        public DbSet<Fornecedor> Fornecedores{ get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}