namespace GlobalErrorApi.Models; 
public class Driver
{
    public int Id {get; set;}

    public String Name {get; set;} = string.Empty; 

    public int DriverNumber {get;set;}

    public bool Enabled {get;set;}
}
