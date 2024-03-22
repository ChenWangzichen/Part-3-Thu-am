using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public Villager[] villagers = new Villager[3];

    private void Start()
    {
        Instance = this;
        StartCoroutine(Select());
    }
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    public void SelectV(int value)
    {
        SetSelectedVillager(villagers[value]);
    }

    IEnumerator Select()
    {
        yield return 0;
        SelectV(0);
    }

    public void SliderValueChanged(Single value)
    {
        SelectedVillager.transform.localScale = Vector3.one * value;
    }

    //private void Update()
    //{
    //    if(SelectedVillager != null)
    //    {
    //        currentSelection.text = SelectedVillager.GetType().ToString();
    //    }
    //}
}
