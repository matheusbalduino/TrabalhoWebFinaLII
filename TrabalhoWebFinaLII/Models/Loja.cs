using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoWebFinaLII.Models
{
    public class Loja
    {
        public long? LojaId { get; set; }
        public string NomeLoja { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string RazaoSocial { get; set; }
        public string Atividade { get; set; }



    }
    public class Fornecedor
    {
        public long FornecedorId { get; set; }
        public string NomeFornecedor { get; set; }
        public string QualidadeServico { get; set; }
        public string PrazoEntrega { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }



    }

    public class Produto
    {
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public long? LojaId { get; set; }
        public long? FornecedorId { get; set; }
        public Loja Loja { get; set; }
        public Fornecedor Fornecedor { get; set; }

    }
}

