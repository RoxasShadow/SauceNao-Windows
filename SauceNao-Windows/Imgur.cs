﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows {
  static class Imgur {
    public static string Upload(string path, string apiKey) {
      using (var w = new WebClient()) {
        w.Headers.Add("Authorization: Client-ID " + apiKey);
        var values = new NameValueCollection {
          { "image", Convert.ToBase64String(File.ReadAllBytes(@path)) }
        };

        string response = System.Text.Encoding.UTF8.GetString(w.UploadValues("https://api.imgur.com/3/upload", values));
        Console.WriteLine(response);
        dynamic dynObj = JsonConvert.DeserializeObject(response);
        return dynObj.data.link;
      }
    }
  }
}
