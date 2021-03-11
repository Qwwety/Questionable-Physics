using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    [SerializeField] private float SpawnRangeX;
    [SerializeField] private float SpawnRangeY;
    [SerializeField] private GameObject WaterMolecul;
    [SerializeField] private float SpawnRepiat;

    private void Start()
    {
        for (int i = 0; i < SpawnRepiat; i++)
        {
            Vector2  SpawnPoint = new Vector2(SpawnRangeX+Random.Range(-SpawnRangeX, SpawnRangeX), SpawnRangeY);
            Instantiate(WaterMolecul, SpawnPoint, Quaternion.identity);
        }
    }
}
