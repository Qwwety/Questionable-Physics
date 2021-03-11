using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpikes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Destroy(gameObject);
        }
    }
}
