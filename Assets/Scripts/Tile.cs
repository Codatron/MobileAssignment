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
    private Target target;

    public bool isOccupied = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        tileHighlight.SetActive(true);
    }

    private void OnMouseUp()
    {
        if (CompareTag("Tile") == true && !gameManager.isGameOver)
        {
            if (isOccupied)
            {
                target.RevealMe();
                gameObject.SetActive(false);
                //Debug.Log("You found me!");
            }
            else
            {
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
