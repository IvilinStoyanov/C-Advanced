using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{

    public Soldier(string name, int age, double experiance, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experiance;
        this.Endurance = endurance;
    }


    public IDictionary<string, IAmmunition> Weapons { get; }

    public string Name { get; }

    public  int Age { get; }

    public  double Experience { get; }

    private double endurance;

    public double Endurance
    {
        get { return endurance; }
        private set
        {
            endurance = value;
        }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void Regenerate()
    {
        throw new System.NotImplementedException();
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    //public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}