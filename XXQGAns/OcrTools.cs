using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace XXQGAns
{
    /// <summary>
    /// 百度OCR API
    /// </summary>
    class OcrTools
    {
        private string AccessToken = "";
        public string language = "CHN_ENG";

        /// <summary>
        /// 构造函数，获取API Token
        /// </summary>
        public OcrTools()
        {
            string API_key = "你的百度OCRkey";
            string Secret_key = "你的百度OCRSecret";
            string host = "https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id=" + API_key + "&client_secret=" + Secret_key;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "get";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string JsonData = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(JsonData);
            this.AccessToken = json["access_token"].ToString();
        }
        /// <summary>
        /// 根据图片路径进行在线文字识别
        /// </summary>
        /// <param name="fileName">图片文件路径</param>
        /// <returns>按行返回识别的文字内容</returns>
        public List<string> accurateBasic(String fileName)
        {
            List<string> result = new List<string>();
            string token = this.AccessToken;
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic?access_token=" + this.AccessToken + "&language_type=" + this.language;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = getFileBase64(fileName);
            String str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string jsonText = reader.ReadToEnd();
            //解析json字符串，提取结果
            JsonReader jsreader = new JsonTextReader(new StringReader(jsonText));
            while (jsreader.Read())
            {
                if (Regex.IsMatch(jsreader.Path, "words_result\\[\\d*\\].words"))
                {
                    if (jsreader.TokenType.ToString() != "PropertyName")
                    {
                        result.Add(jsreader.Value.ToString());
                    }
                }
            }
            return result;
        }
        public List<string> accurateBasic(MemoryStream stream)
        {
            List<string> result = new List<string>();
            string token = this.AccessToken;
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic?access_token=" + this.AccessToken + "&language_type=" + this.language;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = getStreamBase64(stream);
            String str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string jsonText = reader.ReadToEnd();
            //解析json字符串，提取结果
            JsonReader jsreader = new JsonTextReader(new StringReader(jsonText));
            while (jsreader.Read())
            {
                if (Regex.IsMatch(jsreader.Path, "words_result\\[\\d*\\].words"))
                {
                    if (jsreader.TokenType.ToString() != "PropertyName")
                    {
                        result.Add(jsreader.Value.ToString());
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// base64编码文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>文件的base64字符串</returns>
        public static String getFileBase64(String fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }

        /// <summary>
        /// base64编码文件流
        /// </summary>
        /// <param name="filestream">文件流</param>
        /// <returns>文件流的base64字符串</returns>
        public static String getStreamBase64(MemoryStream ms)
        {
            byte[] arr = new byte[ms.Length];
            arr = ms.GetBuffer();
            string baser64 = Convert.ToBase64String(arr);
            return baser64;
        }
    }
}

