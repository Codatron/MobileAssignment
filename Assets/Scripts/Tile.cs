using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Vector2 tilePos;
    [SerializeField] private GameObject tileHighlight;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreManager scoreManager;
    private Target target;

    public bool isOccupied = false;
    public bool hasBeenPicked = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        tilePos = transform.position;
    }

    public void ConnectToTarget(GameObject target)
    {
        isOccupied = true;
        this.target = target.GetComponent<Target>();
    }

    public void SetColor(bool isOffset)
    {
        rend.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseOver()
    {
        if (!gameManager.isGameOver)
            tileHighlight.SetActive(true);
    }

    private void OnMouseUp()
    {
        if (!gameManager.isGameOver)
        {
            if (!hasBeenPicked)
            {
                gameManager.tries++;
                scoreManager.AddMouseClicks(gameManager.tries);
            }

            if (isOccupied)
            {
                hasBeenPicked = true;
                target.RevealMe();
                gameObject.SetActive(false);
                //Debug.Log("You found me!");
            }
            else
            {
                hasBeenPicked = true;
                gameObject.SetActive(false);
                //Debug.Log("Try again!");
            }

        }
    }

    private void OnMouseExit()
    {
        tileHighlight.SetActive(false);
    }

}
