using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public void SpawnCoins(Vector3 position, float groundWidth)
    {
        int random = Random.Range(1, 100);

        if (random < 50)
            return;

        int numberOfCoins = (int)Random.Range(3f, groundWidth);
        
        for(int i=0; i<numberOfCoins; i++)
        {
            GameObject coin = coinPooler.GetPooledObject();

            coin.transform.position = new Vector3(
                position.x+1 - (groundWidth/2) + i,
                position.y + 2,
                position.z);

            coin.SetActive(true);
        }
    }
}

    

