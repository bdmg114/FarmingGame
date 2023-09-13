using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farm_manager : MonoBehaviour
{
    public static farm_manager instance;
    public int day;
    public int money;
    public Vector2 farm_ori;
    public int width;
    public int height;
    public int[,] farm_state; //y,x
    //-7, 7, -2
    //(6, 7, -2)
    //(-7, 7, -7)
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public bool isFarmable(Vector3 pos)
    {
        Vector2 grid_pos = new Vector2(grid.instance.grid_pos(pos).x, grid.instance.grid_pos(pos).z);
        bool isContained = (grid_pos.x >= farm_ori.x && grid_pos.x < farm_ori.x + width) &&
                   (grid_pos.y >= farm_ori.y && grid_pos.y < farm_ori.y + height);
        return isContained;

    }

    public Vector2Int farm_Pos(Vector3 pos)
    {
        if (isFarmable(pos))
        {
            Vector2 grid_pos = new Vector2(grid.instance.grid_pos(pos).x, grid.instance.grid_pos(pos).z);
            return new Vector2Int(Mathf.RoundToInt(grid_pos.x - farm_ori.x), Mathf.RoundToInt(grid_pos.y - farm_ori.y));
        }
        else
        {
            return new Vector2Int(-1, -1);
        }
    }

    public void Plant(Vector3 pos)
    {
        Vector2Int fp = farm_Pos(pos);
        if (fp != new Vector2Int(-1, -1))
        {
            farm_state[fp.y, fp.x] = 1;
            Debug.Log(farm_state);
        }
    }
}
