using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace Test
{
    class MapObjectOptions
    {
        public bool draggable { get; set; } 
    }

    class MapObject
    {
        public MapObject()
            {
                this.options = new MapObjectOptions();
            }

        public string id { get; set; } 
        public string description { get; set; } 
        public string latitude { get; set; } 
        public string longitude { get; set; } 
        public string address { get; set; } 
        public string markerType { get; set; }
        public MapObjectOptions options { get; set; }

        public string ToJSON()
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(this);
        }
    }
}
