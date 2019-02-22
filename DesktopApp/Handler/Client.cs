using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using System.Reflection;

namespace DesktopApp.Handler
{
    public class Client
    {
        public static string CPUCode
        {
            get
            {
                string strCpu = null;
                //取CPU物理串号
                try
                {

                    ManagementClass myCpu = new ManagementClass("win32_Processor");  //获取系统CPU处理器
                    ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
                    foreach (ManagementObject myObject in myCpuConnection)
                    {
                        if (myObject.Properties["Processorid"] != null)
                        {
                            strCpu = myObject.Properties["Processorid"].Value.ToString();   //获取CPU序列号
                            break;
                        }
                    }
                }
                catch { }
                //如果实在取不到
                if (string.IsNullOrWhiteSpace(strCpu))
                {
                    strCpu = "notGetCPU";
                }
                return strCpu;
            }
        }
    }
}
