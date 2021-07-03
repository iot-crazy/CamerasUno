using System;
using System.Collections.Generic;
using System.Text;

namespace Cameras.Models.Request
{
    public class CamerasBase : RequestModelBase
    {
        const string uriPath = "/Cameras";

        public CamerasBase() : base(uriPath)
        { }

        public override Uri ToUri(Uri baseURL)
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();
            /*parms.Add(nameof(AppID), AppID);
            parms.Add("q", CityName);*/

            return BuildUri(baseURL, parms);
        }
    }
}
