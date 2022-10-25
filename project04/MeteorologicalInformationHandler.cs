using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSampleWeatherStation
{
    //屏幕显示气象信息
    class ScreenDisplayMeteorologicalInformation
    {

        public void Screen_OnNewMeteorologicalInformationCommingEventHandler(object sender, EventArgs e)
        {
            MeteorologicalInformation mi = (MeteorologicalInformation)e;
            Console.WriteLine($"->最新气象时间: {mi.MeteorologicalInformationDateTime}，温度：{mi.Temperature}，湿度：{mi.Humidity}");
        }
    }

    //数据库保存气象信息
    class DatebaseSaveMeteorologicalInformation
    {
        public void DatabaseSave_OnNewMeteorologicalInformationCommingEventHandler(object sender, EventArgs e)
        {
            MeteorologicalInformation mi = (MeteorologicalInformation)e;
            Console.WriteLine($"->(202100838 20软一)\n数据库中保存了最新气象时间{mi.MeteorologicalInformationDateTime}的信息！");

        }
    }
}