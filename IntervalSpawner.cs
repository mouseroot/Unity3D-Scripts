using UnityEngine;
using System.Collections;


public class IntervalSpawner : MonoBehaviour {

    public enum SpawnChoice
    {
        All,
        Random
    }

    public float delayTime;
    public float spawnInterval;
    public float spawnSize;
    public GameObject[] spawnList;
    public SpawnChoice spawnType;

	// Use this for initialization
	void Start () {
        Invoke("spawnObject", delayTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }

    private void spawnObject()
    {
        Vector3 position = Vector3.zero;
        if (spawnType == SpawnChoice.All)
        {
            for (int i = 0; i < spawnList.Length; i++)
            {
                Instantiate(spawnList[i], position, transform.rotation);
            }
        }
        else if (spawnType == SpawnChoice.Random)
        {
            int listSize = spawnList.Length;
            int randomSel = Random.Range(0, listSize);
            Instantiate(spawnList[randomSel], position, transform.rotation);
        }
        Invoke("spawnObject", spawnInterval);

    }
}
