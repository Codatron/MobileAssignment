using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int itemsFound = 0;

    [SerializeField] private Vector2 pos;
    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        pos = transform.position;
        gameObject.SetActive(false);
    }

    public void RevealMe()
    {
        gameObject.SetActive(true);
        itemsFound++;
        scoreManager.AddItemsFound(itemsFound);
    }
}
