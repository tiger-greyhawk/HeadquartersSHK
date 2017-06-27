using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Model.Entity;
using Model.Setting;

namespace Model.REST
{
    public class RestClient : IDisposable
    {
        private ConnectionProperties _connectionProperties;

        public RestClient(ConnectionProperties connectionProperties)
        {
            _connectionProperties = connectionProperties;
        }

        public ConnectionProperties ConnectionProperties
        {
            get { return _connectionProperties; }
        }

        public HttpWebRequest PrepareRequest(HttpWebRequest request)
        {
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(ConnectionProperties.SCookieCollection);
            request.ContentType = "application/json;charset=UTF-8";
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:47.0) Gecko/20100101 Firefox/47.0";
            return request;
        }

        public HttpWebRequest PrepareBasicAuth(HttpWebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            return request;
        }

        public string DoGet(string url)
        {
            //return Task.Factory.StartNew(() =>
            //{
                string result = "";
                //if (ConnectionProperties.Connected)

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
                            //ConnectionProperties.SCookieCollection.Add(response.Cookies);
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
                    }
                return result;
        }

        public string DoPostAsync(string json, string url)
        {
            string result = "";
            if (ConnectionProperties.Connected)
            {
                HttpWebRequest request =
                    (HttpWebRequest)WebRequest.Create(this._connectionProperties.UrlServer + url + "?_type=json");
                request = PrepareRequest(request);
                request = PrepareBasicAuth(request, ConnectionProperties.Login, ConnectionProperties.Password);
                request.Method = "POST";
                byte[] body = Encoding.UTF8.GetBytes(json);
                request.ContentLength = body.Length;
                System.Net.ServicePointManager.Expect100Continue = false;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                    stream.Close();
                }
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream data = (Stream)response.GetResponseStream();

                        StreamReader reader = new StreamReader(data, Encoding.UTF8);
                        result = reader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    if (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotModified)
                        result = "304";
                }
            }
            return result;
        }

        public void Dispose()
        {

            OnDispose();
        }

        protected virtual void OnDispose()
        {
            //throw new NotImplementedException("Dispose");
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}