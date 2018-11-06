using System;
using UnityEngine;

public class RegionControlloer : MonoBehaviour {

    private float speed, spawnInterval, destroyAfter;
    public GameObject[] regions;
    public GameObject[] sferes;
    private Vector3 spawnValues;
    private int region = 0;

    void Start () {
        speed = 10.0f;
        spawnInterval = 0.3f;
        destroyAfter = 4.0f;
        spawnValues = new Vector3(10, 0.5f, 30.0f);
        InvokeRepeating("SpawnSfere", 2.0f, spawnInterval);
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

    void Update () {
        
	}

    void FixedUpdate()
    {
        transform.Translate(Vector3.back  * speed * Time.deltaTime);
    }
}
