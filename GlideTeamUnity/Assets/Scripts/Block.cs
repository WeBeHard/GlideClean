/*  
 * Detect if object was clicked
 * Match object transform to mouse transform
 */
using UnityEngine;
using UnityEngine.UI;

public class Block : GridManager
{
    //Vector3 distance;
    Transform objectPosition;
    Vector2 originalPosition;
    //bool moving = false;
    //public Transform holder;
    //Holder holder;
    bool stored = false;
	public static bool isSet = false;

	public Button upButton;
	public Button downButton;
	public Button leftButton;
	public Button rightButton;

    void Start()
    {
        // Keep track of original position just in case block is placed
        // in an invalid area
        originalPosition = transform.position;

        //holder = GameObject.FindObjectOfType<Holder>();
    }
    
    void OnMouseDown()
    {
        // Distance from camera to object
        //distance = Camera.main.WorldToScreenPoint(transform.position);
        //moving = true;
        //stored = false;
        Debug.Log(name);
    }

    void OnMouseDrag()
    {
        // Debug.Log("dragging");

        // Get position of mouse while moving it
        Vector2 mousePosition = Input.mousePosition;
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objectPosition.x = (int)(Mathf.Round(objectPosition.x));
        objectPosition.y = (int)(Mathf.Round(objectPosition.y));
        transform.position = objectPosition;
        //moving = true;
        //stored = false;
    }
    
    void OnMouseUp()
    {
        //foreach (Transform childBlock in transform)
        //{
        //    if (childBlock.position.x < 0 || childBlock.position.x > 10 || childBlock.position.y < 0 || childBlock.position.y > 10)
        //    {
        //        transform.position = originalPosition;
        //        Debug.Log("returned");
        //    }
        //}
        if (IsInGrid())
        {
            SetBlock();
        }
        else
        {
            transform.position = originalPosition;
            Debug.Log("returned");
        }
		isSet = false;
    }
    
    void Update()
    {
        
    }

    public Vector2 RoundVector(Vector2 vector2d)
    {
        return new Vector2(Mathf.Round(vector2d.x), Mathf.Round(vector2d.y));
    }

    bool IsInGrid()
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

    // Check if position is within border
    bool IsInBorder(Vector2 position)
    {
        return ((int)position.x >= 0 && (int) position.x <=10 && (int) position.y >= 0 && (int) position.y <= 10);
    }

    // Check if position is already occupied by another shape
    bool IsOccupied(int x, int y)
    {
        // Current space is occupied only by the actual shape, not by another shape
        return (Grid.grid[x, y] != null && Grid.grid[x, y].parent != transform);
    }


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



    public void SetBlock()
    {
		upButton = GameObject.FindGameObjectWithTag ("Up").GetComponent<Button>();
		downButton = GameObject.FindGameObjectWithTag ("Down").GetComponent<Button>();
		leftButton = GameObject.FindGameObjectWithTag ("Left").GetComponent<Button>();
		rightButton = GameObject.FindGameObjectWithTag ("Right").GetComponent<Button>();

		Vector2 position; 
		foreach (Transform childBlock in transform) {
			position = RoundVector (childBlock.position);
			Grid.grid [(int)position.x, (int)position.y] = childBlock;
        

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

			}

		}

		isSet = true;
    }

    // Invoked when collision happens
    void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("collision");
        // If collision with Holder tag
        if(collision.collider.name == "Holder")
        {
            // If holder is full
            if (Holder.full == false)
            {
                stored = true;
            }
            else
            {
                stored = false;
            }
            Debug.Log("Collided");
        }
    }

    

    void StoreBlock()
    {
        transform.position = FindObjectOfType<Holder>().transform.position;
    }
}