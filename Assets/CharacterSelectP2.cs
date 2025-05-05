using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public bool ABSOP2Select;
    public bool TinmanP2Select;
    public bool FeatherweightP2Select;
    public bool WernerP2Select;
    public bool ZyariaP2Select;

    public bool GameStart;

    public GameObject ABSOP2;
    public GameObject TinmanP2;
    public GameObject FeatherweightP2;
    public GameObject WernerP2;
    public GameObject ZyariaP2;
    // Start is called before the first frame update
    void Update()
    {

        if (GameStart == true)

            CheckBools();
        if (ABSOP2Select == true)
        {
            ABSOP2.SetActive(true);
            TinmanP2.SetActive(false);
            FeatherweightP2.SetActive(false);
            WernerP2.SetActive(false);
            ZyariaP2.SetActive(false);
            Debug.Log("WTF");
        }
        if (TinmanP2Select == true)
        {
            ABSOP2.SetActive(false);
            TinmanP2.SetActive(true);
            FeatherweightP2.SetActive(false);
            WernerP2.SetActive(false);
            ZyariaP2.SetActive(false);
        }
        if (FeatherweightP2Select == true)
        {
            ABSOP2.SetActive(false);
            TinmanP2.SetActive(false);
            FeatherweightP2.SetActive(true);
            WernerP2.SetActive(false);
            ZyariaP2.SetActive(false);
        }
        if (WernerP2Select == true)
        {
            ABSOP2.SetActive(false);
            TinmanP2.SetActive(false);
            FeatherweightP2.SetActive(false);
            WernerP2.SetActive(true);
            ZyariaP2.SetActive(false);
        }
        if (ZyariaP2Select == true)
        {
            ABSOP2.SetActive(false);
            TinmanP2.SetActive(false);
            FeatherweightP2.SetActive(false);
            WernerP2.SetActive(false);
            ZyariaP2.SetActive(true);
        }
    }
    Debug.Log("I called");
    }
private void CheckBools()
{
    //check all saves and load 
    int value = PlayerPrefs.GetInt("ABSOP2Select");
    ABSOP2Select = value == 1;

    int value1 = PlayerPrefs.GetInt("TinmanP2Select");
    TinmanP2Select = value1 == 1;

    int value2 = PlayerPrefs.GetInt("FeatherweightP2Select");
    FeatherweightP2Select = value2 == 1;

    int value3 = PlayerPrefs.GetInt("WernerP2Select");
    WernerP2Select = value3 == 1;

    int value4 = PlayerPrefs.GetInt("ZyariaP2Select");
    ZyariaP2Select = value4 == 1;

}
public void SaveBools()
{
    //save all the characters selected
    PlayerPrefs.SetInt("ABSOP2Select", ABSOP2Select ? 1 : 0);
    PlayerPrefs.SetInt("TinmanP2Select", TinmanP2Select ? 1 : 0);
    PlayerPrefs.SetInt("FeatherweightP2Select", FeatherweightP2Select ? 1 : 0);
    PlayerPrefs.SetInt("WernerP2Select", WernerP2Select ? 1 : 0);
    PlayerPrefs.SetInt("ZyariaP2Select", ZyariaP2Select ? 1 : 0);

}

public void SelectABSOP2()
{
    ABSOP2Select = true;
    TinmanP2Select = false;
    FeatherweightP2Select = false;
    WernerP2Select = false;
    ZyariaP2Select = false;
    SaveBools();
}
public void SelectTinmanP2()
{
    ABSOP2Select = false;
    TinmanP2Select = true;
    FeatherweightP2Select = false;
    WernerP2Select = false;
    ZyariaP2Select = false;
    SaveBools();
}
public void SelectFeatherweightP2()
{
    ABSOP2Select = false;
    TinmanP2Select = false;
    FeatherweightP2Select = true;
    WernerP2Select = false;
    ZyariaP2Select = false;
    SaveBools();
}
public void SelectWernerP2()
{
    ABSOP2Select = false;
    TinmanP2Select = false;
    FeatherweightP2Select = false;
    WernerP2Select = true;
    ZyariaP2Select = false;
    SaveBools();
}
public void SelectZyariaP2()
{
    ABSOP2Select = false;
    TinmanP2Select = false;
    FeatherweightP2Select = false;
    WernerP2Select = false;
    ZyariaP2Select = true;
    SaveBools();
}

}
