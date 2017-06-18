using System.Collections;
using System.Collections.Generic;
using Model.Entity;

namespace Model.REST
{
    public class RestClient
    {
        public string DoGet(string url)
        {
            //return Task.Factory.StartNew(() =>
            //{
                string result = "";
                /*if (ConnectionProperties.Connected)

                    using (this)

                    {
                        //Thread.Sleep(1000);
                        //System.Threading.Thread.Sleep(10000);
                        HttpWebRequest request =
                           (HttpWebRequest)WebRequest.Create(this.ConnectionProperties.UrlServer + url + "/?_type=json");
                        //request.CookieContainer = new CookieContainer();
                        //request.CookieContainer.Add(ConnectionProperties.SCookieCollection);
                        //request.ContentType = "application/json;charset=UTF-8";
                        //request.Method = "GET";
                        //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:47.0) Gecko/20100101 Firefox/47.0";
                        //if (!string.IsNullOrEmpty(_connectionProperties.SCookies))
                        //    request.Headers.Add(HttpRequestHeader.Cookie, _connectionProperties.SCookies);
                        request = PrepareRequest(request);
                        request = PrepareBasicAuth(request, ConnectionProperties.Login, ConnectionProperties.Password);

                        //request.AllowAutoRedirect = false;
                        try
                        {
                            var response = (HttpWebResponse)request.GetResponse();
                            //request.BeginGetResponse(new AsyncCallback(OnResponse), request);
                            System.Net.ServicePointManager.Expect100Continue = false;
                            ConnectionProperties.SCookieCollection.Add(response.Cookies);
                            Stream data = (Stream)response.GetResponseStream();
                            StreamReader reader = new StreamReader(data, Encoding.UTF8);
                            //DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Player>));
                            //List<Player> players = ((List<Player>)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(reader.ReadToEnd()))));
                            result = reader.ReadToEnd();
                            response.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            result = null;
                            //throw;
                        }
                    }*/
                return result;
        }
    }
}