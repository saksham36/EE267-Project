
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fires;
    [SerializeField] Vector3 spawnValues;
    [SerializeField] float spawnWait;
    [SerializeField] float spawnLeastWait;
    [SerializeField] float spawnMostWait;
    [SerializeField] int startWait;

    [SerializeField] float fireHeight;
    [SerializeField] int maxFires = 10;
    [SerializeField] bool stop;


    private int randFire;
    public int numFires;

    void Start()
    {   
        foreach(var fire in fires)
        {
            fire.tag = "Fire";
        }
        StartCoroutine(waitSpawner());
        numFires = 0;
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        
        while(!stop && getNumFires() < maxFires)
        {
            randFire = Random.Range(0, fires.Length); //assuming only 2 kinds of fire
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), fireHeight, Random.Range(-spawnValues.z, spawnValues.z));
            //push object to scene
            Instantiate(fires[randFire], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
            numFires += 1;
            // Debug.Log("Number of fires: "+ numFires);
            yield return new WaitForSeconds(spawnWait);
        }
    }
    
    int getNumFires()
    {
        return numFires;
    }

    public void decNumFires()
    {
        numFires -= 1;
    }
	
}
