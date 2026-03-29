namespace OBP200_RolePlayingGame;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Xp { get; set; }
    public int Gold { get; set; }

    public Enemy(string name, int health, int attack, int defense, int xp, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack; 
        Defense = defense;
        Xp = xp;
        Gold = gold;
    }
} // Refaktorerade enemy till Enemy klass