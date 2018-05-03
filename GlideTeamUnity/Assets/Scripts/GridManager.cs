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

	public void PlaceShape()
	{
		int y = 0;
		int x = 0;
        StartCoroutine (CheckFullGrid (y, x));
    }


    IEnumerator CheckFullGrid(int k, int j)
    {
        for (int y = k; y < 10; y++)
        {
            if (IsRowFull(y))
            {
                fullRows.Add(y);
            }
        }

        for (int x = j; x < 10; x++)
        {
            if (IsColumnFull(x))
            {
                fullColumns.Add(x);
            }
        }

        for (int n = 0; n < fullRows.Count; ++n)
        {
            DeleteRow(fullRows[n]);
            AudioClass.extend.StartLineClearingSound(LineClearing); //clear sound
            yield return new WaitForSeconds(0.8f);
        }

        for (int m = 0; m < fullColumns.Count; ++m)
        {
            DeleteColumn(fullColumns[m]);
            AudioClass.extend.StartLineClearingSound(LineClearing); //clear sound
            yield return new WaitForSeconds(0.8f);
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
            if (gameGridCol[x].row[y] == null)
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
            Destroy(gameGridCol[x].row[y].gameObject);
            gameGridCol[x].row[y] = null;
        }
    }

    public bool IsColumnFull(int x)
    {
        for (int y = 0; y < 10; ++y)
        {
            if (gameGridCol[x].row[y] == null)
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
            Destroy(gameGridCol[x].row[y].gameObject);
            gameGridCol[x].row[y] = null;
        }
    }


	public static Vector2 roundVec2(Vector2 v)
    {
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y)); 
	}

	public bool IsValidGridPosition(Transform obj)
	{
		foreach (Transform child in obj) {

			if (child.gameObject.tag.Equals ("Block")) {

				Vector2 v = roundVec2 (child.position);

				if (!InsideBorder (v)) {
					return false;
				}

				if (gameGridCol [(int)v.x].row [(int)v.y] != null && gameGridCol [(int)v.x].row [(int)v.y] != obj) {
					
					return false;
				}
			}
		}
		return true;
	}


    #region potential block slide movement (unused)
    /*
        public enum DraggedDirection
        {
            Up,
            Down,
            Right,
            Left,
            Point
        }

        //inside class
        Vector2 firstPressPos;
        Vector2 secondPressPos;
        Vector2 currentSwipe;
        DraggedDirection direction;
        public void Swipe()
        {

            if(Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);

                if(t.phase == TouchPhase.Began)
                {
                    //save began touch 2d point
                    firstPressPos = new Vector2(t.position.x,t.position.y);
                }
                if (t.phase == TouchPhase.Ended) {
                    //save ended touch 2d point
                    secondPressPos = new Vector2 (t.position.x, t.position.y);

                    //create vector from the two points
                    currentSwipe = new Vector3 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                    //normalize the 2d vector
                    currentSwipe.Normalize ();
                }

                    //swipe upwards
                    if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        Debug.Log("up swipe");
                        direction = DraggedDirection.Up;
                    }
                    //swipe down
                    if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        Debug.Log("down swipe");
                        direction = DraggedDirection.Down;
                    }
                    //swipe left
                    if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        Debug.Log("left swipe");
                        direction = DraggedDirection.Left;
                    }
                    //swipe right
                    if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        Debug.Log("right swipe");
                        direction = DraggedDirection.Right;
                    }

            }
            //return direction;
        }
    */
    #endregion potential block slide movement (unused)


    public void UpdateGrid(Transform obj)
	{
		if (IsValidGridPosition (obj)) {

            // update grid ui ???
            // if valid position, spawn movement arrows (call class)

		}
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
