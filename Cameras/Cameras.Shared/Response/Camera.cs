using System;
using System.Collections.Generic;
using System.Text;

namespace Cameras.Response
{
    public class Camera
    {
        public int ID { get; }
        public string Name { get; }
        public float Lat { get; }
        public float Lng { get; }

        public Camera(int id, string name, float lat, float lng)
        {
            ID = id;
            Name = name;
            Lat = lat;
            Lng = lng;
        }
    }
}
