using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MissileMoveComp : MonoBehaviour, IMovementComponent
{
    [SerializeField] private MissilePhases phase = MissilePhases.LAUNCH;
    public Vector3 target = Vector3.zero;
    [SerializeField] float acceleleration =10f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float turnRate = 90f;
    [SerializeField] float launchTurnScalar = .05f;
    [SerializeField] int curseingAltitude = 40;
    [SerializeField] float curseingAccelerationScalar = .2f;
    [SerializeField] float terminalRange = 160f;
    Rigidbody missileRigidbody;
    Vector3 flat = new Vector3(1,0,1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missileRigidbody = gameObject.GetComponent<Rigidbody>();
        transform.eulerAngles = new Vector3(-90,0,0);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch (phase)
        {
            case MissilePhases.LAUNCH:
                if(transform.position.y > curseingAltitude ) {
                    phase = MissilePhases.CRUSE;
                }
                
                missileRigidbody.AddForce(acceleleration*transform.forward, ForceMode.Acceleration);
                missileRigidbody.AddTorque(
                    calculateTorque(new Vector3(target.x,curseingAltitude,
                    target.z))*launchTurnScalar);
            break;
            case MissilePhases.CRUSE:
                if((Vector3.Scale(transform.position,flat)-Vector3.Scale(target,flat)).magnitude < terminalRange ) {
                    phase = MissilePhases.TERMINAL;
                }
                
                missileRigidbody.AddForce(acceleleration*curseingAccelerationScalar*transform.forward, ForceMode.Acceleration);
                missileRigidbody.AddTorque(
                    calculateTorque(new Vector3(target.x,curseingAltitude,
                    target.z)));
            break;
            case MissilePhases.TERMINAL:
                
                missileRigidbody.AddForce(acceleleration*transform.forward, ForceMode.Acceleration);
                missileRigidbody.AddTorque(calculateTorque(target));
            break;
            default:
            break;
        }

        if(missileRigidbody.linearVelocity.magnitude > maxSpeed) {
            missileRigidbody.linearVelocity = missileRigidbody.linearVelocity.normalized*maxSpeed;
        }
    }

    Vector3 calculateTorque(Vector3 target) 
    {
        Vector3 directionToTarget = target - transform.position;

        directionToTarget.Normalize();

        // Calculate the desired rotation that aligns the missile with the direction to the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Find the difference in rotation (the "angle" we want to rotate)
        Quaternion deltaRotation = targetRotation * Quaternion.Inverse(transform.rotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        float torqueStrength = 1 - (90-angle)/90;
        torqueStrength = Mathf.Clamp(torqueStrength,0,1);
        return axis.normalized * torqueStrength * turnRate;
    }

    
    // Vector3 calculateTorque(Vector3 target) 
    // {
    //     Vector3 directionToTarget = target - transform.position;

    //     // Calculate the desired rotation that aligns the missile with the direction to the target
    //     Quaternion targetRotation = Quaternion.FromToRotation(transform.forward, directionToTarget);

    //     // Find the difference in rotation (the "angle" we want to rotate)
    //     Vector3 targetRotationEuler = targetRotation.eulerAngles;

    //     float torqueStrength = 1 - ((90-Vector3.Angle(transform.forward,directionToTarget))/90);
    //     torqueStrength = Mathf.Clamp(torqueStrength,0,1);
    //     return -1* targetRotationEuler.normalized * torqueStrength * turnRate;
    // }
}
