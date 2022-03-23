using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL.Core
{

    public class CrudCadastro
    {

        private static string datasource = @"DESKTOP-DIHUMJM\SQLEXPRESS";
        private static string database = "BiltifulBancoDados";
        private static string username = "FM";
        private static string password = "btf73";
        static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                    + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;


        SqlConnection connection = new SqlConnection(connString);
        public void InsertFornecedor(Fornecedor fornecedor)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_FORNECEDOR_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                    sql_cmnd.Parameters.AddWithValue("@RAZAO_SOCIAL", fornecedor.RazaoSocial);
                    sql_cmnd.Parameters.AddWithValue("@DATA_ABERTURA", fornecedor.DataAbertura);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void SelectFornecedor()
        {
            List<Fornecedor> fornecedor = new List<Fornecedor>();
            connection.Open();
            String sql = "SELECT CNPJ, RAZAO_SOCIAL, DATA_ABERTURA, ULTIMA_COMPRA, DATA_CADASTRO, SITUACAO FROM dbo.FORNECEDOR";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fornecedor.Add(new Fornecedor
                        {
                            CNPJ = reader["CNPJ"].ToString(),
                            RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                            DataAbertura = DateTime.Parse(reader["DATA_ABERTURA"].ToString()),
                            UltimaCompra = DateTime.Parse(reader["ULTIMA_COMPRA"].ToString()),
                            DataCadastro = DateTime.Parse(reader["DATA_CADASTRO"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["SITUACAO"].ToString())
                        });
                    }
                }
            }
            connection.Close();
        }

        public void InsertCliente(Cliente cliente)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_CLIENTE_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CPF", SqlDbType.NVarChar).Value = cliente.CPF;
                    sql_cmnd.Parameters.AddWithValue("@NOME", SqlDbType.NVarChar).Value = cliente.Nome;
                    sql_cmnd.Parameters.AddWithValue("@DATA_NASC", cliente.DataNasc);
                    sql_cmnd.Parameters.AddWithValue("@SEXO", SqlDbType.VarChar).Value = cliente.Sexo;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertProduto(Produto produto)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_PPRODUTO_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@NOME", SqlDbType.NVarChar).Value = produto.Nome;
                    sql_cmnd.Parameters.AddWithValue("@VALOR_VENDA", SqlDbType.Float).Value = float.Parse(produto.ValorVenda);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertCompra(Compra compra)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_COMPRA_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@VALOR_TOTAL", compra.ValorTotal);
                    sql_cmnd.Parameters.AddWithValue("@CNPJ_FORNECEDOR", compra.Fornecedor);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertMateriaPrima(MPrima mPrima)
        {
            mPrima.Id = "MP" + (Count() + 1).ToString().PadLeft(4, '0');
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_MPrima_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Float).Value = float.Parse(mPrima.Id);
                    sql_cmnd.Parameters.AddWithValue("@Nome ", SqlDbType.VarChar).Value = mPrima.Nome;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public int Count()
        {
            connection.Open();
            int GReader = 0;
            string query = "SELECT COUNT(*) FROM MPrima_PROC";
            var reader = new SqlCommand(query, connection).ExecuteReader();
            reader.Read();
            GReader = reader.GetInt32(0);
            connection.Close();
            return GReader;
        }
        public void InsertVendaCliente(Venda venda)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_Venda_Cliente_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Valor_Total", SqlDbType.Float).Value = float.Parse(venda.ValorTotal);
                    sql_cmnd.Parameters.AddWithValue("@CPF_Cliente", SqlDbType.VarChar).Value = venda.Cliente;
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertItemCompra(ItemCompra itemCompra)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_Item_Compra_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Quantidade", itemCompra.Quantidade);
                    sql_cmnd.Parameters.AddWithValue("@Valor_Unitario", itemCompra.ValorUnitario);
                    sql_cmnd.Parameters.AddWithValue("@Total_Item", itemCompra.TotalItem);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertProducao(Producao producao)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_Item_Compra_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Quantidade", SqlDbType.Float).Value = float.Parse(producao.Quantidade);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
        public void InsertItemProducao(ItemProducao itemProducao)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_Item_Producao_PROC", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@ID_Materia_Prima", SqlDbType.Float).Value = float.Parse(itemProducao.MateriaPrima);
                    sql_cmnd.Parameters.AddWithValue("@Quant_Materia_Prima", SqlDbType.Float).Value = float.Parse(itemProducao.QuantidadeMateriaPrima);
                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nProcedimento Concluido");
            Console.ReadLine();
        }
    }
}