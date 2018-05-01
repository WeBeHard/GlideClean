using UnityEngine;

public class Grid : MonoBehaviour {

    public Transform cell;

    // store used shapes
    public static Transform[,] grid = new Transform[10, 10];

    // Use this for initialization
    void Start () {
        DrawGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DrawGrid ()
    {
        if (cell)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Instantiate(cell, new Vector3(j + cell.transform.position.x, i + cell.transform.position.y, 0), Quaternion.identity);
                }
            }
        }
    }

    public static bool IsLineFull(int row)
    {
        for(int col = 0; col < 10; col++)
        {
            if(grid[col, row] == null)
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsComplete(int y)
    {
        for(int x = 0; x < 10; ++x)
        {
            if(grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    //public bool IsOverLimit(Block block)
    //{

    //}
}