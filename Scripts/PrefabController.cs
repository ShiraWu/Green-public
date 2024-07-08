using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PrefabController : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject CloverPrefab;

    public Transform LT, RT, LB, RB;

    public int numberofObejcts = 50;

    public float minDistance = 0.5f;

    private int luckyNumber;

    public GameObject[] Flower_Big;
    public GameObject[] Flower_Middle;
    public GameObject[] Flower_Small;

    public Transform Spot_Big;
    public Transform Spot_Middle;
    public Transform Spot_Small;

    private GameObject Clover;

    void Start()
    {
        luckyNumber = Random.Range(0, 5);
        Debug.Log("Today's lucky number is: " + luckyNumber);
        Spawn();
        FLowerSpawn(luckyNumber);
    }

    private void Update()
    {
        
    }

    private void Spawn()
    {
        float minX = LT.position.x;
        float maxX = RT.position.x;
        float minZ = LT.position.z;
        float maxZ = LB.position.z;

        List<GameObject> spawnedPrefabs = new List<GameObject>();

        for (int i = 0; i < numberofObejcts; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(minX, maxX),
                0.0f,
                Random.Range(minZ, maxZ)
            );

            bool validPosition = true;
            foreach (GameObject prefab in spawnedPrefabs)
            {
                if (Vector3.Distance(randomPos, prefab.transform.position) < minDistance)
                {
                    validPosition = false;
                    break;
                }
            }

            if (validPosition)
            {
                GameObject randomPrefab = Prefabs[Random.Range(0, Prefabs.Length)];
                GameObject prefab = Instantiate(randomPrefab, randomPos, Quaternion.identity);
                spawnedPrefabs.Add(prefab);

                Transform prefabBone = prefab.transform.GetChild(0);
                prefabBone.GetComponent<RigBuilder>().enabled = false;
                prefabBone.GetComponent<RigBuilder>().enabled = true;
            }
        }


        Vector3 CLoverPos = new Vector3(
            Random.Range(minX, maxX),
            0.0f,
            Random.Range(minZ, maxZ)
        );

        Clover = Instantiate(CloverPrefab, CLoverPos, Quaternion.identity);
        Transform CloverBone = Clover.transform.GetChild(0);
        CloverBone.GetComponent<RigBuilder>().enabled = false;
        CloverBone.GetComponent<RigBuilder>().enabled = true;
    }

    private void FLowerSpawn(int i)
    {
        switch (i)
        {
            case 0:
                Instantiate(Flower_Big[0], Spot_Big.position, Quaternion.identity);
                Instantiate(Flower_Middle[0], Spot_Middle.position, Quaternion.identity);
                Instantiate(Flower_Small[0], Spot_Small.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(Flower_Big[1], Spot_Big.position, Quaternion.identity);
                Instantiate(Flower_Middle[1], Spot_Middle.position, Quaternion.identity);
                Instantiate(Flower_Small[1], Spot_Small.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Flower_Big[2], Spot_Big.position, Quaternion.identity);
                Instantiate(Flower_Middle[2], Spot_Middle.position, Quaternion.identity);
                Instantiate(Flower_Small[2], Spot_Small.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Flower_Big[3], Spot_Big.position, Quaternion.identity);
                Instantiate(Flower_Middle[3], Spot_Middle.position, Quaternion.identity);
                Instantiate(Flower_Small[3], Spot_Small.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Flower_Big[4], Spot_Big.position, Quaternion.identity);
                Instantiate(Flower_Middle[4], Spot_Middle.position, Quaternion.identity);
                Instantiate(Flower_Small[4], Spot_Small.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
