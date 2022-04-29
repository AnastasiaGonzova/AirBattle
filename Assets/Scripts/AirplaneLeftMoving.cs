using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AirBattle.Classes;

public class AirplaneLeftMoving : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D body;
    public WhichPlayer player;
    public Airplane airplane;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = WhichPlayer.Player1;
        airplane = new Airplane("Airplane A", 100, 80, 1, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = 0;
        if (player == WhichPlayer.Player1 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            moveY = Input.GetAxis("Vertical");
            body.MovePosition(body.position - Vector2.down * speed * moveY * Time.deltaTime);
        } 
    }
}
