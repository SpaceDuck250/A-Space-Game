using UnityEngine;

public class ShipEngineControlScript : MonoBehaviour
{
    [Tooltip("Rotation")]
    public Transform rotatePoint;
    public Transform enginePoint;
    public float rotateSpeed;


    [Tooltip("Move")]
    public float engineSpeed;
    //public Vector3 shipMoveDirection => -Vector3.Normalize(enginePoint.position - transform.position);
    public Vector3 shipMoveDirection => rotatePoint.up;


    public Rigidbody2D rb;

    private Vector3 refVelocity;

    public float smoothValue;

    public bool engineOn = false;

    private void Update()
    {
        MoveShip();
    }

    public void RotateEngine(float direction)
    {
        if (direction == 0)
        {
            return;
        }

        Vector3 rotateVector = new Vector3(0, 0, direction * Time.deltaTime * rotateSpeed);
        rotatePoint.transform.Rotate(rotateVector);
    }

    public void ActivateEngine(bool value)
    {
        engineOn = value;
   
    }

    public void MoveShip()
    {
        if (!engineOn)
        {
            return;
        }

        //print("moving");
        Vector3 targetVelocity = engineSpeed * shipMoveDirection;
        //Vector3 targetVelocity = Vector3.right * engineSpeed;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue);
    }
}
