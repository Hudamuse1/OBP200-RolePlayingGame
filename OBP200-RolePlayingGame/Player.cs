using System; 
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Player
{
    // attributes (replaces Player[index] )
    public string Name { get; private set; }
    
    public string ClassName { get; private set; }
    public int HP { get;private set; }
    public int MaxHP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    public int Gold { get; private set; }
    public int XP { get; private set; }
    public int Level { get; private set; }

    public int Potions { get; private set; }

    public List<string> Inventory { get; private set; }
    // constructor (replace StartNewGameyer setup)
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
    // corresponds to switch(k) in StartNewGame
    private void SetStartingStats(string className)
    {
        switch (className)
        {
            case "Warrior":
                MaxHP = 40;
                Attack = 7;
                Defense = 5;
                Potions = 2;
                Gold = 15; 
                break;
            
            case "Mage":
                MaxHP = 28;
                Attack = 10; 
                Defense = 2;
                Potions = 2;
                Gold = 15;
                break;
            
            case "Rogue":
                MaxHP = 32;
                Attack = 8; 
                Defense = 3;
                Potions = 3;
                Gold = 20;
                break;
            
            default:
                MaxHP = 40;
                Attack = 7; 
                Defense = 5;
                Potions = 2;
                Gold = 15;
                break;
            
        }
        HP = MaxHP;
    }
    // replaces Player [10] inevntory string 
    private void InitializeInventory()
    {
        Inventory.Add("Wooden Sword");
        Inventory.Add("Cloth Armor");
    }
    // replace AppleDamageToPlayer()
    public TakeDamage(int dmg);
    {
        HP -= Math.Max(0, dmg);
        HP = Math.Max(0, HP);
    }
    // used by potion and rest room 
    public int Heal(int amount)
    {
        int oldHp = HP;
        HP = Math.Min(MaxHP, HP + amount);
        return HP - oldHp; 
    }
    // replaces Player [2] = maxhp 
    public void FullHeal ()
    {
        HP=MaxHP
    }
    // replaces UsePotions()
    public bool UsePotions()
    {
        if (Potions <= 0)
        {
            Console.WriteLine("Du har inga drycker kvar. ");
            return false;
        }

        Potions--;
        int healed = Heal(12); 
       
        Console.WriteLine($"Du dricker en dryck och återfår {healed} HP.");
      
        return true;
    }
    // replaces AddPlayerGold()
    public void AddGold(int amount);
    {
        Gold += Math.Max(0,amount); 
    }
    extracted from TryBuy()
    public bool SpendGold(int cost)
    {
        if (Gold >= cost)
        {
            Gold -= cost;
            return true;
        }
        return false;
        
    }
    // replces AddPlayerXP()
    public void AddXP(int amount);
    {
        XP +=Math.Max (0, amount)
        CheckLevelUp();
    }
    // replaces MaybeLevelUp()
    private void CheckLevelUp()
    {
        int nextThreshold =
            Level == 1 ? 10 :
            Level == 2 ? 25 :
            Level == 3 ? 45 :
            Level * 20; 
if (XP >= nextThreshold)
    Level++;
switch (ClassName)
{
    case "Warrior":
        MaxHP += 6;
        Attack += 2; 
        Defense += 2;
        break;
    
    case "Mage":
        MaxHP += 4;
        Attack += 4;
        Defense += 1;
        break;
    
    case "Rogue":
        MaxHP += 5;
        Attack += 3; 
        Defense += 1;
        break;
   
    default:
        MaxHP += 4;
        Attack += 3;
        Defense += 1;
        break;
}
FullHeal();
Console.WriteLine($" Du når nivå {{Level}}! Värden ökade och HP återställd.");
    }
    
   }

// used by treasure and loot 
public void AddItem(string item)
    {
      Inventory.Add(item);
    }

public bool RemooveItem(string item)
{
    return Inventroy.Remove(item); 
}

public bool HasItem(string item)
{
    return Iventory.Contains(item); 
}

public void ShowInventory()
{
    Console.WriteLine("Invenotry:");
    foreach (var item in Inventory)
    {
        Console.WriteLine("- " + item);
    }
}
// replace death check 
public bool isDead()
{
    return HP <= 0;
}
// replaces ShowStatus() 
public void ShowStatus()
{
    Console.WriteLine("====== PLAYER ======");
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Class: {ClassName}");
    Console.WriteLine($"Level: {Level}");
    Console.WriteLine($"HP: {HP}/{MaxHP}");
    Console.WriteLine($"ATK: {Attack}");
    Console.WriteLine($"DEF: {Defense}");
    Console.WriteLine($"Gold: {Gold}");
    Console.WriteLine($"XP: {XP}");
    Console.WriteLine($"Potions: {Potions}");
    Console.WriteLine("====================");
}


    
