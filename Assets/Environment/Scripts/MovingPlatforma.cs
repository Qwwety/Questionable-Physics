using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforma : MonoBehaviour
{
    [SerializeField] private Transform[] MovingsPoints;
    [SerializeField] private float MovingSpeed;
    private Vector3 NextPosition;

    private void Start()
    {
        NextPosition = MovingsPoints[0].position;
    }
    private void Update()
    {
        MovingPlatform();
    }

    private void MovingPlatform()
    {
        if (transform.position==MovingsPoints[0].transform.position)
        {
            NextPosition = MovingsPoints[1].position;
        }
        if(transform.position == MovingsPoints[1].transform.position)
        {
            NextPosition = MovingsPoints[0].position;
        }

        transform.position = Vector2.MoveTowards(transform.position, NextPosition, MovingSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(MovingsPoints[0].position, MovingsPoints[1].position);
    }
}
