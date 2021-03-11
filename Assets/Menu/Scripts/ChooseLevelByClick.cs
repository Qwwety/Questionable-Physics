using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelByClick : MonoBehaviour
{
    [SerializeField] private int LvlToLoad;
   public void ChooseLvl()
   {
        SceneManager.LoadScene(LvlToLoad);
   }
}
