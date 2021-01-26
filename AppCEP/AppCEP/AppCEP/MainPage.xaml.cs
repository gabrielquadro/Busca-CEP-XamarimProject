using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCEP.Servico.Modelo;
using AppCEP.Servico;
namespace AppCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Botao.Clicked += BuscarCep;

        }

        //é preciso por esses parametros para nao dar erro
        private void BuscarCep(object sender, EventArgs args)
        {
            //lógica do programa
            //trim remove os espaços
            string cep = Cep.Text.Trim(); // pega o cep digitado
            if (isValidCep(cep))
            {
                try{ 
                    Endereco end = ViaCepServico.BuscarEndercoViaCep(cep);
                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {3} {0},{1} {2}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro Crítico!", "Enderco não encontrado para o cep" + cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("Erro Crítico!", e.Message, "OK");
                }
            }
          
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                //
                DisplayAlert("Erro", "Cep inválido! Cep deve conter 8 caracteres","OK");
                valido = false;
            }
            int novoCep = 0;
            //verifica se é só numero
            if(int.TryParse(cep,out novoCep))
            {
               // DisplayAlert("Erro", "Cep inválido! Cep deve conter apenas números", "OK");
                //valido = false;
            }
            return valido;
        }
    }

    
}
