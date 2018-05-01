using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public GameObject block;
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Get info from collision, get info of collider, return name
        if (collisionInfo.gameObject.name == "Holder")
        {
            block.transform.position = collisionInfo.gameObject.transform.position;
            Debug.Log("collided");
        }
    }
}