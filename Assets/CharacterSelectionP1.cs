using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterSelectionP1 : MonoBehaviour
{
    public bool ABSOSelect;
    public bool TinmanSelect;
    public bool FeatherweightSelect;
    public bool WernerSelect;
    public bool ZyariaSelect;

    public bool GameStart;

    public GameObject ABSO;
    public GameObject Tinman;
    public GameObject Featherweight;
    public GameObject Werner;
    public GameObject Zyaria;
    // Start is called before the first frame update
    void Update()
    {
        CheckBools();
        if (GameStart == true)
        {
            if (ABSOSelect == true)
            {
                ABSO.SetActive(true);
                Tinman.SetActive(false);
                Featherweight.SetActive(false);
                Werner.SetActive(false);
                Zyaria.SetActive(false);
            }
            if (TinmanSelect == true)
            {
                ABSO.SetActive(false);
                Tinman.SetActive(true);
                Featherweight.SetActive(false);
                Werner.SetActive(false);
                Zyaria.SetActive(false);
            }
            if (FeatherweightSelect == true)
            {
                ABSO.SetActive(false);
                Tinman.SetActive(false);
                Featherweight.SetActive(true);
                Werner.SetActive(false);
                Zyaria.SetActive(false);
            }
            if (WernerSelect == true)
            {
                ABSO.SetActive(false);
                Tinman.SetActive(false);
                Featherweight.SetActive(false);
                Werner.SetActive(true);
                Zyaria.SetActive(false);
            }
            if (ZyariaSelect == true)
            {
                ABSO.SetActive(false);
                Tinman.SetActive(false);
                Featherweight.SetActive(false);
                Werner.SetActive(false);
                Zyaria.SetActive(true);
            }
        }

    }
    private void CheckBools()
    {
        //check all saves and load 
        int value = PlayerPrefs.GetInt("ABSOSelect");
        ABSOSelect = value == 1;

        int value1 = PlayerPrefs.GetInt("TinmanSelect");
        TinmanSelect = value1 == 1;

        int value2 = PlayerPrefs.GetInt("FeatherweightSelect");
        FeatherweightSelect = value2 == 1;

        int value3 = PlayerPrefs.GetInt("WernerSelect");
        WernerSelect = value3 == 1;

        int value4 = PlayerPrefs.GetInt("ZyariaSelect");
        ZyariaSelect = value4 == 1;


    }
    public void SaveBools()
    {
        //save all the characters selected
        PlayerPrefs.SetInt("ABSOSelect", ABSOSelect ? 1 : 0);
        PlayerPrefs.SetInt("TinmanSelect", TinmanSelect ? 1 : 0);
        PlayerPrefs.SetInt("FeatherweightSelect", FeatherweightSelect ? 1 : 0);
        PlayerPrefs.SetInt("WernerSelect", WernerSelect ? 1 : 0);
        PlayerPrefs.SetInt("ZyariaSelect", ZyariaSelect ? 1 : 0);

    }

    public void SelectABSO()
    {
        ABSOSelect = true;
        TinmanSelect = false;
        FeatherweightSelect = false;
        WernerSelect = false;
        ZyariaSelect = false;
        SaveBools();
    }
    public void SelectTinman()
    {
        ABSOSelect = false;
        TinmanSelect = true;
        FeatherweightSelect = false;
        WernerSelect = false;
        ZyariaSelect = false;
        SaveBools();
    }
    public void SelectFeatherweight()
    {
        ABSOSelect = false;
        TinmanSelect = false;
        FeatherweightSelect = true;
        WernerSelect = false;
        ZyariaSelect = false;
        SaveBools();
    }
    public void SelectWerner()
    {
        ABSOSelect = false;
        TinmanSelect = false;
        FeatherweightSelect = false;
        WernerSelect = true;
        ZyariaSelect = false;
        SaveBools();
    }
    public void SelectZyaria()
    {
        ABSOSelect = false;
        TinmanSelect = false;
        FeatherweightSelect = false;
        WernerSelect = false;
        ZyariaSelect = true;
        SaveBools();
    }

}