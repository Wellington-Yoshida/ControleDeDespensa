namespace Cadastro.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompraIdemProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCompra = c.DateTime(nullable: false),
                        LojaId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loja", t => t.LojaId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.LojaId)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Loja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataValidade = c.DateTime(nullable: false),
                        Marca = c.String(),
                        QuantidadeDoItem = c.Int(nullable: false),
                        CompraId = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compra", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.Compra", t => t.Compra_Id)
                .Index(t => t.CompraId)
                .Index(t => t.Compra_Id);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        MunicipioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MunicipioId)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Municipio", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Produto", "Compra_Id", "dbo.Compra");
            DropForeignKey("dbo.Compra", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Produto", "CompraId", "dbo.Compra");
            DropForeignKey("dbo.Compra", "LojaId", "dbo.Loja");
            DropIndex("dbo.Municipio", new[] { "EstadoId" });
            DropIndex("dbo.Produto", new[] { "Compra_Id" });
            DropIndex("dbo.Produto", new[] { "CompraId" });
            DropIndex("dbo.Compra", new[] { "Produto_Id" });
            DropIndex("dbo.Compra", new[] { "LojaId" });
            DropTable("dbo.Municipio");
            DropTable("dbo.Estado");
            DropTable("dbo.Produto");
            DropTable("dbo.Loja");
            DropTable("dbo.Compra");
        }
    }
}
