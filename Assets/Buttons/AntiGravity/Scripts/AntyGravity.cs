using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntyGravity : MonoBehaviour
{
    public bool IsIce;
    private GameObject[] Water;
    private bool IsAntyGravity=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsIce==false)
        {
            Water = GameObject.FindGameObjectsWithTag("Water");
            try
            {
                if (IsAntyGravity == false && collision.tag == "Player")
                {
                    IsAntyGravity = true;
                    for (int i = 0; i <= Water.Length; i++)
                    {
                        Water[i].GetComponent<Rigidbody2D>().gravityScale = -1;

                    }

                }
                else if (IsAntyGravity == true && collision.tag == "Player")
                {
                    IsAntyGravity = false;
                    for (int i = 0; i <= Water.Length; i++)
                    {
                        Water[i].GetComponent<Rigidbody2D>().gravityScale = 1;

                    }

                }
            }
            catch
            {

            }
        }
    }
}
