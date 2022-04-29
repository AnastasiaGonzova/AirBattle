using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AirBattle.Classes;

public class AirplaneRightMoving : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D body;
    public WhichPlayer player;
    public Airplane airplane;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = WhichPlayer.Player2;
        airplane = new Airplane("Airplane B", 60, 120, 1, 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = 0;
        if (player == WhichPlayer.Player2 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            moveY = Input.GetAxis("Vertical");
            body.MovePosition(body.position - Vector2.down * speed * moveY * Time.deltaTime);
        }
    }
}
