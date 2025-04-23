using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    //Manually set Speed Boost Limit
    int speedBoostLimit = 3;
    public GameObject speedBoost;
    public GameObject floorPlane;       

    public Vector3 speedBoostSize = new Vector3(1f, 1f, 1f);
   
    PlayerMovement player;
    public List<Vector3> spawnPoints = new List<Vector3>();
    int randomIndex;

    void Start()
    {
        //Coords
        spawnPoints.Add(new Vector3(1, .5f, 0));
        spawnPoints.Add(new Vector3(8.5f, .5f, 1.5f));
        spawnPoints.Add(new Vector3(2.25f, .5f, 8.95f));
        spawnPoints.Add(new Vector3(6.5f, .5f, 9.2f));
        spawnPoints.Add(new Vector3(-1.8f, .5f, 2.9f));
        spawnPoints.Add(new Vector3(-7.9f, .5f, 0));
        spawnPoints.Add(new Vector3(-13.5f, .5f, -1.9f));

        for(int i = 0; i < speedBoostLimit; i++)
        {
            randomIndex = Random.Range(0, 6);

            Instantiate(speedBoost, spawnPoints[randomIndex], Quaternion.identity);
        }
        
        player = GetComponent<PlayerMovement>();
        
    }


   

    private void OnTriggerEnter(Collider other)
    {
       

        if(other.CompareTag("speedboost"))
        {
            
            StartCoroutine(TempSpeedBoost());
            Destroy(other.gameObject);
        }
        
    }

    public IEnumerator TempSpeedBoost()
    {
        player.speedBoost = 2f;
        yield return new WaitForSeconds(5f);
        player.speedBoost = 1f;
    }

}

