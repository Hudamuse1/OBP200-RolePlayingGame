namespace OBP200_RolePlayingGame;

public class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Xp { get; private set; }
    public int Gold { get; private set; }

    public Enemy(string name, int health, int attack, int defense, int xp, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack; 
        Defense = defense;
        Xp = xp;
        Gold = gold;
    }

    public void TakeDamage(int damge)
    {
       int actualDamage = damge - Defense;
       if (actualDamage < 0)
       {
           actualDamage = 0;
       }
       Health -= actualDamage;
       if (Health <= 0)
       {
           Health = 0;
       }
    }
    public bool isDead()
    {
        return Health <= 0;
    }
} // Implementerat inkapsling i Enemy och lagt till TakeDamage och IsDead metoder . 