using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{
    public float inputX { get; private set; }
    void Update()
    {
        if (Input.GetMouseButton(0))
            inputX = Input.GetAxis("Mouse X");
        else
            inputX = 0;
    }
}
