namespace OBP200_RolePlayingGame;

public class Room
{
    public string Type { get; set; }
    public string Label { get; set; }

    public Room(string type, string label)
    {
        Type = type; 
        Label = label;
    }
}

public class BossRoom : Room
{
    public BossRoom(string label) : base("boss", label)
    {
        
    }
}