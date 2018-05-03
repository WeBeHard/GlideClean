/*  
 * Detect if object was clicked
 * Match object transform to mouse transform
 */
using UnityEngine;

public class Block : MonoBehaviour
{
    Transform objectPosition;
    Vector2 originalPosition;
    Vector2 tempPosition;
    public bool stored;
    public bool finished;

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
            finished = true;
        }
        else if(stored == true)
        {
            StoreBlock();
            finished = true;
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

    public void SetBlock()
    {
        foreach (Transform childBlock in transform)
        {
            Vector2 position = RoundVector(childBlock.position);
            Grid.grid[(int)position.x, (int)position.y] = childBlock;
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
        finished = true;
    }
}