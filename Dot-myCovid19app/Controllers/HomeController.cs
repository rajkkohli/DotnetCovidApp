using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Dot_myCovid19app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // ConsumeExternalAPI();
           string Coviddetail= solution2();
            ViewBag.MyString = Coviddetail;
            if (Session["UserType"] == null)
            {
                Session["UserType"] = "Guest";
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ConsumeExternalAPI()
        {
            string url = "https://covid19.who.int/";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                   // var data = await response.Content.ReadAsStringAsync();
                    var data = await response.Content.ReadAsStringAsync();
                    var requiredstring =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<System.String>(data);
                    var substr= requiredstring.Substring(requiredstring.IndexOf("<span class=\"sc - pJurq euZSTn\">"),
                                               requiredstring.IndexOf("<!-- --> deaths</span>, reported to WHO.")- requiredstring.IndexOf("<span class=\"sc - pJurq euZSTn\">"));
                    substr += "<!-- --> deaths</span>, reported to WHO.";
                    var table =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

    //                System.Web.UI.WebControls.GridView gView = new
    //                    System.Web.UI.WebControls.GridView();
    //                gView.DataSource = table;
    //                gView.DataBind();
    //                using (System.IO.StringWriter sw = new System.IO.StringWriter())
    //                {
    //                    using (System.Web.UI.HtmlTextWriter htw = new
    //System.Web.UI.HtmlTextWriter(sw))
    //                    {
    //                        gView.RenderControl(htw);
    //                        ViewBag.ReturnedData = sw.ToString();
    //                    }
    //                }
                }
            }
            return View();
        }
        private string solution2()
        {
            var str = "";
            try
            {
                String url = "https://covid19.who.int/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(sr);
            var aTags = doc.DocumentNode.SelectNodes("//div[@class='sc-AxjAm sc-AxiKw sc-qYiqT bQthTu']");

            int counter = 1;
            
                
            if (aTags != null)
            {
                foreach (var aTag in aTags)
                {
                        str = str+ aTag.InnerText;

                //    richTextBox1.Text += aTag.InnerHtml + "\n";
                    counter++;
                }
            }
            sr.Close();
        }
        catch (Exception ex)
        {
           // MessageBox.Show("Failed to retrieve related keywords." + ex);
        }
            return str;
}
    }
    
}