using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApi_Prova.Models;

namespace Web_Prova
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _default();
                getAll();
            }
        }

        HttpClient client;
        Uri usuarioUri;
        public void _default()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64414/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private void getAll()
        {
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/produtoes").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                usuarioUri = response.Headers.Location;

                //Pegando os dados do Rest e armazenando na variável usuários
                var usuarios = response.Content.ReadAsAsync<IEnumerable<Produto>>().Result;

                //preenchendo a lista com os dados retornados da variável
                GridView1.DataSource = usuarios;
                GridView1.DataBind();
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }
        private Produto getProduto(int index)
        {
            Produto produto = new Produto();
            string link = "api/produtoes/" + index;
            System.Net.Http.HttpResponseMessage response = client.GetAsync(link).Result;

            usuarioUri = response.Headers.Location;
            
            produto = response.Content.ReadAsAsync<Produto>().Result;

            return produto;
        }
        /*private void updateProduto (int index, Produto produto)
        {
            produto.qtdEstoque -= 1;
            HttpResponseMessage response = client.PutAsJsonAsync ("api/produtoes/" + index, produto);
            response.EnsureSuccessStatusCode();
        }*/

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comprar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Produto produto = new Produto();
                produto = getProduto(index);
                //UpdateProduto(index, produto);

                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}