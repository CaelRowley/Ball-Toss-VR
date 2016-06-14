using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Rigidbody projectile;
    public float throwDistanceMax;
    public int projectileCount;
    public float throwMagnitude;

    private bool canThrow = true;
    private Vector3 targetPosition;

    private void Update()
    {
        if(projectileCount <= 0)
            canThrow = false;

        RaycastHit objectHit;
        targetPosition = transform.forward * throwDistanceMax;

        if(Physics.Raycast(transform.position, transform.forward, out objectHit, throwDistanceMax))
        {
            targetPosition = objectHit.point;
            Debug.DrawLine(targetPosition, transform.position, Color.red, 1.0f, false);
        }

        if(GvrViewer.Instance.Triggered)
        {
            if(canThrow)
            {
                //Vector3 velocity = CalculateVelocity(targetPosition);
                CalculateVelocity(targetPosition);
            }
            else
            {
                Debug.Log("Out of projectiles.");
            }
        }
    }

    private void CalculateVelocity(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - transform.position; // get target direction
        float directionHeight = targetDirection.y;  // get height difference
        targetDirection.y = 0;  // retain only the horizontal direction
        float distanceToTarget = targetDirection.magnitude;  // get horizontal distance
        targetDirection.y = distanceToTarget;  // set elevation to 45 degrees
        distanceToTarget += directionHeight;  // correct for different heights

        float velocity = Mathf.Sqrt(distanceToTarget * Physics.gravity.magnitude * throwMagnitude);

        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = velocity * targetDirection.normalized;

        //Debug.Log("Distance to target: " + distanceToTarget);
    }
}