﻿using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Cliente
    {

        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime UltimaCompra { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public Cliente()
        {
        }

        public Cliente(string cpf, string nome)
        {
            CPF = cpf;
            Nome = nome;
        }

        public Cliente(string cpf, string nome, DateTime dnascimento, Sexo sexo)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNasc = dnascimento;
            this.Sexo = sexo;
            this.Situacao = Situacao;
        }

        public Cliente(string cpf, string nome, DateTime dnascimento, Sexo sexo, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNasc = dnascimento;
            this.Sexo = sexo;
            this.UltimaCompra = ucompra;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }


        public string ConverterParaEDI()
        {
            return $"{CPF}{Nome.PadRight(50).Substring(0, 50)}{DataNasc.ToString("dd/MM/yyyy")}{(char)Sexo}{UltimaCompra.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosCliente()
        {
            return "-------------------------------------------\n|Nome: " + Nome + "\n|CPF: " + CPF + "\n|Data de nascimento: " + DataNasc.ToString("dd/MM/yyyy") + "\n|Sexo: " + Sexo + "\n|Ultima compra: " + UltimaCompra.ToString("dd/MM/yyyy") + "\n|Data de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\n|Situação: " + Situacao;
        }

        public string VendasCliente()
        {
            return $"\n\t\t\t\t\t-------------- Informações --------------" +
                    $"\n\t\t\t\t\tCpf: {CPF}" +
                    $"\n\t\t\t\t\tNome: {Nome}" +
                    $"\n\t\t\t\t\tData Ultima Compra: {UltimaCompra.ToString("dd/MM/yyyy")}" +
                    $"\n\t\t\t\t\t-----------------------------------------";
        }
    }

}
