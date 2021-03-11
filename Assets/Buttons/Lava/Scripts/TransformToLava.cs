using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToLava : MonoBehaviour
{
    [SerializeField] private MeshRenderer _MeshRenderer;
    [SerializeField] private Material LavaMaterial;
    [SerializeField] private Material WaterMaterial;
    private GameObject[] Lava;
    private bool IsLava = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lava = GameObject.FindGameObjectsWithTag("Water");
        try
        {
            if (IsLava == false && collision.tag == "Player")
            {
                IsLava = true;
                for (int i = 0; i <= Lava.Length; i++)
                {
                    Lava[i].layer = 13;
                    _MeshRenderer.material = LavaMaterial;
                }

            }
            else if (IsLava == true && collision.tag == "Player")
            {
                IsLava = false;
                for (int i = 0; i <= Lava.Length; i++)
                {
                    Lava[i].layer = 4;
                    _MeshRenderer.material = WaterMaterial;
                }

            }
        }
        catch
        {

        }
    }

}
