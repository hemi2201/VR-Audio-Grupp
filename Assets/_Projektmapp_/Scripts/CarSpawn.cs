using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    private Transform westCollisionPoint;
    
    [SerializeField]
    private Transform eastCollisionPoint;


    // The actual starting piont, either westSpawnPoint or eastSpawnPoint;
    private Transform startingPoint;

    // The actual ending point, either westCollisionPoint or eastCollisionPoint;
    private Transform collisionPoint;

    // Array of car prefabs
    [SerializeField]
    private GameObject[] carPrefabs;

    // Speed of car
    [SerializeField]
    private int speed = 14; // Roughly 50 km/h

    int numberOfCars; // Count of cars in prefab array

    int randomStartingPoint; // Random number that determines starting route of car

    [SerializeField] List<GameObject> spawnedCars = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        numberOfCars = carPrefabs.Length; // Get number of car prefabs in array

        StartCoroutine(spawnCar());
    }

    // Update is called once per frame
    void Update()
    {
        randomStartingPoint = Random.Range(1, 12);
    }

    IEnumerator spawnCar()
    {
        while (true)
        {
            int randomCar = Random.Range(0, numberOfCars - 1); // Randomly selects a car from prefab array.

            // Choose starting point depending on whether an even or odd number was generated
            if (randomStartingPoint % 2 == 0)
            {
                startingPoint = westSpawnPoint;
                collisionPoint = westCollisionPoint;
            }

            else
            {
                startingPoint = eastSpawnPoint;
                collisionPoint = eastCollisionPoint;
            }

            GameObject carClone = Instantiate(carPrefabs[randomCar], startingPoint);

            spawnedCars.Add(carClone);

            while (Vector3.Distance(carClone.transform.position, collisionPoint.position) > 1.0f)
            {
                carClone.transform.Translate(Vector3.forward * Time.deltaTime * speed);

                yield return null;
            }

            spawnedCars.Remove(carClone);
            Destroy(carClone);

            yield return null;
        }
    }

}
