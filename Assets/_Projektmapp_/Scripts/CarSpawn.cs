using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class CarSpawn : MonoBehaviour
{
    // Reference to starting points for car prefabs
    [SerializeField]
    private Transform westSpawnPoint;
    
    [SerializeField]
    private Transform eastSpawnPoint;

    // The actual starting piont, either westSpawnPoint or eastSpawnPoint;
    private Transform startingPoint;

    // Array of car prefabs
    [SerializeField]
    private GameObject[] carPrefabs;

    // Speed of car
    [SerializeField]
    private int speed = 14; // Roughly 50 km/h

    int numberOfCars;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCars = carPrefabs.Length; // Get number of car prefabs in array
        InvokeRepeating("spawnCar", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Give the spawned car a velocity;
        //carClone.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void spawnCar()
    {
        int randomCar = Random.Range(0, numberOfCars - 1); // Randomly selects a car from prefab array.
        int randomStartingPoint = Random.Range(1, 11);

        Debug.Log("Index of car is: " + randomCar);
        Debug.Log("Index of starting point is: " + randomStartingPoint);

        // Check if index of random car chosen is even
        if (randomStartingPoint % 2 == 0)
            startingPoint = westSpawnPoint;
        else
            startingPoint = eastSpawnPoint;

        GameObject carClone = Instantiate(carPrefabs[randomCar], startingPoint);
    }
}
