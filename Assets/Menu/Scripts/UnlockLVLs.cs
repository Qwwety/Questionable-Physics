using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLVLs : MonoBehaviour
{
    public int UnlockedLvls=1;
    [SerializeField] private Button[] Lvls;
    void Start()
    {
        try
        {
            PlayerData PlayerData = SaveLoad.LoadLvl();
            UnlockedLvls = PlayerData.OpendLvls;
        }
        catch
        {

        }
        for (int i=0;i< UnlockedLvls; i++)
        {
            Lvls[i].interactable = true;
        }
    }
}
