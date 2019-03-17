using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();//getpooledobject function from the objectpool script, we are re using it here
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();//getpooledobject function from the objectpool script, we are re using it here
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);//spawns this coin a small distances beside coin1
        coin2.SetActive(true);


        GameObject coin3 = coinPool.GetPooledObject();//getpooledobject function from the objectpool script, we are re using it here
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);//spawns this coin a small distances beside coin2
        coin3.SetActive(true);

    }

}
