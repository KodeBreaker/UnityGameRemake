using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledAmount;
    //we create a list of objects
    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start()
    {

        pooledObjects = new List<GameObject>();
        //we use this to fill up list
        for (int i = 0; i < pooledAmount; i++)
        {
            //casts a game object
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false); //dont wanted activated in scene so its set false
            pooledObjects.Add(obj); //add object into list
        }
    }

    //get a pooled object
    public GameObject GetPooledObject()
    {
        //search list to find an object not yet active
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false); //dont wanted activated in scene so its set false
        pooledObjects.Add(obj); //add object into list
        return obj;

    }

}
