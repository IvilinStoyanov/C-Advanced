using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunition(string ammution, int quantity);

    bool TryEquipSolider(ISoldier soldier);
}

