using System.ComponentModel.DataAnnotations;

namespace MapTest2Locations.Models;

public class MessageBoard
{
    public int PostNumber { get; set; }
    public string UserName { get; set; }
    public string Post {get; set;}
    public int KabinetNumber { get; set; }
    public DateTime TimeCreated {get; set;}
}