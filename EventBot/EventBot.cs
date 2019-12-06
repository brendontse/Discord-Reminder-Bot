using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace EventBot
{
    class EventBot
    {
        static void Main(string[] args) 
            => new GoonBot().MainAsync().GetAwaiter().GetResult();


        private async Task MainAsync()
        {
        }
    }
}
