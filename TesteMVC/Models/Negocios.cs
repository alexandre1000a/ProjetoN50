using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography;
using System.Web.Security;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace TesteMVC.Models
{
    public class Negocios
    {
         public void InserirTableUsuarios(Usuarios usuarios)
        {
        try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Usuarios.Add(usuarios);
                    contexto.SaveChanges();
                    
               
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }


        public void InserirTableFornecedor(Fornecedor fornecedor)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Fornecedor.Add(fornecedor);
                    contexto.SaveChanges();
                  
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public void InserirTableCliente(Cliente cliente)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Cliente.Add(cliente);
                    contexto.SaveChanges();
                }
                    
                }
            
            catch (SqlException)
            {
                throw;
            }

        }

        public void InserirTableContasAReceber(Contas_a_Receber contasreceber)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Contas_a_Receber.Add(contasreceber);
                    contexto.SaveChanges();
                }

            }

            catch (SqlException)
            {
                throw;
            }

        }

        public void InserirTableContasAPagar(Contas_a_Pagar contaspagar)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Contas_a_Pagar.Add(contaspagar);
                    contexto.SaveChanges();
                }

            }

            catch (SqlException)
            {
                throw;
            }

        }

        public void InserirTableEndereco(Endereco endereco)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    contexto.Endereco.Add(endereco);
                   var geraId= contexto.SaveChanges();
                   
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }


        public List<Endereco> BuscarEnderecoCliente(Cliente cliente)
        {
          
            using (testeEntities2 contexto = new testeEntities2())
                {
                    try
                    {
                        var endereco = new Endereco();
                        if (cliente.id_endereco == null)
                        {
                            return null;

                        }
                        else { 

                        endereco.id = (int)cliente.id_endereco;

                        var retornaIdEnderecoCliente = contexto.Endereco.Where(id => id.id == endereco.id).ToList();

                        return retornaIdEnderecoCliente;
                        }
                    }
                    catch (Exception  )
                    {
                        
                        throw;
                    }
                 
                               
                }
        }

        public List<Endereco> BuscarEnderecoFornecedor(Fornecedor fornecedor)
        {

            using (testeEntities2 contexto = new testeEntities2())
            {
                var endereco = new Endereco();
                if (fornecedor.id_endereco == null)
                {
                    return null;

                }
                else
                {
                    endereco.id = (int)fornecedor.id_endereco;

                    var retornaIdEnderecoFornecedor = contexto.Endereco.Where(id => id.id == endereco.id).ToList();

                    return retornaIdEnderecoFornecedor;
                }

            }
        }

  
        public void EditarEndereco(Endereco retornaendereco)
            {
            
                 using (testeEntities2 contexto = new testeEntities2())
                     
                 {

                Endereco endereco = (contexto.Endereco.First(e => e.id == retornaendereco.id));
             try
                {
                   
                   
                    endereco.rua = retornaendereco.rua;
                    endereco.numero = retornaendereco.numero;
                    endereco.complemento = retornaendereco.complemento;
                    endereco.cep = retornaendereco.cep;
                    endereco.cidade = retornaendereco.cidade;
                    endereco.estado = retornaendereco.estado;
                    endereco.pais = retornaendereco.pais;
                    contexto.SaveChanges();
                    

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro" + ex.Message.ToString());
                }

                 
             }
          }

        public int retornaUltimoIdInserido(Endereco endereco)
        {
            try
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                  var retornaId =  contexto.Endereco.Select(id => id.id).Last();
                    
                    return retornaId;                   
                }

            }

            catch (SqlException)
            {
                throw;
            }
       }        

        public void Remover(string nome)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var usuarios = new Usuarios();
                usuarios.nome_usuario = nome;

                Usuarios recebeid = (from id in contexto.Usuarios where id.nome_usuario == usuarios.nome_usuario select id).First();
                string recebenomeretonado = recebeid.nome_usuario;

                if (usuarios.nome_usuario == recebeid.nome_usuario)
                {
                    contexto.Usuarios.Remove(recebeid);
                    contexto.SaveChanges();
                }
                
            }
        }


        public IEnumerable<Usuarios> Listar(Usuarios usuarios)
        {

            using (testeEntities2 contexto = new testeEntities2())

                return contexto.Usuarios.Where(m => m.email_usuario == usuarios.email_usuario).ToList();
        
        }

        public IEnumerable<Endereco> SelectRetornaEndereco(Endereco endereco)
        {
            using(testeEntities2 contexto = new testeEntities2())
            {
                return contexto.Endereco.Where(e => e.id == endereco.id).ToList();
            }
       
        }

        public IEnumerable<String> SelectTodosUsuarios(Usuarios usuarios)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Usuarios.Select(p => p.nome_usuario).ToList();

            }

        }

        public IEnumerable<Cliente>  SelectTodosClientes()
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Cliente.Where(p => p.id_cliente>= 1).ToList();

            }
        }

        public IEnumerable<Cliente> SelectTodosClientesporID(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Cliente.Where(p => p.id_cliente >= 1).ToList();

            }
        }

        public IEnumerable<Fornecedor> SelectTodosFornecedoresporID(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Fornecedor.Where(p => p.id_fornecedor >= 1).ToList();

            }
        }

        public ObjectResult<pc_status_fornecedor2_Result> PcStatusFornecedor()
        {
            testeEntities2 contexto = new testeEntities2();
                //Convert.ToInt32(fornecedor.id_status_fornecedor);
                //contexto.Status_Usuario_Fornecedor.Where(s => s.id_status = fornecedor.id_status_fornecedor).Select(p => new { p.status_Ativo_Inativo }).ToList();
         
                return contexto.pc_status_fornecedor2();
                
            
        }


        public IEnumerable<Fornecedor> SelectTodosFornecedores()
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var retorna = contexto.Fornecedor.Where(p => p.id_fornecedor > 0).ToList();
                return retorna;

            }
        }

        public string VerificaEnderecoCLiente(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var recebeConsulta = contexto.Cliente.Where(c => c.id_cliente == cliente.id_cliente).First();
               
                if( recebeConsulta.id_endereco != null )
                {
                    return "Endereço já´cadastrado";
                }
                return null;

            }

        }

        public string VerificaEnderecoFornecedor(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var recebeConsulta = contexto.Fornecedor.Where(c => c.id_fornecedor == fornecedor.id_fornecedor).First();

                if (recebeConsulta.id_endereco != null)
                {
                    return "Endereço já´cadastrado";
                }
                return null;

            }

        }


        public Cliente SelectClienteEndereco(Cliente id)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Cliente.Where(p => p.id_cliente == id.id_cliente).First();


            }
        }

            public Fornecedor SelectFornecedorEndereco(Fornecedor id)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
               return contexto.Fornecedor.Where(p => p.id_fornecedor == id.id_fornecedor).First();
            }
        
        }

            public IList<Status_Usuario_Fornecedor> SelectStatusCliente(Cliente cliente)
            {
                using (testeEntities2 contexto = new testeEntities2())
                {
                    return contexto.Status_Usuario_Fornecedor.Where(p => p.id_status == cliente.id_status_cliente).ToList();
                }

            }



        public void IserirEnderecoCliente(Endereco endereco)

        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                try
                {
                    contexto.Endereco.Add(endereco);
                    contexto.SaveChanges();


                }
                catch (Exception)
                {
                    
                    throw;
                }
              

            }
        
        
        }


        public void VincularIdEnderecoTabelaCliente(Endereco endereco, Cliente cliente)
        {

            using (testeEntities2 contexto = new testeEntities2())
            {
                try
                {
                    var retornaCliente = contexto.Cliente.Where(c => c.id_cliente == cliente.id_cliente).First();
                    
                    if (cliente.id_cliente > 0)
                    {

                        retornaCliente.id_endereco = endereco.id;
                        contexto.SaveChanges();
                    }
                }

                catch (Exception)
                {

                    throw;
                }


            }
        }


        public void VincularIdEnderecoTabelaFornecedor(Endereco endereco, Fornecedor fornecedor)
        {

            using (testeEntities2 contexto = new testeEntities2())
            {
                try
                {
                    var retornaFornecedor = contexto.Fornecedor.Where(c => c.id_fornecedor == fornecedor.id_fornecedor).First();

                    if (fornecedor.id_fornecedor > 0)
                    {

                        retornaFornecedor.id_endereco = endereco.id;
                        contexto.SaveChanges();
                    }
                }

                catch (Exception)
                {

                    throw;
                }


            }
        }

        public int InserStatusCliente(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var statusClienteAtivo = new Status_Usuario_Fornecedor();

                statusClienteAtivo.status_Ativo_Inativo = 1;
                cliente.id_status_cliente = statusClienteAtivo.status_Ativo_Inativo;
                contexto.Status_Usuario_Fornecedor.Add(statusClienteAtivo);
                contexto.SaveChanges();
                return (int)statusClienteAtivo.id_status;                
            
            }        
        
        }


        public int InserStatusFornecedor(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var statusFornecedorAtivo = new Status_Usuario_Fornecedor();

                statusFornecedorAtivo.status_Ativo_Inativo = 1;
                fornecedor.id_status_fornecedor = statusFornecedorAtivo.status_Ativo_Inativo;
                contexto.Status_Usuario_Fornecedor.Add(statusFornecedorAtivo);
                contexto.SaveChanges();
                return (int)statusFornecedorAtivo.id_status;

            }


        }


        public void EditarStatusCliente(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                var retornaObjeto = contexto.Status_Usuario_Fornecedor.Where(c => c.id_status == cliente.id_cliente).First();
               
                    if (retornaObjeto.status_Ativo_Inativo == 1)
                    {
                        retornaObjeto.status_Ativo_Inativo = 2;
                   
                    }

                    else if (retornaObjeto.status_Ativo_Inativo == 2)
                    {
                        retornaObjeto.status_Ativo_Inativo = 1;

                    }
                
                     contexto.SaveChanges();
            }

        }


        public void EditarStatusFornecedor(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                var retornaObjeto = contexto.Status_Usuario_Fornecedor.Where(c => c.id_status == fornecedor.id_fornecedor);
                foreach (var item in retornaObjeto)
                {
                    if (item.status_Ativo_Inativo == 1)
                    {
                        item.status_Ativo_Inativo = 2;

                    }

                    else if (item.status_Ativo_Inativo == 2)
                    {
                        item.status_Ativo_Inativo = 1;

                    }
                }
                contexto.SaveChanges();
            }

        }


        public void EditarContasAPagar(Contas_a_Pagar contaspagar)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                Contas_a_Pagar retornaContasPagar = (contexto.Contas_a_Pagar.First(e => e.id_contas_a_pagar == contaspagar.id_contas_a_pagar));

                try
                {
                    retornaContasPagar.valor_pago = contaspagar.valor_pago;
                    retornaContasPagar.data_valor_pago = contaspagar.data_valor_pago;
                    
                    contexto.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro" + ex.Message.ToString());
                }

            }

        }

        public void EditarContasAReceber(Contas_a_Receber contasreceber)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                Contas_a_Receber retornaContasReceber = (contexto.Contas_a_Receber.First(e => e.id_contas_a_receber == contasreceber.id_contas_a_receber));

                try
                {
                    retornaContasReceber.valor_recebido = contasreceber.valor_recebido;
                    retornaContasReceber.data_recebimento = contasreceber.data_recebimento;

                    contexto.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro" + ex.Message.ToString());
                }

            }

        }

        public List<Status_Usuario_Fornecedor> BuscaStatusCliente(Cliente cliente)

        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                
                return contexto.Status_Usuario_Fornecedor.Where(s => s.id_status ==cliente.id_cliente).ToList();
            }
        
        }


        public List<Status_Usuario_Fornecedor> BuscaStatusFornecedor(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {

                return contexto.Status_Usuario_Fornecedor.Where(s => s.id_status == fornecedor.id_fornecedor).ToList();
            }

        }

        public void CalculaValorJurosDecontoContasReceber(Contas_a_Receber contasreceber)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var retorna = contexto.Contas_a_Receber.Where(c => c.id_contas_a_receber == contasreceber.id_contas_a_receber).First();

                if (contasreceber.valor_a_receber < contasreceber.valor_recebido)
                {


                    var juros = (double)(retorna.valor_recebido - retorna.valor_a_receber);

                    retorna.valor_juros_recebimento = (double)juros;
                    
                     Convert.ToDouble(retorna.valor_juros_recebimento);


                }
                else if (contasreceber.valor_a_receber > contasreceber.valor_recebido)
                {

                    double desconto = (double)(retorna.valor_a_receber - retorna.valor_recebido);
                    retorna.valor_desconto_recebimento = desconto;
                     Convert.ToDouble(retorna.valor_desconto_recebimento);

                }
                contexto.SaveChanges(); 
            }
        }


        public void CalculaValorJurosDecontoContasPagar(Contas_a_Pagar contaspagar)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var retorna = contexto.Contas_a_Pagar.Where(c => c.id_contas_a_pagar == contaspagar.id_contas_a_pagar).First();

                
                if (retorna.id_contas_a_pagar == contaspagar.id_contas_a_pagar && contaspagar.valor_a_pagar < contaspagar.valor_pago)
                {

                    var juros = (double)(retorna.valor_a_pagar - retorna.valor_pago);
                    retorna.valor_juros_pago = (double)juros;
                    

                }
                else if (retorna.id_contas_a_pagar == contaspagar.id_contas_a_pagar && contaspagar.valor_a_pagar > contaspagar.valor_pago)
                {

                    double desconto = (double)(retorna.valor_a_pagar - retorna.valor_pago);
                    retorna.valor_deconto_pago = desconto;
                    Convert.ToDouble(retorna.valor_deconto_pago);

                }

                contexto.SaveChanges();

            }
        }


        public IList<Contas_a_Receber> RecuperaDadosEmAbertoCliente(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var contasreceber = new Contas_a_Receber();
                if (contasreceber.valor_a_receber == 0)
                {
                    var recebe = contexto.Contas_a_Receber.Where(p => p.data_a_receber.Value < EntityFunctions.AddDays(DateTime.Today, -30)).
                        Select(p => new Contas_a_Receber()
                                       {
                                           id_cliente = p.id_cliente,
                                           data_a_receber = p.data_a_receber,
                                           valor_a_receber = p.valor_a_receber                                          


                                       }).ToList();

                    return recebe.ToList();
                }
                return null;

            }

        }



        public ObjectResult<pc_Relatorio_inadimplente_1_Result> ProcedureInadimplentes()
        {

            testeEntities2 contexto = new testeEntities2();
                var resulta = contexto.pc_Relatorio_inadimplente_1();
                return resulta;
            
        }

        public ObjectResult<pc_relatorio_pagamento1_Result> PcRelatorioPagamento()
        {

            testeEntities2 contexto = new testeEntities2();
            var resulta = contexto.pc_relatorio_pagamento1();
            return resulta;

        }

        public ObjectResult<pc_status_cliente4_Result> PcRetornaStatusCliente()
        {
            testeEntities2 contexto = new testeEntities2();
            var resulta = contexto.pc_status_cliente4();
            return resulta;
        }






        public List<Contas_a_Pagar> RecuperaPagamentoFornecedor(Fornecedor fornecedor)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var recupera =  contexto.Contas_a_Pagar.Where(c=> c.id_fornecedor == fornecedor.id_fornecedor).ToList();
                return recupera;
            }

        }

        public List<Contas_a_Receber> RecuperaPagamentoCliente(Cliente cliente)
        {
            using (testeEntities2 contexto = new testeEntities2())
            {
                var recupera = contexto.Contas_a_Receber.Where(c => c.id_cliente == cliente.id_cliente).ToList();
                return recupera;
            }

        }


    }
}

    