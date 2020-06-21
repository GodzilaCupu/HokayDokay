using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool wasJustClicked = true;
    bool canMove;

    Rigidbody2D rbPlayer;

    public Transform boundrayHolder;

    Boundary playerBondray;

    Collider2D Player;


    // Use this for initialization
    void Start()
    {
        Player = GetComponent<Collider2D>();

        rbPlayer = GetComponent<Rigidbody2D>();

        playerBondray = new Boundary(boundrayHolder.GetChild(0).position.y,
                                     boundrayHolder.GetChild(1).position.y,
                                     boundrayHolder.GetChild(2).position.x,
                                     boundrayHolder.GetChild(3).position.x);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if (Player.OverlapPoint(mousePos))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {

                Vector2 clampMovePos = new Vector2(Mathf.Clamp(mousePos.x, playerBondray.Left, playerBondray.Right),
                                                   Mathf.Clamp(mousePos.y, playerBondray.Down, playerBondray.Up));


                rbPlayer.MovePosition(clampMovePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }
}
