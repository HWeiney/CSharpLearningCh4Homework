using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSampleWeatherStation
{
    //定义类气象信息，MeteorologicalInformation
    //包含时间、温度、湿度等信息
    public class MeteorologicalInformation : EventArgs
    {
        public  DateTime MeteorologicalInformationDateTime { get; set; }
        public String Temperature { get; set; }
        public String Humidity { get; set; }
    }

    /// <summary>
    /// 气象站类
    /// </summary>
    class WeatherStation
    {
        //事件获取到新的气象信息
        public event EventHandler<MeteorologicalInformation> NewMeteorologicalInformationComming;
        
        //属性气象信息
        public MeteorologicalInformation CurrentMeteorologicalInformation { get; set; }
        
        public WeatherStation()
        {
            CurrentMeteorologicalInformation = new MeteorologicalInformation();
            CurrentMeteorologicalInformation.MeteorologicalInformationDateTime = DateTime.Now;
            CurrentMeteorologicalInformation.Temperature = "";
            CurrentMeteorologicalInformation.Humidity = "";
        }

        //获取新的气象信息
        public void GetNewMeteorologicalInformation(String _temperature, String _humidity)
        {
            CurrentMeteorologicalInformation.MeteorologicalInformationDateTime = DateTime.Now;
            CurrentMeteorologicalInformation.Temperature = _temperature;
            CurrentMeteorologicalInformation.Humidity = _humidity;

            //调用触发事件
            RaiseNewMeteorologicalInformationComming();
        }

        //触发事件
        public void RaiseNewMeteorologicalInformationComming()
        {
            if (NewMeteorologicalInformationComming != null)
            {
                NewMeteorologicalInformationComming.Invoke(this, CurrentMeteorologicalInformation);
            }
            // NewMeteorologicalInformationComming?.Invoke(this, CurrentMeteorologicalInformation);
        }
    }
}
