using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace DesktopApp.Handler
{
    internal class Download : IDownloadHandler
    {
               

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(@"C:\Users\" +
                            System.Security.Principal.WindowsIdentity.GetCurrent().Name +
                            @"\Downloads\" +
                            downloadItem.SuggestedFileName,
                        showDialog: true);
                }

            }
                
        }

        public bool OnDownloadUpdated(CefSharp.DownloadItem downloadItem)
        {
            return false;
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            
        }
    }

}
