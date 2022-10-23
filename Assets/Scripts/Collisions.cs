using UnityEngine;
public class Collisions : MonoBehaviour
{
    GameObject obj;
    Vector3 sizeOfBox = new Vector3(.25f, .25f, .01f);
    float range = .5f;
    LayerMask layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask(Tags.layerName);
        if (!Physics.queriesHitTriggers)
            Physics.queriesHitTriggers = true;
    }

    private void FixedUpdate()
    {
        if (Physics.BoxCast(transform.position,sizeOfBox,Vector3.forward, out RaycastHit hit,Quaternion.identity,range,layerMask))
        {
            obj = hit.collider.gameObject;
            if (obj != this.gameObject)
            {
                if (obj.CompareTag(Tags.unCollactableCubeTag))
                {
                    CollectionManager.Instance.DropCube();
                    DropMe();
                }
                else if (obj.CompareTag(Tags.collactableCubeTag))
                {
                    CollectionManager.Instance.CollectCube(obj);
                }
                else if (obj.CompareTag(Tags.gameEndTag))
                {
                    CollectionManager.Instance.FinishDropCube();
                    DropMe();
                }
            }
        }
    }
    void DropMe()
    {
        this.gameObject.transform.SetParent(null);
        Destroy(this.gameObject, 2.0f);//Destroy cube
        Destroy(this);//Destroy script

    }
}
