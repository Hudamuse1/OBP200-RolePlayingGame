namespace OBP200_RolePlayingGame;

public class Player
{
    public string Name { get; private set; }
    public string ClassName { get; private set; }
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Gold { get; private set; }
    public int XP { get; private set; }
    public int Level { get; private set; }
    public int Potions { get; private set; }
    public List<string> Inventory { get; private set; }

    public Player(string name, string className)
    {
        Name = name;
        ClassName = className;
        Inventory = new List<string>();
        XP = 0;
        Level = 1;
        SetStartingStats(className);
        InitializeInventory();
    }

    private void SetStartingStats(string className)
    {
        switch (className)
        {
            case "Warrior": MaxHP = 40; Attack = 7; Defense = 5; Potions = 2; Gold = 15; break;
            case "Mage":    MaxHP = 28; Attack = 10; Defense = 2; Potions = 2; Gold = 15; break;
            case "Rogue":   MaxHP = 32; Attack = 8; Defense = 3; Potions = 3; Gold = 20; break;
            default:        MaxHP = 40; Attack = 7; Defense = 5; Potions = 2; Gold = 15; break;
        }
        HP = MaxHP;
    }

    private void InitializeInventory()
    {
        Inventory.Add("Wooden Sword");
        Inventory.Add("Cloth Armor");
    }

    public void TakeDamage(int dmg)
    {
        HP -= Math.Max(0, dmg);
        HP = Math.Max(0, HP);
    }

    public int Heal(int amount)
    {
        int oldHp = HP;
        HP = Math.Min(MaxHP, HP + amount);
        return HP - oldHp;
    }

    public void FullHeal()
    {
        HP = MaxHP;
    }

    public bool UsePotion()
    {
        if (Potions <= 0)
        {
            Console.WriteLine("Du har inga drycker kvar.");
            return false;
        }
        Potions--;
        int healed = Heal(12);
        Console.WriteLine($"Du dricker en dryck och återfår {healed} HP.");
        return true;
    }

    public void AddGold(int amount)
    {
        Gold += Math.Max(0, amount);
    }

    public bool SpendGold(int cost)
    {
        if (Gold >= cost) { Gold -= cost; return true; }
        return false;
    }

    public void AddXP(int amount)
    {
        XP += Math.Max(0, amount);
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int nextThreshold = Level == 1 ? 10 : Level == 2 ? 25 : Level == 3 ? 45 : Level * 20;
        if (XP >= nextThreshold)
        {
            Level++;
            switch (ClassName)
            {
                case "Warrior": MaxHP += 6; Attack += 2; Defense += 2; break;
                case "Mage":    MaxHP += 4; Attack += 4; Defense += 1; break;
                case "Rogue":   MaxHP += 5; Attack += 3; Defense += 1; break;
                default:        MaxHP += 4; Attack += 3; Defense += 1; break;
            }
            FullHeal();
            Console.WriteLine($"Du når nivå {Level}! Värden ökade och HP återställd.");
        }
    }

    public void AddItem(string item) { Inventory.Add(item); }

    public bool RemoveItem(string item) { return Inventory.Remove(item); }

    public bool HasItem(string item) { return Inventory.Contains(item); }

    public bool IsDead() { return HP <= 0; }

    public void ShowStatus()
    {
        Console.WriteLine($"[{Name} | {ClassName}]  HP {HP}/{MaxHP}  ATK {Attack}  DEF {Defense}  LVL {Level}  XP {XP}  Guld {Gold}  Drycker {Potions}");
        if (Inventory.Count > 0)
            Console.WriteLine($"Väska: {string.Join(", ", Inventory)}");
    }
}
