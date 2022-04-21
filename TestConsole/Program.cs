using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Http.Lib;

namespace TestConsole {

    class Program {

        static async Task Main(string[] args) {

            var http = new Http.Lib.HttpMethod();
            http.AddHeader("x-prs-api-key", "1a2411a8e00e41c9aa78b82afbd4ce66307aafae61d94b118a0c32663e2c3d5f");
            await http.Get("http://doudsystems.net/prs6db/api/users");
            var users = http.Deserialize("User[]");
        }
    }
}

