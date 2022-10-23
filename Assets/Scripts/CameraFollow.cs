using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    Vector3 offset;
    Transform camTransform;
    void Start()
    {
        camTransform = Camera.main.transform;
        if(targetTransform==null)
            targetTransform = GameObject.FindGameObjectWithTag(Tags.characterTag).transform;
        offset = camTransform.position - targetTransform.position;
    }

    void FixedUpdate()
    {
        Debug.DrawLine(camTransform.position, targetTransform.position, Color.red);
        camTransform.position = Vector3.Lerp(camTransform.position, targetTransform.position + offset, 
            Time.deltaTime * GameSettings.Instance.cameraLerpMultiplier);
    }
}
