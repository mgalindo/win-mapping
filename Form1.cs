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
            webView = new WebView("http://mgevodev64-vm:5000/embedded", new BrowserSettings());
            //webView = new WebView("http://cnn.com", new BrowserSettings());
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
            setNewMarkerId(edId.Text);
            setNewMarkerCoords(edLatitude.Text, edLongitude.Text);
            setNewMarkerDraggable(ckbxDragabble.Checked);

            doAddUpdateMarker();
        }

        private void btnRemoveMarker_Click(object sender, EventArgs e)
        {
            doremoveMarker(edId.Text);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            doremoveAllMarkers();
        }



        private void setNewMarkerId(string id)
        {
            callScopeFunction("setNewMarkerID", String.Format("\"{0}\"", id));
        }

        private void setNewMarkerCoords(string Latitude, string Longitude)
        {
            callScopeFunction("setNewMarkerCoords", String.Format("\"{0}\", \"{1}\"", Latitude, Longitude));
        }

        private void setNewMarkerDraggable(bool dragabble)
        {
            callScopeFunction("setNewMarkerDraggable", String.Format("{0}", dragabble.ToString().ToLower()));
        }

        private void doremoveMarker(string id)
        {
            callScopeFunction("removeMarker", String.Format("\"{0}\"", id));
        }

        private void doremoveAllMarkers()
        {
            callScopeFunction("removeAllMarkers", "");
        }

        public object EvaluateScript(string script)
        {
            return webView.EvaluateScript(script);
        }

        private void doRetrieveMarker(string id)
        {
            callScopeFunction("retrieveMarker", String.Format("\"{0}\"", id));
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            edLatitude.Text = "";
            edLongitude.Text = "";

            doRetrieveMarker(edId.Text);
            //We need a small delay to let the DOM get the changes
            System.Threading.Thread.Sleep(100);

            edLatitude.Text = getElementValue("edLatitude");

            edLongitude.Text = getElementValue("edLongitude");
            //doApply();
        }



        #region DOM manipulation Functions 

        private string getElementValue(string elementId) {
            object retObj = new Object();

            retObj = EvaluateScript(String.Format("document.getElementById(\"{0}\").value", elementId));

            string retStr = (string)retObj;
            return retStr;
        }

        private void doAddUpdateMarker()
        {
            JsclickElementById("btnAddUpdateMarker");
        }


        private void doApply()
        {
            JsclickElementById("btnApply");
        }

        private void doExecute()
        {
            JsclickElementById("btnEval");
        }

        private void callScopeFunction(string functionName, string parameters) 
        {
            JsSetElemeValuetById("edEval", String.Format("$scope.{0}({1})", functionName, parameters));
            doApply();
            doExecute();
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
        }

        private void btnClearMarkers_Click(object sender, EventArgs e)
        {
            clearAllMarkers();
        }

        private void clearAllMarkers()
        {
            JsclickElementById("btmRemoveAllMarkers");
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            webView.ShowDevTools();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            setNewMarkerId("1");
            setNewMarkerCoords("11", "12");
            setNewMarkerDraggable(true);
            doAddUpdateMarker();

            setNewMarkerId("2");
            setNewMarkerCoords("21", "22");
            setNewMarkerDraggable(true);
            doAddUpdateMarker();

            setNewMarkerId("3");
            setNewMarkerCoords("31", "32");
            setNewMarkerDraggable(true);
            doAddUpdateMarker();

            edId.Text = "1";
            edLatitude.Text = "";
            edLongitude.Text = "";

        }



    }
}
