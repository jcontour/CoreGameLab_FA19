using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeCoins : MonoBehaviour
{
    public GameObject coin_prefab;
    int coinCount = 0;
    public Slider coinDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
        
    public void addCoins() {
        GameObject c = Instantiate(coin_prefab, new Vector2(Random.Range(-6f, 6f), 5), Quaternion.identity);
        coinCount++;
        updateSlider(coinCount);

        if (coinCount > 30) {
            removeCoin();
        }
    }

    public void removeCoin() {
        GameObject[] coins;
        coins = GameObject.FindGameObjectsWithTag("coin");

        int randomCoin = Random.Range(0, coinCount-1);
        Destroy(coins[randomCoin]);
        coinCount--;
        updateSlider(coinCount);
    }

    void updateSlider(int count) {
        coinDisplay.value = count;
    }
}
