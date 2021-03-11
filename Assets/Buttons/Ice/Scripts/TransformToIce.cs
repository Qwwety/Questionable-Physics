using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToIce : MonoBehaviour
{
    [SerializeField] private MeshRenderer _MeshRenderer;
    [SerializeField] private Material IceMaterial;
    [SerializeField] private Material WaterMaterial;
    [SerializeField] private AntyGravity _AntyGravity;
    private GameObject[] Ice;
    private GameObject[] LavaIce;
    private bool IsIce = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ice = GameObject.FindGameObjectsWithTag("Water");
        LavaIce = GameObject.FindGameObjectsWithTag("Lava");

        try
        {
            if (Ice.Length != 0)
            {
                if (IsIce == false && collision.tag == "Player")
                {
                    Debug.Log("ToIce");
                    _AntyGravity.IsIce = true;
                    IsIce = true;
                    for (int i = 0; i <= Ice.Length; i++)
                    {
                        Ice[i].layer = 12;
                        _MeshRenderer.material = IceMaterial;
                    }

                }
                else if (IsIce == true && collision.tag == "Player")
                {
                    Debug.Log("ToWater");
                    _AntyGravity.IsIce = false;
                    IsIce = false;
                    for (int i = 0; i <= Ice.Length; i++)
                    {
                        Ice[i].layer = 4;
                        _MeshRenderer.material = WaterMaterial;
                    }

                }
            }
            else if (LavaIce.Length != 0)
            {

                if (IsIce == false && collision.tag == "Player")
                {
                    Debug.Log("ToIce");
                    _AntyGravity.IsIce = true;
                    IsIce = true;
                    for (int i = 0; i <= LavaIce.Length; i++)
                    {
                        LavaIce[i].layer = 12;
                        _MeshRenderer.material = IceMaterial;
                    }
                }

                else if (IsIce == true && collision.tag == "Player")
                {
                    Debug.Log("ToWater");
                    _AntyGravity.IsIce = false;
                    IsIce = false;
                    for (int i = 0; i <= LavaIce.Length; i++)
                    {
                        LavaIce[i].layer = 4;
                        _MeshRenderer.material = WaterMaterial;
                    }

                }

            }

        }
        catch
        {

        }
    }
}