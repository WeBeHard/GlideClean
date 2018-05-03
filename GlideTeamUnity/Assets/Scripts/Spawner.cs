using UnityEngine;

public class Spawner : MonoBehaviour {

    public Block[] blocks;

    public int index;

    public Block activeBlock;

    public void SpawnBlock()
    {
        int shapeIndex = Random.Range(0, blocks.Length);
        index = shapeIndex;
        activeBlock = Instantiate(blocks[shapeIndex], transform.position, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
        SpawnBlock();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool IsEmpty()
    {
        if(activeBlock.finished == true)
        {
            return activeBlock.finished;
        }
        return false;
    }
}
