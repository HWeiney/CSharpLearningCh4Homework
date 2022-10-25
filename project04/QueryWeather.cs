using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
/*
 * 注：如果“using Newtonsoft.Json;”提示错误，则右键此项目->管理NuGet程序包->浏览->安装Newtonsoft.Json
 */
namespace EventSampleWeatherStation
{
    class QueryWeather
    {
        public String temp { set; get; }
        public String humidity { set; get; }
        public QueryWeather()
        {
            //获取天气信息
            GetWeatherInfos();
        }
        //获取天气信息
        private void GetWeatherInfos()
        {

            try
            {
                //免费的天气信息获取API 呼和浩特id：101080101
                string WeatherInfos = HttpGet($"https://api.help.bj.cn/apis/weather/?id=101080101");
                //Console.WriteLine("内蒙古呼和浩特市天气信息：");
                JObject jot = AnalayJson.AnalayJsonStringToJObject(WeatherInfos);
                this.temp = jot["temp"].ToString() + "℃";
                this.humidity = jot["humidity"].ToString();
                /*Console.WriteLine("1-反馈代码：" + jot["status"].ToString());
                Console.WriteLine("2-实时温度：" + jot["temp"].ToString() + "℃");
                Console.WriteLine("3-风    向：" + jot["wd"].ToString());
                Console.WriteLine("4-风    力：" + jot["wdforce"].ToString());
                Console.WriteLine("5-风    速：" + jot["wdspd"].ToString());
                Console.WriteLine("6-更新时间：" + jot["uptime"].ToString());
                Console.WriteLine("7-天气状况：" + jot["weather"].ToString());
                Console.WriteLine("8-天气图标：" + jot["weatherimg"].ToString());
                Console.WriteLine("9-气    压：" + jot["stp"].ToString() + "pa");
                Console.WriteLine("10- 能见度：" + jot["wisib"].ToString());
                Console.WriteLine("11-湿   度：" + jot["humidity"].ToString());
                Console.WriteLine("12-24小时降雨量：" + jot["prcp24h"].ToString());
                Console.WriteLine("13-PM2.5  ：" + jot["pm25"].ToString());
                Console.WriteLine("14-今日日期：" + jot["today"].ToString());
                Console.WriteLine("-----------免费的天气信息获取完成----------------");
                Console.WriteLine("按任何键退出...");
                Console.ReadKey();*/
            }
            catch
            {

            }

            /// <summary>
            /// 发送GET请求
            /// </summary>
            /// <param name="url">请求URL，如果需要传参，在URL末尾加上“？+参数名=参数值”即可</param>
            /// <returns>返回对应的相应信息</returns>
            static string HttpGet(string url)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        //创建
                        HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                        //设置请求方法
                        httpWebRequest.Method = "GET";
                        //请求超时时间
                        httpWebRequest.Timeout = 20000;
                        //发送请求
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        //利用Stream流读取返回数据
                        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
                        //获得最终数据，一般是json
                        string responseContent = streamReader.ReadToEnd();
                        streamReader.Close();
                        httpWebResponse.Close();
                        return responseContent;
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("获取当前 " + url + " 信息出错，请检查！！！" + ex.Message);
                    }

                }
                else
                {
                    return null;
                }
            }

        }//Class_end

        class AnalayJson
        {
            #region
            /// <summary>
            /// 解析Json字符串(首尾没有中括号)【线程安全】
            /// </summary>
            /// <param name="jsonStr">需要解析的Json字符串</param>
            /// <returns>返回解析好的Hashtable表</returns>
            public static Hashtable AnalayJsonString(string jsonStr)
            {
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(jsonStr))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(jsonStr);
                    foreach (var item in jo)
                    {
                        ht.Add(item.Key, item.Value);
                    }
                }

                return ht;
            }

            /// <summary>
            /// 解析Json字符串为JObject(首尾没有中括号)
            /// </summary>
            /// <param name="jsonStr">需要解析的Json字符串</param>
            /// <returns>返回解析后的JObject对象</returns>
            public static JObject AnalayJsonStringToJObject(string jsonStr)
            {
                if (!string.IsNullOrEmpty(jsonStr))
                {
                    string strJsonIndex = string.Empty;
                    JObject jo = (JObject)JsonConvert.DeserializeObject(jsonStr);
                    return jo;
                }
                else
                {
                    return null;
                }
            }

            #endregion

            #region

            /// <summary>
            /// 解析Json字符串(首尾有中括号)【线程安全】
            /// </summary>
            /// <param name="jsonStr">需要解析的Json字符串</param>
            /// <returns>返回解析好的Hashtable表</returns>
            public static Hashtable AnalayJsonStringMiddleBrackets(string jsonStr)
            {
                Hashtable ht = new Hashtable();
                if (!string.IsNullOrEmpty(jsonStr))
                {
                    JArray jArray = (JArray)JsonConvert.DeserializeObject(jsonStr);//jsonArrayText必须是带[]字符串数组
                    if (jArray != null && jArray.Count > 0)
                    {
                        foreach (var item in jArray)
                        {
                            foreach (JToken jToken in item)
                            {
                                string[] strTmp = jToken.ToString().Split(':');
                                ht.Add(strTmp[0].Replace("\"", ""), strTmp[1].Replace("\"", ""));
                            }
                        }
                    }
                }
                return ht;
            }

            /// <summary>
            /// 解析Json字符串为JArray(首尾有中括号)
            /// </summary>
            /// <param name="jsonStr">需要解析的Json字符串</param>
            /// <returns>返回解析后的JArray对象</returns>
            public static JArray AnalayJsonStringMiddleBracketsToJArray(string jsonStr)
            {
                if (!string.IsNullOrEmpty(jsonStr))
                {
                    string strJsonIndex = string.Empty;
                    JArray ja = (JArray)JsonConvert.DeserializeObject(jsonStr);
                    return ja;
                }
                else
                {
                    return null;
                }
            }

            #endregion
        }
    }
}
