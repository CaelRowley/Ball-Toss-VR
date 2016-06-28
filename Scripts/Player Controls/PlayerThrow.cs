using UnityEngine;
using System.Collections;

public class PlayerThrow : MonoBehaviour
{
    public Rigidbody projectile;
    public float throwDistanceMax;
    public float throwMagnitude;

    private bool canThrow = true;
    private Vector3 targetPosition;

    public GameObject playerStatusGameObject;
    private PlayerStatus playerStatus;

    public float throwCooldown;
    private int timeAfterThrow;

    private void Start()
    {
        playerStatus = (PlayerStatus)playerStatusGameObject.GetComponent("PlayerStatus");
        timeAfterThrow = (int)throwCooldown;
        StartCoroutine("ThrowTimer");
    }

    private void Update()
    {
        canThrow = playerStatus.HasAmmo() && (timeAfterThrow >= throwCooldown);

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
                playerStatus.SetAmmoCount(playerStatus.GetAmmoCount() - 1);
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
    public void AlternateThrow2(Vector3 targetPosition)
    {
        float ang = 70.0f;
        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile.velocity = BalsticVelocity(targetPosition, ang);
        //Destroy(instantiatedProjectile, 10);
    }

    private Vector3 BalsticVelocity(Vector3 targetPosition, float angle)
    {
        Vector3 targetDirection = targetPosition - transform.position;
        float directionHeight = targetDirection.y;
        targetDirection.y = 0;
        float distanceToTarget = targetDirection.magnitude;

        float degreesToRadians = angle * Mathf.Deg2Rad;
        targetDirection.y = distanceToTarget * Mathf.Tan(degreesToRadians);

        //Debug.Log("Target direction " + targetDirection);        
        //float velocity = Mathf.Sqrt(distanceToTarget * Physics.gravity.magnitude * throwMagnitude);        

        float velocity = Mathf.Sqrt(distanceToTarget * Physics.gravity.magnitude / Mathf.Sin(2 * degreesToRadians));
        //Debug.Log("Vel: " + velocity);

        return velocity * targetDirection.normalized;
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