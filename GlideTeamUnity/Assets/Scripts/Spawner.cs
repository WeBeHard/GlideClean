using UnityEngine;

public class Spawner : MonoBehaviour {

    public Block[] blocks;

    public int index;

    public void SpawnShape()
    {
        int shapeIndex = Random.Range(0, blocks.Length);
        index = shapeIndex;
        Instantiate(blocks[shapeIndex], transform.position, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
        SpawnShape();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
