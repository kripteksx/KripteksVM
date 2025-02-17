// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;

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
            File.Delete(dosya_yolu);

#if ANYCPU
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
#endif

            string LocalCachePath = Application.StartupPath + "\\Cache";
            if(Directory.Exists(LocalCachePath)) Directory.Delete(LocalCachePath, true);
            Directory.CreateDirectory(LocalCachePath);

            // Programmatically enable DPI Aweness
            // Can also be done via app.manifest or app.config
            // https://github.com/cefsharp/CefSharp/wiki/General-Usage#high-dpi-displayssupport
            // If set via app.manifest this call will have no effect.
            Cef.EnableHighDPISupport();

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
                CachePath = LocalCachePath
            };

            //Example of setting a command line argument
            //Enables WebRTC
            // - CEF Doesn't currently support permissions on a per browser basis see https://bitbucket.org/chromiumembedded/cef/issues/2582/allow-run-time-handling-of-media-access
            // - CEF Doesn't currently support displaying a UI for media access permissions
            //
            //NOTE: WebRTC Device Id's aren't persisted as they are in Chrome see https://bitbucket.org/chromiumembedded/cef/issues/2064/persist-webrtc-deviceids-across-restart
            settings.CefCommandLineArgs.Add("enable-media-stream");
            //https://peter.sh/experiments/chromium-command-line-switches/#use-fake-ui-for-media-stream
            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream");
            //For screen sharing add (see https://bitbucket.org/chromiumembedded/cef/issues/2582/allow-run-time-handling-of-media-access#comment-58677180)
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capturing");

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            //var splash = new SplashForm();
            //Application.Run(splash);
            
            
            var browser = new KripteksVMB();
            Application.Run(browser);

            return 0;
        }
    }
}
