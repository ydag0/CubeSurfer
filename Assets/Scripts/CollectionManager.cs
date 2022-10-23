using UnityEngine;
public class CollectionManager : Singleton<CollectionManager>
{
    Transform cubeTransformParent;
    Transform characterTransform;
    Transform trailTransform;

    float trailPosY;
    int currentCubes=1;
    
    private void Start()
    {
        
        cubeTransformParent = GameObject.FindGameObjectWithTag(Tags.firstCubeTag).transform;
        characterTransform= GameObject.FindGameObjectWithTag(Tags.characterTag).transform;
        trailTransform = characterTransform.GetComponentInChildren<TrailRenderer>().transform;
        trailPosY = trailTransform.position.y;
        currentCubes = cubeTransformParent.GetComponentsInChildren<Transform>().Length - 1;//-1 for itself
        //characterStartPosY = characterTransform.position.y - currentCubes;
    }

    public void CollectCube(GameObject objectToCollect)
    {
        objectToCollect.tag = Tags.untagged;

        characterTransform.position += Vector3.up;

        objectToCollect.transform.SetParent(cubeTransformParent);
        objectToCollect.transform.localPosition = Vector3.down * currentCubes;
        objectToCollect.GetComponent<Collider>().isTrigger = false;
        objectToCollect.AddComponent<Collisions>();
        currentCubes++;
        
    }
    public void DropCube()
    {
        currentCubes--;
        if (currentCubes <= 0)
        {
            Debug.LogError("Game Over You Lose");
        }
    }
    public void FinishDropCube()
    {
        currentCubes--;
        if (currentCubes <= 0)
        {
            Debug.LogError("Game Over You Win");
        }
    }


    private void Update()
    {
        trailTransform.position = new Vector3(trailTransform.position.x, trailPosY, trailTransform.position.z);
    }

}
