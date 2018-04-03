using System;
using System.Linq;
using System.Text;

public abstract class Weapon : IWeapon
{
    private IGem[] slots;
    private IRarity rarity;
    private int baseMinDamage;
    private int baseMaxDamage;

    protected Weapon(IRarity rarity,int minDamage, int maxDamage, int numberOfSlots,string name)
    {
        this.baseMinDamage = minDamage;
        this.baseMaxDamage = maxDamage;
        slots = new IGem[numberOfSlots];
        this.rarity = rarity;
        this.Name = name;

    }

    //4(DefaultMinDamage) * 3(Rarity) + 19(Strength) x 2 (StreghtToMinDamageConst) + 17(Agility) x 1 (AgilityToMinDamage)

    public int MinDamage { get { return (baseMinDamage * rarity.DamageMultiplier + TotalStrength * 2 + TotalAgility * 1); } }

    public int MaxDamage { get { return (baseMaxDamage * rarity.DamageMultiplier + TotalStrength * 3 + TotalAgility * 4); } }

    public string Name { get; }

    public int TotalStrength => slots.Where(s=>s!=null).Sum(s => s.Strength);

    public int TotalAgility => slots.Where(s=>s!=null).Sum(s => s.Agility);

    public int TotalVitality => slots.Where(s=>s!=null).Sum(s => s.Vitality);

    public void AddGem(int index,IGem gem){
        if(IsWithinSlotRange(index)){
            slots[index] = gem;
        }
    }

    public void RemoveGem(int index){
        if(IsWithinSlotRange(index)){
            slots[index] = null;
        }
    }

    private bool IsWithinSlotRange(int index){
        return index >= 0 && index < slots.Length;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.TotalStrength} Strength, +{this.TotalAgility} Agility, +{this.TotalVitality} Vitality");
        return sb.ToString();
    }
}

