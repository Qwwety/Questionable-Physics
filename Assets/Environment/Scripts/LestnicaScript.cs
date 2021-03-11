using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LestnicaScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Movment Movment;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==10)
        {
            Movment.IsClimbing = true;
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==10)
         {
            Movment.IsClimbing = false;
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
         }
    }
}
