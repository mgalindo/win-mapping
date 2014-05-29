using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;

namespace Test
{
    public partial class Form1 : Form
    {
        WebView webView;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webView = new WebView("http://mgevodev64-vm:5000", new BrowserSettings());
            webView.PropertyChanged += new PropertyChangedEventHandler(webView_PropertyChanged);
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);
        }
        
        // Get all propertys from https://github.com/chillitom/CefSharp/blob/master/CefSharp/BrowserCore.h
        void webView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BrowserCore core = (BrowserCore)sender;
            switch (e.PropertyName)
            {
                case "IsBrowserInitialized":
                    //core.IsBrowserInitialized
                    break;
                case "Title":
                    //core.Title
                    break;
                case "Address":
                    //core.Address
                    break;
                case "CanGoBack":
                    //core.CanGoBack
                    break;
                case "CanGoForward":
                    //core.CanGoForward;
                    break;
                case "IsLoading":
                    //core.IsLoading
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsSetElemeValuetById("edID", "xxx");
            JsclickElementById("btnApply");

            JsSetElemeValuetById("edLatitude", "33.43017060777363"); //edLatitude.Text);
            JsclickElementById("btnApply");

            JsSetElemeValuetById("edLongitude", "-86.69652080535889"); //edLongitude.Text);
            JsclickElementById("btnApply");

            JsclickElementById("btnAddUpdateMarker");
        }

        private void JsclickElementById(string elementID)
        {
            JsFireEvent("document.getElementById('" + elementID + "')", "click");

        }

        public void JsFireEvent(string getElementQuery, string eventName)
        {
            webView.ExecuteScript(@"
                                function fireEvent(element,event) {
                                    var evt = document.createEvent('HTMLEvents');
                                    evt.initEvent(event, true, true ); // event type,bubbling,cancelable
                                    element.dispatchEvent(evt);                                 
                                }
                                " + String.Format("fireEvent({0}, '{1}');", getElementQuery, eventName));
        }

        private void JsSetElemeValuetById(string elementID, string elementValue)
        {

            webView.ExecuteScript(String.Format("document.getElementById('{0}').value='{1}'", elementID, elementValue));

//            dynamic textboxes = (JSObject)webView.ExecuteJavascriptWithResult("document.getElementsByTagName('input')");
//            int len = textboxes.length;
//            for (int i = 0; i < len; i++)
//            {
//                textboxes[i].value = elementValue;
//            }

        }

        private void btnClearMarkers_Click(object sender, EventArgs e)
        {
            clearAllMarkers();
        }

        private void clearAllMarkers()
        {
            JsclickElementById("btmRemoveAllMarkers");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webView.ShowDevTools();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

    }
}
