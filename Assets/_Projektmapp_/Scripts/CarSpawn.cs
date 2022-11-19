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

    bool evenCar; // Determines if index of carPrefabs is an even number.

    // Start is called before the first frame update
    void Start()
    {
        numberOfCars = carPrefabs.Length; // Get number of car prefabs in array
    }

    // Update is called once per frame
    void Update()
    {
        int randomCar = Random.Range(0, numberOfCars - 1); // Randomly selects a car from prefab array.

        // Check if index of random car chosen is even
        if (randomCar % 2 == 0)
            evenCar = true;

        // If randomCar = even, spawn the prefab at the westSpawnpoint, otherwise at eastSpawnPoint.
        if (evenCar)
            startingPoint = westSpawnPoint;
        else 
            startingPoint = eastSpawnPoint;

        GameObject carClone = Instantiate(carPrefabs[randomCar], startingPoint);

        //Give the spawned car a velocity;
        carClone.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
