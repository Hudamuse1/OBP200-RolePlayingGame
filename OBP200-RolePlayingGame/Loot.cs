namespace OBP200_RolePlayingGame;

public class Loot
{
    public string Name { get; set; }
    public int GoldValue { get; set; }
    
    public Loot (string name, int goldValue)
        {
        Name = name;
        GoldValue = goldValue;
        }
}

public class RareLoot : Loot
{
    public RareLoot(string name) : base(name, 15)
    {
    }
}