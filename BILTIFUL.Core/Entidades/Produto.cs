using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Globalization;

namespace BILTIFUL.Core.Entidades
{
    public class Produto
    {
        public string CodigoBarras { get; set; } = "7896617";
        public string Nome { get; set; }
        public string ValorVenda { get; set; }
        public DateTime UltimaVenda { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public Produto()
        {
        }


        public Produto(string cbarras, string nome, string vvenda)
        {
            this.CodigoBarras += cbarras.PadLeft(5,'0');
            this.Nome = nome;
            this.ValorVenda = vvenda.PadLeft(5, '0');
        }

        public Produto(string cbarras, string nome, string vvenda, DateTime uvenda, DateTime dcadastro, Situacao situacao)
        {
            this.CodigoBarras = cbarras;
            this.Nome = nome;
            this.ValorVenda = vvenda;
            this.UltimaVenda = uvenda;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }
        public string ExibirProd()
        {   
            return $"\n\t\t\t\t\t----------------------------\n" +
                   $"\n\t\t\t\t\tCod. Barra: {CodigoBarras}\n" +
                   $"\t\t\t\t\tNome: {Nome}\n" +
                   $"\t\t\t\t\tValor Unitário: R$ {float.Parse(ValorVenda.Insert(5, ","))}\n"+
                   $"\n\t\t\t\t\t----------------------------\n" ;
        }

        public string ConverterParaEDI()
        {
            return $"{CodigoBarras}{Nome.PadRight(20).Substring(0, 20)}{ValorVenda.PadLeft(5,'0')}{UltimaVenda.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosProduto()
        {
            return "-------------------------------------------\nCodigo de barras: " + CodigoBarras + "\nNome: " + Nome + "\nValor venda: " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), " {0:C}", float.Parse(ValorVenda.Insert(3,","))) + "\nData de ultima venda: " + UltimaVenda.ToString("dd/MM/yyyy") + "\nData de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\nSituação: " + Situacao;
        }
    }
}