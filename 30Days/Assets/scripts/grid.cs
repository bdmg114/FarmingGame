using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    private Grid g;

    public LayerMask groundLayer;

    public static grid instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        g = GetComponentInChildren<Grid>();
    }

    public Vector3Int grid_pos(Vector3 ori)
    {
        Vector3Int gridpos = g.WorldToCell(ori);
        return gridpos;
    }

    public Vector3 place(Vector3 ori)
    {
        return check_ground(g.CellToWorld(grid_pos(ori)));
    }

    public Vector3 check_ground(Vector3 ori)
    {
        RaycastHit hit;
        if (Physics.Raycast(ori, Vector3.down, out hit, 1000f, groundLayer))
        {
            return hit.point;
        }
        else
        {
            return ori;
        }
    }
}
