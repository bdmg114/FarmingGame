using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorController : MonoBehaviour
{
    [Header("movement")]
    public Rigidbody rb;
    public float speed;
    public Vector3 input_axis;

    [Header("Animation")]
    public Animator ani;
    private string currentState;
    int dir;

    string[] wk = new string[] { "walk_front", "walk_back", "walk_side" };
    string[] id = new string[] { "idle_ront", "idle_back", "idle_side" };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        movement();
        set_direction();
    }

    public void movement()
    {
        input_axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + (Vector3)(input_axis * speed * Time.deltaTime));
    }

    public void set_direction()
    {
        if (input_axis.z < 0)
        {
            dir = 0;
        }
        else
        {
            dir = 2;
            if (input_axis.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (input_axis != Vector3.zero)
        {
            changeAnimationState(wk[dir]);
        }
        else
        {
            changeAnimationState(id[dir]);
        }
    }

    void changeAnimationState(string newState)
    {
        if (currentState == newState) return;

        ani.Play(newState);

        currentState = newState;
    }
}