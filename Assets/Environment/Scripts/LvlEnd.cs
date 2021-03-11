using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlEnd : MonoBehaviour
{
    [SerializeField] private int NextLVL;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (NextLVL>SceneManager.sceneCount)
            {
                 SaveLoad.SaveLvl(NextLVL);
            }

            SceneManager.LoadScene(NextLVL);
        }
    }
}
