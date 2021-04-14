using System;
using bronzetti.christian._4h.RompicapOttoRegine.Models;
using System.Text.Encodings;
namespace bronzetti.christian._4h.RompicapOttoRegine
{
    class Program
    {
        static void Main(string[] args)
        {
            Scacchiera BobbyFischer = new Scacchiera(8);
            BobbyFischer.RisolviRompicapo();
            Console.WriteLine(BobbyFischer.StampaScacchiera());
        }
    }
}
