namespace Challenge3.Data;
public class Badge
{
    public int ID { get; set; }
    public List<string> Doors { get; set; } = new List<string>();

    public Badge() {}

    public Badge(List<string> doors)
    {
        Doors = doors;
    }
}
