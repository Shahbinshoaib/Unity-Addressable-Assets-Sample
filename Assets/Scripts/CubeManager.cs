using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CubeManager : MonoBehaviour
{
    public int numberOfCubes = 1000;
    private string cubeKey = "CubePrefab";

    void Start()
    {
        //Spawns cube in the scene
        GenerateCubes();
    }

    async void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), Random.Range(-50f, 50f));

            // Load cube prefab from Addressable
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(cubeKey, spawnPosition, Quaternion.identity);
            await handle.Task;

        }
    }


}
