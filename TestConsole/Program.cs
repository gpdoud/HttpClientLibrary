using System;
using System.Threading.Tasks;
using Http.Lib;

namespace TestConsole {

    class Program {

        static async Task Main(string[] args) {

            var http = new HttpMethod();
            http.AddHeader("x-prs-api-key", "ABCXYZ");
            http.Get("http://doudsystems.net/api/users");
        }
    }
}

