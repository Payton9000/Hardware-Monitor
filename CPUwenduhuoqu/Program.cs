using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibreHardwareMonitor.Hardware;
using CPUwenduhuoqu;

namespace CPUwenduhuoqu // CPU温度获取
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 启用应用程序的视觉样式
            Application.EnableVisualStyles();
            // 设置应用程序兼容的文本呈现方式
            Application.SetCompatibleTextRenderingDefault(false);
            // 运行主窗体
            Application.Run(new MainForm());
        }
    }
}
