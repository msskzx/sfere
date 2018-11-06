using System;
using UnityEngine;

public class RegionControlloer : MonoBehaviour
{

    private float speed, spawnInterval, destroyAfter;
    public GameObject[] regions;
    public GameObject[] sferes;
    private Vector3 spawnValues;
    private int region;
    private int regionLength;

    void Start()
    {
        region = 0;
        regionLength = 100;
        speed = 10.0f;
        spawnInterval = 0.3f;
        destroyAfter = 4.0f;
        spawnValues = new Vector3(10, 0.5f, 30.0f);
        InvokeRepeating("SpawnSfere", 2.0f, spawnInterval);
    }

    void Update()
    {
        if (CheckRegionStart())
        {
            region = (region + 1) % regions.Length;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void SpawnRegion()
    {

    }

    private void SpawnSfere()
    {
        int sfereIndex = UnityEngine.Random.Range(0, sferes.Length);
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        GameObject sfere = Instantiate(sferes[sfereIndex]) as GameObject;

        sfere.transform.SetParent(transform);
        sfere.transform.position = spawnPosition;
        Destroy(sfere, destroyAfter);
    }   

    Boolean CheckRegionStart()
    {
        return transform.position.z % regionLength == 0;
    }

}
