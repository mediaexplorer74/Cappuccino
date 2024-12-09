using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cappuccino.App
{

    public static class RequestConstants
    {
        public static IEnumerable<string> UserDefaults() => new[]
        {
        "last_seen", "online", "photo_100", "photo_200"
    };
    }
}
