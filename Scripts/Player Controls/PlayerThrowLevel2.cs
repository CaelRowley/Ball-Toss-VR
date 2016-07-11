using UnityEngine;
using System.Collections;

public class PlayerThrowLevel2 : MonoBehaviour
{
    public Rigidbody projectile;
    public float throwDistanceMax;
    public float throwMagnitude;

    private bool canThrow = true;
    private Vector3 targetPosition;

    public float throwCooldown;
    private int timeAfterThrow;

    private void Start()
    {
        timeAfterThrow = (int)throwCooldown;
        StartCoroutine("ThrowTimer");
    }

    private void Update()
    {
        canThrow = timeAfterThrow >= throwCooldown;

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
                //AlternateThrow2(targetPosition);
                timeAfterThrow = 0;
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

        if(distanceToTarget < 0.4)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.AddForce(targetDirection * 1.9f, ForceMode.Impulse);
            Destroy(instantiatedProjectile, 3f);
            //Debug.Log("lessthen1");
        }
        else
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = velocity * targetDirection.normalized;
            //Destroy(instantiatedProjectile, 3f);
        }

        //Debug.Log("Distance to target: " + distanceToTarget);
    }

    // Adds 1 to currentTime every second
    private IEnumerator ThrowTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeAfterThrow += 1;
        }
    }
}