namespace OBP200_RolePlayingGame;

public class Room
{
    public string Type { get; private set; }
    public string Label { get; private set; }

    public Room(string type, string label)
    {
        Type = type; 
        Label = label;
    }
}

public class BossRoom : Room
{
    public Enemy Boss { get; private set; }

    public BossRoom(string label, Enemy boss) : base("boss", label)
    {
        Boss = boss;
    }

    public void EnterRoom()
    {
        Console.WriteLine($"Du har gått in i: {Label}");
        Console.WriteLine($"En kraftfull boss dyker upp: {Boss.Name}");
    }
}
