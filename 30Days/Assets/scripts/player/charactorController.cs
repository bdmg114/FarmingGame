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

    [Header("Point")]
    public Transform plane;

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
        put_plane();
    }

    public void put_plane()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Vector3 p = snapToGrid(hit.point);
            plane.position = p;
            Debug.Log(p);
        }
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
    }\

    float dis(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(Mathf.)
    }

    Vector3 snapToGrid(Vector3 pos)
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, pos)) <= 1)
        {
            return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
        }
        else
        {
            return Vector3.zero;
        }
    }
}
