using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    bool IsMovementEnable = true;

    [SerializeField]
    float movementspeed = 1;

    player playerControl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMovementEnable) return;
        var move = Vector3.zero;
        if (playerControl == player.one)
        {
            if (Input.GetKey(KeyCode.A))
            {
                move += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                move += Vector3.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                move += Vector3.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move += Vector3.down;
            }
        }
        else if (playerControl == player.two)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                move += Vector3.right;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                move += Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                move += Vector3.down;
            }
        }
        transform.position += move * Time.deltaTime * movementspeed;
    }

    public void ChangeControl(player playerControl)
    {
        this.playerControl = playerControl;
    }
}




public enum player
{
    one,
    two
}
