using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI Character;
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }
    private void Update()
    {
        if(SelectedVillager !=null)
        {
            Character.text = SelectedVillager.GetType().Name;
            Character.color = Color.green;
        }
        else
        {
            Character.text = "Choose Villager";
        }
       
    }
}
