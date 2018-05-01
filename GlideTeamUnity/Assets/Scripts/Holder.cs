/* 
 * Drag block to Hold
 * Check if there is another block
 * If empty, put block in hold
 */
using UnityEngine;

public class Holder : MonoBehaviour {

    public Block holdBlock = null;

    public static bool full = false;

    public static Transform holder;   

    //void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Block")
    //    {

    //    }
    //}

    //public void hold(Block block)
    //{
    //    block.transform.position = transform.position;
    //    holdBlock = block;
    //}

    //public Block release()
    //{
    //    if (holdBlock != null)
    //    {
    //        Block block = holdBlock;
    //        holdBlock = null;
    //        return block;
    //    }

    //    return null;
    //}

    //void Update()
    //{
    //    // If left mouse button clicked
    //    if (Input.GetMouseButton(0))
    //    {
    //        // Convert clicked position to world space
    //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

    //        // Raycast: "draws" a line between two points in the game world
    //        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
    //        if(hit.collider.gameObject.tag == "Block")
    //        {
    //            Debug.Log("You clicked on the block");
    //        }
    //    }
    //}
}