using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchants : Villager
{
    public override ChestType CanOpen()
    {
        return ChestType.Merchant;
    }
}
