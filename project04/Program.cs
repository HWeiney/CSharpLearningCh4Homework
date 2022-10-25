using System;
using System.Timers;

namespace EventSampleWeatherStation
{
    class Program
    {
        //定时器
        public static Timer timer = new Timer(3000);

        //气象站,实例化气象站对象
        public static WeatherStation ws = new WeatherStation();

        //屏幕显示气象信息
        public static ScreenDisplayMeteorologicalInformation screen = new ScreenDisplayMeteorologicalInformation();

        //数据库保存气象信息
        public static DatebaseSaveMeteorologicalInformation db = new DatebaseSaveMeteorologicalInformation();

        //在线网站查询气象信息
        public static QueryWeather queryWeather = new QueryWeather();

        static void Main(string[] args)
        {
            //订阅事件
            ws.NewMeteorologicalInformationComming += screen.Screen_OnNewMeteorologicalInformationCommingEventHandler;
            ws.NewMeteorologicalInformationComming += db.DatabaseSave_OnNewMeteorologicalInformationCommingEventHandler;

            //设置执行一次（false）还是一直执行(true)
            timer.AutoReset = true;

            //设置是否执行System.Timers.Timer.Elapsed事件
            timer.Enabled = true;

            //绑定Elapsed事件
            timer.Elapsed += OnTimerElapsedHander;

            timer.Start();
            Console.ReadLine();
        }

        public static void OnTimerElapsedHander(object sender, EventArgs eventArgs)
        {
            //获取了在线温度 202100838 20软一
            ws.GetNewMeteorologicalInformation(queryWeather.temp, queryWeather.humidity);
        }
    }

}
