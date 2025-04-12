using CefSharp.WinForms;

namespace KripteksVM.Concrete
{
    interface IChromiumBrowser
    {
        void Init(string sHost, string sCID, string sSID, string sAID, string sHID);
        void DisplayOutput(string output);
        void Refresh(string host, string CID, string SID, string AID, string HID);
        void SetElementValueById(ChromiumWebBrowser myCwb, string eltId, string setValue);
        string GetElementValueById(ChromiumWebBrowser myCwb, string eltId);
        string GetJSValueByVar(ChromiumWebBrowser myCwb, string var);

    }
}
