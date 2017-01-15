using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SauceNao_Windows {
  class Program {
    /* TODO: struct User; struct Picture; abstract class Sauce; class Sauces_GenericSauce */


    static void Main(string[] args) {
      Console.Title = "SauceNAO for Windows";

      if (args.Length < 3) {
        Console.WriteLine("Usage: SauceNao-Windows.exe <SAUCENAO_API_KEY> <IMGUR_API_KEY> <IMAGE_PATH> [PROXY IP:PORT]");
        Console.ReadLine();
        return;
      }

      string   SAUCENAO_API_KEY = args[0];
      string   IMGUR_API_KEY    = args[1];
      string   IMAGE_PATH       = args[2];
      WebProxy PROXY            = args.Length >= 4 ? new WebProxy(args[3]) : null;

      Console.WriteLine("The requested image is: " + IMAGE_PATH);
      if(!File.Exists(IMAGE_PATH)) {
        Console.WriteLine("Given file was not found.");
        Console.ReadLine();
        return;
      }
      
      Console.Write("Uploading...");
      string image = Imgur.Upload(IMAGE_PATH, IMGUR_API_KEY);
      Console.WriteLine(" done ({0})", image);

      List<Result> results = new SauceNao(SAUCENAO_API_KEY).Request(image, PROXY);
      results.RemoveAll(result => !result.HasRecognizableSauce());
  
      foreach(Result result in results) {
        Console.WriteLine(result.ToString() + "\n");
      }

      int resultsCount = results.Count;
      if(resultsCount > 0) {
        int resultsToOpen = resultsCount >= 3 ? 3 : resultsCount;

        Console.WriteLine("Opening results 0-{0}...", resultsToOpen);
        for(int i = 0; i < resultsToOpen; ++i) {
          System.Diagnostics.Process.Start(results[i].Response.Url);
        }
      }

      Console.ReadLine();
    }
  }
}
