using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float CamRange;
    [SerializeField] private float CamPosition;
    private Camera Camera;

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, CamRange);
        Camera.orthographicSize = CamPosition;
    }
}
