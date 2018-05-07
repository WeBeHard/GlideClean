/*  
 * Detect if object was clicked
 * Match object transform to mouse transform
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : GridManager
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

	public void Start()
	{
		// Keep track of original position just in case block is placed
		// in an invalid area
		originalPosition = transform.position;
		stored = false;
		finished = false;
		hideArrows();
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
			hideArrows ();
		}
		else
		{
			transform.position = originalPosition;
			hideArrows ();
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
			/*
			if (!IsOnBorder (position))
				return false;*/
		}

		return true;
	}

	// Try instantiating and destroying
	public void moveBlockUp (Block b){
		if (b.IsInGrid ()) {
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartInteractionSound();
			while (IsMoveValid (b.transform, 0, 1)) {
				foreach (Transform child in b.transform) {
					Vector2 currentPos = RoundVector (child.position);
					Grid.grid [(int)currentPos.x, (int)currentPos.y] = null;
					Grid.grid [(int)currentPos.x, (int)currentPos.y + 1] = child;
				}
				Vector2 objectPosition = b.transform.position;
				int blockMove = Mathf.RoundToInt (b.transform.position.y) + 1;
				objectPosition.y = (int)(Mathf.Round (blockMove));
				b.transform.position = objectPosition;
				Vector2 newBlockPos = RoundVector (transform.position);
				Grid.grid [(int)newBlockPos.x, (int)newBlockPos.y] = this.transform;

			}
			hideArrows ();
			foreach (Transform child in b.transform) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y] = child;
				Debug.Log ("Child at: " + (int)currentPos.x + "," + (int)currentPos.y);
				child.gameObject.AddComponent<PlacedBlock> ();
				child.gameObject.GetComponent<PlacedBlock> ().setX ((int)currentPos.x);
				child.gameObject.GetComponent<PlacedBlock> ().setY ((int)currentPos.y);
			}
			finished = true;
			Destroy (this.GetComponent<Block> ());
			ClearCheck (b.transform);
		}
	}
		
	public void moveBlockDown (Block b){
		if (b.IsInGrid ()) {
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartInteractionSound();
			while (IsMoveValid (b.transform, 0, -1)) {
				foreach (Transform child in b.transform) {
					Vector2 currentPos = RoundVector (child.position);
					Grid.grid [(int)currentPos.x, (int)currentPos.y] = null;
					Grid.grid [(int)currentPos.x, (int)currentPos.y - 1] = child;
				}
				Vector2 objectPosition = b.transform.position;
				int blockMove = Mathf.RoundToInt (b.transform.position.y) - 1;
				objectPosition.y = (int)(Mathf.Round (blockMove));
				b.transform.position = objectPosition;
				Vector2 newBlockPos = RoundVector (transform.position);
				Grid.grid [(int)newBlockPos.x, (int)newBlockPos.y] = this.transform;
			}
			hideArrows ();
			Debug.Log ("Child count" + b.transform.childCount);
			foreach (Transform child in b.transform) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y] = child;
				Debug.Log ("Child at: " + (int)currentPos.x + "," + (int)currentPos.y);
				child.gameObject.AddComponent<PlacedBlock> ();
				child.gameObject.GetComponent<PlacedBlock> ().setX ((int)currentPos.x);
				child.gameObject.GetComponent<PlacedBlock> ().setY ((int)currentPos.y);	
			}
			finished = true;
			Destroy (this.GetComponent<Block> ());
			ClearCheck (b.transform);
		}
	}

	public void moveBlockLeft (Block b){
		if (b.IsInGrid ()) {
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartInteractionSound();
			while (IsMoveValid (b.transform, -1, 0)) {
				foreach (Transform child in b.transform) {
					Vector2 currentPos = RoundVector (child.position);
					Grid.grid [(int)currentPos.x, (int)currentPos.y] = null;
					Grid.grid [(int)currentPos.x - 1, (int)currentPos.y] = child;
				}
				Vector2 objectPosition = b.transform.position;
				int blockMove = Mathf.RoundToInt (b.transform.position.x) - 1;
				objectPosition.x = (int)(Mathf.Round (blockMove));
				b.transform.position = objectPosition;
				Vector2 newBlockPos = RoundVector (transform.position);
				Grid.grid [(int)newBlockPos.x, (int)newBlockPos.y] = this.transform;
			}
			foreach (Transform child in b.transform) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y] = child;
				child.gameObject.AddComponent<PlacedBlock> ();
				child.gameObject.GetComponent<PlacedBlock> ().setX ((int)currentPos.x);
				child.gameObject.GetComponent<PlacedBlock> ().setY ((int)currentPos.y);
			}
			hideArrows ();
			finished = true;
			Destroy (this.GetComponent<Block> ());
			ClearCheck (b.transform);
		}
	}
		
	public void moveBlockRight (Block b){
		if (b.IsInGrid ()) {
			GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartInteractionSound();
			while (IsMoveValid (b.transform, 1, 0)) {
				foreach (Transform child in b.transform) {
					Vector2 currentPos = RoundVector (child.position);
					Grid.grid [(int)currentPos.x, (int)currentPos.y] = null;
					Grid.grid [(int)currentPos.x + 1, (int)currentPos.y] = child;
				}
				Vector2 objectPosition = b.transform.position;
				int blockMove = Mathf.RoundToInt (b.transform.position.x) + 1;
				objectPosition.x = (int)(Mathf.Round (blockMove));
				b.transform.position = objectPosition;
				Vector2 newBlockPos = RoundVector (transform.position);
				Grid.grid [(int)newBlockPos.x, (int)newBlockPos.y] = this.transform;
			}
			foreach (Transform child in b.transform) {
				Vector2 currentPos = RoundVector (child.position);
				Grid.grid [(int)currentPos.x, (int)currentPos.y] = child;
				Debug.Log ("Sprite at " + (int)currentPos.x + "," + (int)currentPos.y + "became PlacedBlock.");
				child.gameObject.AddComponent<PlacedBlock> ();
				child.gameObject.GetComponent<PlacedBlock> ().setX ((int)currentPos.x);
				child.gameObject.GetComponent<PlacedBlock> ().setY ((int)currentPos.y);
			}
            hideArrows();
            finished = true;
            Destroy(this.GetComponent<Block>());
            ClearCheck(b.transform);
        }
	}

	void ClearCheck(Transform b){
		/*Vector2 newBlockPos = RoundVector(b.transform.position);
		UpdateGrid ((int)newBlockPos.x, (int)newBlockPos.y);
		foreach (Transform child in b) {
			Vector2 currentPos = RoundVector (child.position);
			UpdateGrid ((int)currentPos.x, (int)currentPos.y);
		}
		Try #2
		Vector2 currentPos = RoundVector (b.position);
		UpdateGrid ((int)currentPos.x, (int)currentPos.y);
		*/
	/*	foreach (Transform child in b.transform) {
			child.gameObject.AddComponent<PlacedBlock>();
		}*/
		UpdateGrid (b);
	}

	// Check if position is within border
	bool IsInBorder(Vector2 position)
	{
		return ((int)position.x >= 0 && (int) position.x <=9 && (int) position.y >= 0 && (int) position.y <= 9);
	}
	/*
	bool IsOnBorder(Vector2 position)
	{
		return((int)position.x == 0 || (int)position.x == 9 || (int)position.y == 0 || (int)position.y == 9);
	}*/
	// Check if position is already occupied by another shape
	bool IsOccupied(int x, int y)
	{
		// Current space is occupied only by the actual shape, not by another shape
		return (Grid.grid[x, y] != null && Grid.grid[x, y].parent != transform);
	}

	public void SetBlock()
	{	
		upButton = GameObject.Find ("Up").GetComponent<Button>();
		downButton = GameObject.Find ("Down").GetComponent<Button>();
		leftButton = GameObject.Find ("Left").GetComponent<Button>();
		rightButton = GameObject.Find ("Right").GetComponent<Button>();

		upButton.onClick.AddListener(() => moveBlockUp(this));
		downButton.onClick.AddListener(() => moveBlockDown(this));
		rightButton.onClick.AddListener(() => moveBlockRight(this));
		leftButton.onClick.AddListener(() => moveBlockLeft(this));

		GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartDropSound();
		/*Vector2 newPos = transform.position;
		newPos = roundPosition (newPos.x, newPos.y);
		transform.position = newPos;*/
		foreach (Transform childBlock in transform)
		{
			Vector2 position = RoundVector(childBlock.position);
			//Grid.grid[(int)position.x, (int)position.y] = childBlock;

			if ((int)position.x == 0 && (int)position.y == 0) {

				showArrows("Up", "Right");/*
				Vector2 upButtonPos = position;
				upButtonPos.y += 3;
				upButton.transform.position = upButtonPos;

				Vector2 rightButtonPos = position;
				rightButtonPos.x += 3;
				rightButton.transform.position = rightButtonPos;*/


			} else if ((int)position.x == 0 && (int)position.y == 9) {

				showArrows("Down", "Right");/*
				Vector2 downButtonPos = position;
				downButtonPos.y -= 2;
				downButtonPos.x += 1;
				downButton.transform.position = downButtonPos;

				Vector2 rightButtonPos = position;
				rightButtonPos.x += 3;
				rightButton.transform.position = rightButtonPos;*/


			} else if ((int)position.x == 9 && (int)position.y == 0) {

				showArrows("Up", "Left");/*
				Vector2 leftButtonPos = position;
				leftButtonPos.x -= 3;
				leftButton.transform.position = leftButtonPos;

				Vector2 upButtonPos = position;
				upButtonPos.y += 3;
				upButtonPos.x -= 1;
				upButton.transform.position = upButtonPos;
*/

			} else if ((int)position.x == 9 && (int)position.y == 9) {

				showArrows("Down", "Left");/*
				Vector2 downButtonPos = position;
				downButtonPos.y -= 3;
				downButtonPos.x -= 1;
				downButton.transform.position = downButtonPos;

				Vector2 leftButtonPos = position;
				leftButtonPos.x -= 3;
				leftButton.transform.position = leftButtonPos;
*/
			}
			else if ((int)position.x == 0) {
			
				showArrows("Right");/*
				Vector2 rightButtonPos = position;
				rightButtonPos.x += 3;
				rightButton.transform.position = rightButtonPos;*/


			}
			else if ((int)position.x == 9) {

				showArrows("Left");/*
				Vector2 leftButtonPos = position;
				leftButtonPos.x -= 3;
				leftButton.transform.position = leftButtonPos;*/


			}
			else if ((int)position.y == 0) {

				showArrows("Up");/*
				Vector2 upButtonPos = position;
				upButtonPos.y += 3;
				upButtonPos.x -= 1;
				upButton.transform.position = upButtonPos;*/


			}
			else if ((int)position.y == 9) {

				showArrows("Down");/*
				Vector2 downButtonPos = position;
				downButtonPos.y -= 3;
				downButtonPos.x -= 1;
				downButton.transform.position = downButtonPos;*/


			}
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

	void hideArrows(){
		upButton = GameObject.Find ("Up").GetComponent<Button> ();
		downButton = GameObject.Find ("Down").GetComponent<Button> ();
		leftButton = GameObject.Find ("Left").GetComponent<Button> ();
		rightButton = GameObject.Find ("Right").GetComponent<Button> ();

		upButton.enabled = false;
		upButton.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0);
		downButton.enabled = false;
		downButton.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0);
		leftButton.enabled = false;
		leftButton.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0);
		rightButton.enabled = false;
		rightButton.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0);
	}

	void showArrows(string arrow1, string arrow2){

		Button arrowButton1 = GameObject.Find (arrow1).GetComponent<Button> ();
		Button arrowButton2 = GameObject.Find (arrow2).GetComponent<Button> ();

		arrowButton1.enabled = true;
		arrowButton1.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
		arrowButton2.enabled = true;
		arrowButton2.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
	}

	void showArrows(string arrow){

		Button arrowButton = GameObject.Find (arrow).GetComponent<Button> ();

		arrowButton.enabled = true;
		arrowButton.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
	}

	Vector2 roundPosition(float x, float y){
		float distanceRight = x - 9;
		float distanceLeft = x;
		float distanceTop = y - 9;
		float distanceBot = y;
		float finalX = 0;
		float finalY = 0;
		float finalMin = Mathf.Min (distanceRight, distanceLeft, distanceTop, distanceBot);
		if (distanceRight == finalMin)
			finalX = 9;
		else if(distanceLeft == finalMin)
			finalX = 0;
		else if (distanceBot == finalMin)
			finalY = 0;
		else if (distanceTop == finalMin)
			finalY = 9;
		Vector2 newPos;
		newPos.x = finalX;
		newPos.y = finalY;
		return newPos;
	}
}