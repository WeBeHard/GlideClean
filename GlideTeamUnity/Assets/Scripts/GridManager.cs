using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]

public class Column
{
    public Transform[] row = new Transform[10];
}

public class GridManager : MonoBehaviour {

	public Column[] gameGridCol = new Column[10];
	public List<int> fullColumns = new List<int>();
	public List<int> fullRows = new List<int>();

	Object test = new Object();
	public List<Object> testList = new List<Object> ();


	public bool InsideBorder(Vector2 pos)
	{
		return ((int)pos.x >= 0 && (int)pos.x < 10 && (int)pos.y >= 0);
	}


	IEnumerator CheckFullGrid(int i, int j)
    {
		/*
        for (int x = i; x < 10; x++)
        {
            if (IsColumnFull(x))
            {
                fullColumns.Add(x);
            }
        }

		for (int y = j; y < 10; y++)
		{
			if (IsRowFull(y))
			{
				fullRows.Add(y);
			}
		}*/
		if(IsColumnFull(i))
			fullColumns.Add(i);

		if (IsRowFull (j))
			fullRows.Add (j);
		
        for (int n = 0; n < fullRows.Count; ++n)
        {
            DeleteRow(fullRows[n]);
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartLineClearingSound(); //clear sound
			yield return new WaitForSeconds(GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().soundSource.clip.length);
        }

        for (int m = 0; m < fullColumns.Count; ++m)
        {
            DeleteColumn(fullColumns[m]);
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartLineClearingSound(); //clear sound
			yield return new WaitForSeconds(GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().soundSource.clip.length);
        }

        fullRows.Clear();
        fullColumns.Clear();
        //Spawn new shape? <- may not need this 
        yield break;
    }


    public bool IsRowFull(int y)
    {
        for (int x = 0; x < 10; ++x)
        {
           //if (gameGridCol[x].row[y] == null)
			if(Grid.grid[x,y] == null	)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteRow(int y)
    {
        scoreManager.scoreChart.UpdateScore(100); //add score, accomodate score modifer block
        for (int x = 0; x < 10; x++)
        {
        /*    Destroy(gameGridCol[x].row[y].gameObject);
            gameGridCol[x].row[y] = null;*/
			Grid.grid [x, y] = null;
        }
		Debug.Log ("Cleared Row: " + y);
    }

    public bool IsColumnFull(int x)
    {
        for (int y = 0; y < 10; ++y)
		{
			//if (gameGridCol[x].row[y] == null)
			if(Grid.grid[x,y] == null)
            {

                return false;
            }
        }
        return true;
    }

    public void DeleteColumn(int x)
    {
        scoreManager.scoreChart.UpdateScore(100); //add score, accomodate score modifer block
        for (int y = 0; y < 0; y++)
		{
			/*    Destroy(gameGridCol[x].row[y].gameObject);
            gameGridCol[x].row[y] = null;*/
			Destroy (Grid.grid [x, y].gameObject);
			Grid.grid [x, y] = null;
        }
		Debug.Log ("Cleared Column: " + x);
    }


	public static Vector2 roundVec2(Vector2 v)
    {
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y)); 
	}

	public bool IsValidGridPosition(Transform obj)
	{
		foreach (Transform child in obj) {



				Vector2 v = roundVec2 (child.position);

				if (!InsideBorder (v)) {
					return false;
				}

				if (gameGridCol [(int)v.x].row [(int)v.y] != null && gameGridCol [(int)v.x].row [(int)v.y] != obj) {
					
					return false;
				}

		}
		return true;
	}

	public bool IsMoveValid(Transform obj, int xShift, int yShift)
	{
		/*Vector2 block = roundVec2 (obj.position);
		block.x = block.x + xShift;
		block.y = block.y + yShift;
		if (block.x > 9 || block.y > 9 || block.x < 0 || block.y < 0)
			return false;
	
		if(Grid.grid[(int)(block.x), (int)(block.y)] != null && !Grid.grid[(int)(block.x), (int)(block.y)].IsChildOf(obj)){
			Debug.Log ("Collision at " + block.x + "," + block.y + ".");
			return false;
		}*/
		foreach (Transform child in obj) {
		Vector2 v = roundVec2 (child.position);
			v.x = v.x + xShift;
			v.y = v.y + yShift;
			if (v.x > 9 || v.y > 9 || v.x < 0 || v.y < 0)
				return false;
			if (!InsideBorder (v)) {
				return false;
			}

			//if (gameGridCol [(int)v.x].row [(int)v.y] != null && gameGridCol [(int)v.x].row [(int)v.y] != obj) {
			if(Grid.grid[(int)(v.x), (int)(v.y)] != null && !Grid.grid[(int)(v.x), (int)(v.y)].IsChildOf(obj)){
				Debug.Log ("Collision at " + v.x + "," + v.y + ".");
				return false;
			}

		}

		return true;
	}

	public void UpdateGrid(int blockX, int blockY)
	{
		StartCoroutine (CheckFullGrid (blockX, blockY));
	}


	public void ClearBoard()
	{
		for (int y = 0; y < 10; ++y) {
			for (int x = 0; x < 10; ++x) {

				if (gameGridCol [x].row [y] != null) {

					Destroy (gameGridCol [x].row [y].gameObject);
					gameGridCol [x].row [y] = null;
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
