using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Cameras.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new Cameras.App(), args);
            host.Run();
        }
    }
}
