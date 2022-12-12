using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.MVVM.View;

//配置的更改可见
[assembly:log4net.Config.XmlConfigurator(Watch =true)]
namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 日志名称是文件名，采用反射获取，反射有性能问题，但用的不多
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
#if DEBUG
            log.Error("Hello Log4Net");
            var mainView = new MainWindow();
            mainView.Show();
#else
            var loginView = new LogInView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    loginView.Close();
                }
            };
#endif
        }
    }
}
