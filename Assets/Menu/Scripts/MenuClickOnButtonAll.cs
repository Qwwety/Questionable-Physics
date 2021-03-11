using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuClickOnButtonAll : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject LVLMenu;
    [SerializeField] private GameObject SelectLVLButton;
    [SerializeField] public Slider VolumeSlider;
    [SerializeField] private UnlockLVLs UnlockLVLs;

    public void NewGameClick()
    {
        UnlockLVLs.UnlockedLvls = 1;
        SaveLoad.SaveLvl(UnlockLVLs.UnlockedLvls);
        SaveLoad.SaveSound(VolumeSlider.value);
        SceneManager.LoadScene(1);
    }
    public void SettingsClick()
    {
        SettingsMenu.SetActive(!SettingsMenu.activeSelf);
        SelectLVLButton.SetActive(!SelectLVLButton.activeSelf);

    }
    public void LvLClick()
    {
        LVLMenu.SetActive(!LVLMenu.activeSelf);
    }
    public void ExitClick()
    {
        SaveLoad.SaveSound(VolumeSlider.value);
        SaveLoad.SaveLvl(UnlockLVLs.UnlockedLvls);
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SaveLoad.SaveLvl(UnlockLVLs.UnlockedLvls);
        SaveLoad.SaveSound(VolumeSlider.value);
        SceneManager.LoadScene(0);
    }
}
