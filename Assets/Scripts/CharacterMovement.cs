using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : Singleton<CharacterMovement>
{
    public bool shouldMove;
    public Rigidbody myRb { get; private set; }
    float boundaryX = 1.5f;
    void Start()
    {
        myRb=GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down * 9.81f;
    }
    private void FixedUpdate()
    {   
        if (shouldMove)
        {
            Move();
        }

    }
    private void Update()
    {
        if (transform.position.x > boundaryX || transform.position.x < -boundaryX)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundaryX, boundaryX), transform.position.y, transform.position.z);
        }
    }
    void Move()
    {
        Vector3 vel= GameSettings.Instance.characterSpeed * Time.fixedDeltaTime *
            (Vector3.forward + (Vector3.right * InputHandler.Instance.inputX * GameSettings.Instance.characterSideSpeed));
        myRb.velocity= new Vector3(vel.x, myRb.velocity.y, vel.z);
        //if (transform.position.x > GameSettings.Instance.worldBoundaryX || transform.position.x < -GameSettings.Instance.worldBoundaryX)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundaryX, boundaryX), transform.position.y, transform.position.z);
        //}
        //else
        //    myRb.velocity = new Vector3(vel.x, myRb.velocity.y, vel.z);

    }
}
