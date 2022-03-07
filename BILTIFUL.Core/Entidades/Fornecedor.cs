﻿using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Fornecedor
    {
        public long CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimaCompra { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public Fornecedor()
        {
        }

        public Fornecedor(long cnpj, string rsocial, DateTime dabertura)
        {
            this.CNPJ = cnpj;
            this.RazaoSocial = rsocial;
            this.DataAbertura = dabertura;
        }
        public Fornecedor(long cnpj, string rsocial)
        {
            this.CNPJ = cnpj;
            this.RazaoSocial = rsocial;
            
        }

        public override string ToString()
        {
            return "Fornecedor:\t" + RazaoSocial + "\nCnpj:\t" + CNPJ;
        }

        public Fornecedor(long cnpj, string rsocial, DateTime dabertura, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {

            this.CNPJ = cnpj;
            this.RazaoSocial = rsocial;
            this.DataAbertura = dabertura;
            this.UltimaCompra = ucompra;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{CNPJ}{RazaoSocial.PadRight(50, ' ')}{DataAbertura.ToString("dd/MM/yyyy")}{UltimaCompra.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosFornecedor()
        {
            return "Razão social: " + RazaoSocial + "\nCNPJ: " + CNPJ + "\nData de abertura: " + DataAbertura.ToString("dd/MM/yyyy") + "Data de ultima compra" + UltimaCompra.ToString("dd/MM/yyyy") + "\nData de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\nSituação: " + Situacao;
        }
    }
}
