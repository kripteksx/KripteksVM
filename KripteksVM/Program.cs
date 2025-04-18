﻿using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace KripteksVM
{
    public static class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {

            string path = Application.StartupPath;
            string dosya_yolu = path + "\\debug.log";

            // Now delete the file.
            if (File.Exists(dosya_yolu))
            {
                File.Delete(dosya_yolu);
            }

#if ANYCPU
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
#endif

            string LocalCachePath = Application.StartupPath + "\\Cache";
            if (Directory.Exists(LocalCachePath)) Directory.Delete(LocalCachePath, true);
            Directory.CreateDirectory(LocalCachePath);

            Cef.EnableHighDPISupport();

            var settings = new CefSettings()
            {
                CachePath = LocalCachePath
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            SplashForm splashForm = new SplashForm();
            Application.Run(splashForm);

            //var browser = new KripteksVMB();
            //Application.Run(browser);

            return 0;
        }
    }
}
