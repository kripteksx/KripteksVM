using CefSharp.DevTools.IO;
using CefSharp.WinForms;
using KripteksVM.Controls;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KripteksVM.Controls
{
    public class ControlBrowser
    {
        public ChromiumWebBrowser browser;

        public bool boMainFrameLoaded = false;

        //public string sHost = "";

        public void fbInit(string sHost, string sCID, string sSID, string sAID, string sHID)
        {
            browser = new ChromiumWebBrowser(sHost + "/application.aspx?CID=" + sCID + "&SID=" + sSID + "&AID=" + sAID + "&HID=" + sHID);
            
            
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.LoadError += OnBrowserLoadError;
            browser.LoadingStateChanged += Browser_LoadingStateChanged;


            var version = string.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}",
               Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);

#if NETCOREAPP
            // .NET Core
            var environment = string.Format("Environment: {0}, Runtime: {1}",
                System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant(),
                System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
#else
            // .NET Framework
            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var environment = String.Format("Environment: {0}", bitness);
#endif

            DisplayOutput(string.Format("{0}, {1}", version, environment));


        }
        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                boMainFrameLoaded = true;
                //All Resources Have Loaded
            }
            else
            {
                boMainFrameLoaded = false;
            }
        }
        private void OnBrowserLoadError(object sender, LoadErrorEventArgs e)
        {
            //Actions that trigger a download will raise an aborted error.
            //Aborted is generally safe to ignore
            if (e.ErrorCode == CefErrorCode.Aborted)
            {
                return;
            }

            var errorHtml = string.Format("<html><body><h2>Failed to load URL {0} with error {1} ({2}).</h2></body></html>",
                                              e.FailedUrl, e.ErrorText, e.ErrorCode);

            _ = e.Browser.SetMainFrameDocumentContentAsync(errorHtml);

        }
        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var b = ((ChromiumWebBrowser)sender);

            //this.InvokeOnUiThreadIfRequired(() => b.Focus());
        }
        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }
        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            //this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            //this.InvokeOnUiThreadIfRequired(() => Text = Text);// + " - " + args.Title);
        }
        public void DisplayOutput(string output)
        {
            //this.InvokeOnUiThreadIfRequired(() => outputLabel.Text = output);
        }
        public void fbRefresh(string sHost, string sCID, string sSID, string sAID, string sHID)
        {
            LoadUrl(sHost + "/application.aspx?CID=" + sCID + "&SID=" + sSID + "&AID=" + sAID + "&HID=" + sHID);
        }
        private void LoadUrl(string urlString)
        {
            // No action unless the user types in some sort of url
            if (string.IsNullOrEmpty(urlString))
            {
                return;
            }

            Uri url;

            var success = Uri.TryCreate(urlString, UriKind.RelativeOrAbsolute, out url);

            // Basic parsing was a success, now we need to perform additional checks
            if (success)
            {
                // Load absolute urls directly.
                // You may wish to validate the scheme is http/https
                // e.g. url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps
                if (url.IsAbsoluteUri)
                {
                    browser.LoadUrl(urlString);

                    return;
                }

                // Relative Url
                // We'll do some additional checks to see if we can load the Url
                // or if we pass the url off to the search engine
                var hostNameType = Uri.CheckHostName(urlString);

                if (hostNameType == UriHostNameType.IPv4 || hostNameType == UriHostNameType.IPv6)
                {
                    browser.LoadUrl(urlString);

                    return;
                }

                if (hostNameType == UriHostNameType.Dns)
                {
                    try
                    {
                        var hostEntry = Dns.GetHostEntry(urlString);
                        if (hostEntry.AddressList.Length > 0)
                        {
                            browser.LoadUrl(urlString);

                            return;
                        }
                    }
                    catch (Exception)
                    {
                        // Failed to resolve the host
                    }
                }
            }

            // Failed parsing load urlString is a search engine
            var searchUrl = "https://www.google.com/search?q=" + Uri.EscapeDataString(urlString);

            browser.LoadUrl(searchUrl);
        }


        public void SetElementValueById(ChromiumWebBrowser myCwb, string eltId, string setValue)
        {
            string script = string.Format("(function() {{document.getElementById('{0}').value='{1}';}})()", eltId, setValue);
            myCwb.ExecuteScriptAsync(script);
        }
        public string GetElementValueById(ChromiumWebBrowser myCwb, string eltId)
        {

            string script = string.Format("(function() {{return document.getElementById('{0}').value;}})();",
                 eltId);
            JavascriptResponse jr = myCwb.EvaluateScriptAsync(script).Result;
            return jr.Result.ToString();
        }
        public string GetJSValueByVar(ChromiumWebBrowser myCwb, string var)
        {
            string sReturn = "0";
            try
            {
                string script = string.Format("(function() {{let sR=''; let i=0; if (" + var + " instanceof Array){{  for(i in "+var+") {{sR+="+ var + "[i].toString()+':';}} return sR;}}else{{sR="+var+".toString(); return sR;}}}})();", var);
                JavascriptResponse jr = myCwb.EvaluateScriptAsync(script).Result;
               

                if (jr.Result != null)
                {
                    sReturn = jr.Result.ToString();
                }
            }
            catch
            {

            }
            return sReturn;
        }


    }
}
