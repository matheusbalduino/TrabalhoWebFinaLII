namespace TrabalhoWebFinaLII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        FornecedorId = c.Long(nullable: false, identity: true),
                        NomeFornecedor = c.String(),
                        QualidadeServico = c.String(),
                        PrazoEntrega = c.String(),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Cep = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Lojas",
                c => new
                    {
                        LojaId = c.Long(nullable: false, identity: true),
                        NomeLoja = c.String(),
                        Descricao = c.String(),
                        Cnpj = c.String(),
                        Telefone = c.String(),
                        RazaoSocial = c.String(),
                        Atividade = c.String(),
                    })
                .PrimaryKey(t => t.LojaId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        LojaId = c.Long(),
                        FornecedorId = c.Long(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Fornecedors", t => t.FornecedorId)
                .ForeignKey("dbo.Lojas", t => t.LojaId)
                .Index(t => t.FornecedorId)
                .Index(t => t.LojaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "LojaId", "dbo.Lojas");
            DropForeignKey("dbo.Produtoes", "FornecedorId", "dbo.Fornecedors");
            DropIndex("dbo.Produtoes", new[] { "LojaId" });
            DropIndex("dbo.Produtoes", new[] { "FornecedorId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Lojas");
            DropTable("dbo.Fornecedors");
        }
    }
}
