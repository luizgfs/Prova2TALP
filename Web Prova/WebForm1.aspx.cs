using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using WebApi_Prova.Models;
using System.Web.UI.WebControls;

namespace Web_Prova
{
    public partial class WebForm1 : System.Web.UI.Page
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
            
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/vendas").Result;
                        
            if (response.IsSuccessStatusCode)
            {                
                usuarioUri = response.Headers.Location;
                var usuarios = response.Content.ReadAsAsync<IEnumerable<Venda>>().Result;

                
                GridView2.DataSource = usuarios;
                GridView2.DataBind();
            }
                        
            else
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }
    }
}