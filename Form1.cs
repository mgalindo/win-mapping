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

        public class CallbackObjectForJs
        {
            public void showMessage(string msg)
            {
                MessageBox.Show(msg);
            }

            public void geocodedLatLong(string lat, string lng, string id)
            {
                MessageBox.Show(String.Format("lat={0}, long={1}, id={2}", lat, lng, id));
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


        private void btnRemoveMarker_Click(object sender, EventArgs e)
        {
            JSRemoveMarker(edId.Text);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            JSRemoveAllMarkers();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            edLatitude.Text = "";
            edLongitude.Text = "";

            doRetrieveMarker(edId.Text);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            webView.ShowDevTools();
        }


        private void bbtnRefresh_Click(object sender, EventArgs e)
        {
           webView.Reload();
        }


        private void button1_Click_2(object sender, EventArgs e)
        {

            JSSimulateMarkers();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            edLatitude.Text = "";
            edLongitude.Text = "";

            //The registerd Call back will be executed with the corrdinates
            JSGetAddressCoordinates(cbbxAddress.Text, edId.Text);
        }

        private void testButton_Click(object sender, EventArgs e)
        {

        }


        private void doRetrieveMarker(string id)
        {
            MapObject mapObject = JSRetrieveMarker(id);

            edId.Text = mapObject.id;
            edLatitude.Text = mapObject.latitude;
            edLongitude.Text = mapObject.longitude;
            ckbxDragabble.Checked = mapObject.options.draggable;
            edDescription.Text = mapObject.description;
            cbbxType.Text = mapObject.markerType;
            cbbxAddress.Text = mapObject.address;
        }


        //------------------NEW API-----------------

        private void ExecuteScript(string script)
        {
            webView.ExecuteScript(script);
        }

        public object EvaluateScript(string script)
        {
            return webView.EvaluateScript(script);
        }

        private void doCreateMarker(string id, string latitude, string longitude, bool dragabble, string description, string markerType, string address)
        {
            MapObject mapObject = new MapObject();
            mapObject.id = id;
            mapObject.latitude = latitude;
            mapObject.longitude = longitude;
            mapObject.description = description;
            mapObject.address = address;
            mapObject.markerType = markerType;
            mapObject.options.draggable = dragabble;

            string JSONString;

            JSONString = mapObject.ToJSON();

            JSAddUpdateMarker(JSONString);
        }

        private void JSAddUpdateMarker(string JSONMapObject)
        {
            ExecuteScript(String.Format("dotNetAPI.addUpdateMarker({0})", JSONMapObject));
        }

        private void JSGetAddressCoordinates(string address, string id)
        {
            //the registerd callback will be executed with the correct coords
            ExecuteScript(String.Format("dotNetAPI.getAddressCoords(\"{0}\", \"{1}\")", address, id));
        }


        private void JSRemoveMarker(string id)
        {
            ExecuteScript(String.Format("dotNetAPI.removeMarker(\"{0}\")", id));
        }


        private void JSRemoveAllMarkers()
        {
            ExecuteScript(String.Format("dotNetAPI.removeAllMarkers()", ""));
        }

        private MapObject JSRetrieveMarker(string id)
        {
            object retObj = new Object();

            retObj = EvaluateScript(String.Format("dotNetAPI.retrieveMarker(\"{0}\")", id));

            string JSONString = (string)retObj;

            MapObject mapObject  = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MapObject>(JSONString);

            return mapObject;
        }

        private void JSSimulateMarkers()
        {
            ExecuteScript(String.Format("dotNetAPI.simulateMarkers()", ""));
        }

    }
}
