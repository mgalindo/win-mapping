﻿using System;
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

        public class CallbackObjectForJs
        {
            public void showMessage(string msg)
            {
                MessageBox.Show(msg);
            }

            public void geocodedLatLong(string lat, string lng)
            {
                MessageBox.Show(String.Format("lat={0}, long={1}", lat, lng) );
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mapServer = Properties.Settings.Default.MapServer;

            webView = new WebView(mapServer, new BrowserSettings());
            //webView = new WebView("http://cnn.com", new BrowserSettings());
            webView.PropertyChanged += new PropertyChangedEventHandler(webView_PropertyChanged);
            webView.Dock = DockStyle.Fill;

            webView.RegisterJsObject("callbackObj", new CallbackObjectForJs());

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

            doCreateMarker(edId.Text, edLatitude.Text, edLongitude.Text, ckbxDragabble.Checked, edDescription.Text, cbbxType.Text, cbbxAddress.Text);
        }

        private void doCreateMarker(string id, string latitude, string longitude, bool dragabble, string description, string markerType, string address)
        {
            setNewMarkerId(id);
            setNewMarkerCoords(latitude, longitude);
            setNewMarkerDraggable(dragabble);
            setNewMarkerDescription(description);
            setNewMarkerType(markerType);
            setNewMarkerAddress(address);

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
            //doCreateMarker("1", "33.4054515", "-86.7634086", false, "BHM South Plant", "Plant");
            //doCreateMarker("2", "33.487593", "-86.825162", false, "Truck 145", "Truck");
            //doCreateMarker("3", "33.507831", "-86.8122149", false, "Regions Field", "Job Site");
            //callScopeFunction("simulateMarkers", "");

            doSimulateMarkers();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            edLatitude.Text = "";
            edLongitude.Text = "";

            //setNewMarkerAddress(cbbxAddress.Text);

            doGetAddressCoordinates(cbbxAddress.Text);

            //System.Threading.Thread.Sleep(100);

            //edLatitude.Text = getElementValue("edLatitude");

            //edLongitude.Text = getElementValue("edLongitude");
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            MapObject mapObject = new MapObject();
            mapObject.id = edId.Text;
            mapObject.latitude = edLatitude.Text;
            mapObject.longitude = edLongitude.Text;
            mapObject.description = edDescription.Text;
            mapObject.address = cbbxAddress.Text;
            mapObject.markerType = cbbxType.Text;
            mapObject.options.draggable = ckbxDragabble.Checked;

            string JSONString;

            JSONString = mapObject.ToJSON();

            doAddUpdateMarker2(JSONString);

        }

        //------------------NEW API-----------------

        private void doAddUpdateMarker2(string JSONMapObject)
        {
            //JsclickElementById("btnAddUpdateMarker");
            ExecuteScript(String.Format("dotNetAPI.addUpdateMarker({0})", JSONMapObject));
        }

        private void ExecuteScript(string script)
        {
            //callScopeFunction("setNewMarkerID", String.Format("\"{0}\"", id));
            webView.ExecuteScript(script);
        }

        private void setNewMarkerId(string id)
        {
            //callScopeFunction("setNewMarkerID", String.Format("\"{0}\"", id));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerID(\"{0}\")", id));
        }

        private void setNewMarkerCoords(string Latitude, string Longitude)
        {
            //callScopeFunction("setNewMarkerCoords", String.Format("\"{0}\", \"{1}\"", Latitude, Longitude));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerCoords(\"{0}\", \"{1}\")", Latitude, Longitude));
        }

        private void setNewMarkerDraggable(bool dragabble)
        {
            //callScopeFunction("setNewMarkerDraggable", String.Format("{0}", dragabble.ToString().ToLower()));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerDraggable({0})", dragabble.ToString().ToLower()));
        }

        private void setNewMarkerDescription(string description)
        {
            //callScopeFunction("setNewMarkerDescription", String.Format("\"{0}\"", description));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerDescription(\"{0}\")", description));
        }

        private void setNewMarkerType(string markerType)
        {
            //callScopeFunction("setNewMarkerType", String.Format("\"{0}\"", markerType));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerType(\"{0}\")", markerType));
        }

        private void setNewMarkerAddress(string address)
        {
            //callScopeFunction("setNewMarkerAddress", String.Format("\"{0}\"", address));
            ExecuteScript(String.Format("dotNetAPI.setNewMarkerAddress(\"{0}\")", address));
        }

        private void doAddUpdateMarker()
        {
            //JsclickElementById("btnAddUpdateMarker");
            ExecuteScript(String.Format("dotNetAPI.addUpdateMarkerFromScope()", ""));
        }

        private void doremoveMarker(string id)
        {
            //callScopeFunction("removeMarker", String.Format("\"{0}\"", id));
            ExecuteScript(String.Format("dotNetAPI.removeMarker(\"{0}\")", id));
        }

        private void doremoveAllMarkers()
        {
            //callScopeFunction("removeAllMarkers", "");
            ExecuteScript(String.Format("dotNetAPI.removeAllMarkers()", ""));
        }

        private void doGetAddressCoordinates(string address)
        {
            //callScopeFunction("getNewMarkerAddressCoords", String.Format("", ""));
            //the registerd callback will be executed with the correct coords
            ExecuteScript(String.Format("dotNetAPI.getAddressCoords(\"{0}\")", address));
        }

        private void doSimulateMarkers()
        {
            //callScopeFunction("simulateMarkers", "");
            ExecuteScript(String.Format("dotNetAPI.simulateMarkers()", ""));
        }
            
    }
}
