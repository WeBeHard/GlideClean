/*  
 * Detect if object was clicked
 * Match object transform to mouse transform
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
	Transform objectPosition;
	Vector2 originalPosition;
	Vector2 tempPosition;

	public bool stored;
	public bool finished;

	public Button upButton;
	public Button downButton;
	public Button leftButton;
	public Button rightButton;

    Holder holder;

	void Start()
	{
		// Keep track of original position just in case block is placed
		// in an invalid area
		originalPosition = transform.position;
		stored = false;
		finished = false;
	}

	void OnMouseDrag()
	{
		// Get position of mouse while moving it
		Vector2 mousePosition = Input.mousePosition;
		Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		objectPosition.x = (int)(Mathf.Round(objectPosition.x));
		objectPosition.y = (int)(Mathf.Round(objectPosition.y));
		transform.position = objectPosition;
	}

	void OnMouseUp()
	{
		if (IsInGrid() && stored == false)
		{
			SetBlock();
            GameOver();
        }
		else if(stored == true)
		{
			StoreBlock();
		}
		else
		{
			transform.position = originalPosition;
			Debug.Log("returned");
		}
	}

	void Update()
	{

	}

	public Vector2 RoundVector(Vector2 vector2d)
	{
		return new Vector2(Mathf.Round(vector2d.x), Mathf.Round(vector2d.y));
	}

	public bool IsInGrid()
	{
		// Go through each child block to see if it is in grid and not taking up current space
		foreach(Transform childBlock in transform)
		{
			Vector2 position = RoundVector(childBlock.position);

			if (!IsInBorder(position))
			{
				return false;
			}

			if(IsOccupied((int)position.x, (int)position.y))
			{
				return false;
			}
		}

		return true;
	}
	/*
	public void moveBlockUp (Transform obj){

		while (IsValidGridPosition (obj)) {
			foreach (Transform child in obj) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x - 1, (int)currentPos.y] = child;
			}
		}
	}
		
	public void moveBlockDown (Transform obj){

		while (IsValidGridPosition (obj)) {
			foreach (Transform child in obj) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x + 1, (int)currentPos.y] = child;
			}
		}
	}
		
	public void moveBlockLeft (Transform obj){

		while (IsValidGridPosition (obj)) {
			foreach (Transform child in obj) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y - 1] = child;
			}
		}
	}
		
	public void moveBlockRight (Transform obj){

		while (IsValidGridPosition (obj)) {
			foreach (Transform child in obj) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y + 3] = child;
			}
		}
	}
	*/

	// Check if position is within border
	bool IsInBorder(Vector2 position)
	{
        //foreach(Transform childBlock in transform)
        //{
        //    if((int)position.x >= 0 && (int)position.x <= 9 && (int)position.y >= 0 && (int)position.y <= 9)
        //    {

        //    }
        //}
		return ((int)position.x >= 0 && (int) position.x <=9 && (int) position.y >= 0 && (int) position.y <= 9);
	}

	// Check if position is already occupied by another shape
	bool IsOccupied(int x, int y)
	{
		// Current space is occupied only by the actual shape, not by another shape
		return (Grid.grid[x, y] != null && Grid.grid[x, y].parent != transform);
	}

	public void SetBlock()
	{
		/*
		upButton = GameObject.FindGameObjectWithTag ("Up").GetComponent<Button>();
		downButton = GameObject.FindGameObjectWithTag ("Down").GetComponent<Button>();
		leftButton = GameObject.FindGameObjectWithTag ("Left").GetComponent<Button>();
		rightButton = GameObject.FindGameObjectWithTag ("Right").GetComponent<Button>();
        */
		GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartDropSound();
		foreach (Transform childBlock in transform)
		{
			Vector2 position = RoundVector(childBlock.position);
			Grid.grid[(int)position.x, (int)position.y] = childBlock;
			/*
			if ((int)position.x == 0 && (int)position.y == 0) {
				Vector2 rightButtonPos = position;
				rightButtonPos.y += 1;
				rightButton.transform.position = rightButtonPos;

				Vector2 downButtonPos = position;
				downButtonPos.x += 1;
				downButton.transform.position = downButtonPos;


			} else if ((int)position.x == 0 && (int)position.y == 9) {


				Vector2 upButtonPos = position;
				upButtonPos.x -= 1;
				upButton.transform.position = upButtonPos;

				Vector2 rightButtonPos = position;
				rightButtonPos.y += 1;
				rightButton.transform.position = rightButtonPos;


			} else if ((int)position.x == 9 && (int)position.y == 0) {

				Vector2 rightButtonPos = position;
				rightButtonPos.y += 1;
				rightButton.transform.position = rightButtonPos;

				Vector2 downButtonPos = position;
				downButtonPos.x += 1;
				downButton.transform.position = downButtonPos;


			} else if ((int)position.x == 9 && (int)position.y == 9) {

				Vector2 upButtonPos = position;
				upButtonPos.y -= 1;
				upButton.transform.position = upButtonPos;

				Vector2 leftButtonPos = position;
				leftButtonPos.x -= 1;
				leftButton.transform.position = leftButtonPos;

			}*/
		}
		finished = true;
        
    }

	// Invoked when collision happens
	void OnCollisionStay2D(Collision2D collision)
	{
		// Debug.Log("collision");
		// If collision with Holder tag
		if(collision.collider.name == "Holder")
		{
			Debug.Log(Holder.full);
			// If holder is empty
			if (Holder.full == false)
			{
				stored = true;
				Holder.full = true;
				tempPosition = originalPosition;
				originalPosition = FindObjectOfType<Holder>().transform.position;
			}
			//Debug.Log("Collided");
			//Debug.Log(stored);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.collider.name == "Holder")
		{
			Debug.Log("Exited");
			// Holder is now empty
			Holder.full = false;
			// Block is not stored
			stored = false;
			Debug.Log("exit stored: " + stored);
		}
	}

	void StoreBlock()
	{
		transform.position = FindObjectOfType<Holder>().transform.position;
	}

    bool GameOver()
    {
        if (Lose() == true)
        {
            Debug.Log("Game Over!");
            return true;
        }
        return false;
    }

    bool Lose()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        List<Block> activeBlocks = new List<Block>();

        foreach (Block block in blocks)
        {
            if (block.finished == false)
            {
                activeBlocks.Add(block);
            }
        }
        Debug.Log(activeBlocks.Count);
        if(activeBlocks.Count == 0)
        {
            return false;
        }
        foreach (Block block in activeBlocks)
        {
            if (CanMove(block) == true)
            {
                return false;
            }
        }
        return true;
    }

    bool CanMove(Block block)
    {
        // Check if block can be placed in grid
        Block checkBlock = Instantiate(block);
        checkBlock.gameObject.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Grid.grid[i, j] == null)
                {
                    Vector2 vect = new Vector2(i, j);
                    checkBlock.transform.position = vect;
                    //foreach(Transform childBlock in checkBlock.transform)
                    //{
                    //    //if(childBlock.transform.position.x > 10 || chil)
                    //}
                    if (checkBlock.IsInGrid() == true)
                    {
                        Destroy(checkBlock.gameObject);
                        return true;
                    }
                    //if(checkBlock.IsInGrid() == false)
                    //{

                    //}
                }
            }
        }
        return false;
    }
}