using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour {

	Rigidbody2D rbody;

	public static Vector3 cursorPosition;


	void Start()
	{
		rbody = GetComponent<Rigidbody2D> ();
		Cursor.visible = false;
	}

	void Update()
	{
        Vector2 move_vector;
        Vector2 start_vector;
        Debug.Log(cursorPosition);

        if (BoardController.instance.currentState == States.PLAYERONETURN)
        {
            start_vector = new Vector2(-6, -27);
            rbody.MovePosition(rbody.position + start_vector * Time.deltaTime * 15);

            move_vector = new Vector2(Input.GetAxisRaw("Joy1 X"), Input.GetAxisRaw("Joy1 Y"));
            rbody.MovePosition(rbody.position + move_vector * Time.deltaTime * 15);
            cursorPosition = rbody.position;
        }
        if(BoardController.instance.currentState == States.PLAYERTWOTURN)
        {
            start_vector = new Vector2(50, 2);
            rbody.MovePosition(rbody.position + start_vector * Time.deltaTime * 15);

            move_vector = new Vector2(Input.GetAxisRaw("Joy2 X"), Input.GetAxisRaw("Joy2 Y"));
            rbody.MovePosition(rbody.position + move_vector * Time.deltaTime * 15);
            cursorPosition = rbody.position;
        }

       

	
	}


}
