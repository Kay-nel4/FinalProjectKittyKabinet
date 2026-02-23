using System.Globalization;
using MapTest2Locations.Data;
using MapTest2Locations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;


namespace MapTest2Locations.Controllers;

public class Map : Controller
{
    // GET
    public IActionResult Index()
    {
  
        var locations = new List<MapLocation>();
        
            
        using (var parser = new TextFieldParser("wwwroot/mapData/WalgreensLocations.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            
            while (!parser.EndOfData)
            {
                var parts = parser.ReadFields();

                var lat = parts[0].Replace("\"", "").Replace(",", "");
                var lon = parts[1].Replace("\"", "").Replace(",", "");
                var address = parts[2].Replace("\"", "").Replace(",", "");

                if (string.IsNullOrWhiteSpace(lat) || string.IsNullOrWhiteSpace(lon))
                    continue;

                var kabinetId = 0;
                if (address.Contains("7520"))
                    kabinetId = 1;
                else if (address.Contains("2415"))
                    kabinetId = 2;
                else if (address.Contains("14040"))
                    kabinetId = 3;
                else if (address.Contains("5171"))
                    kabinetId = 4;
                else if (address.Contains("3455"))
                    kabinetId = 5;
                else if (address.Contains("3909"))
                    kabinetId = 6;
                else if (address.Contains("1615"))
                    kabinetId = 7;
                else if (address.Contains("1120"))
                    kabinetId = 8;
                else if (address.Contains("9125"))
                    kabinetId = 9;
                
                locations.Add(new MapLocation
                {
                    Latitude = double.Parse(lat, CultureInfo.InvariantCulture),
                    Longitude = double.Parse(lon, CultureInfo.InvariantCulture),
                    LocationName = address,
                    kabinetlocation = address,
                    KabinetNumber = kabinetId
                });


            }
        }
        return View(locations);
    }
    
    
}