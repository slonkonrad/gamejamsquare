using UnityEngine;

public class CarCam : MonoBehaviour
{
    public SplitScreen SplitScreen;
    public Vector3 DistanceFromCar;
    public float MaxDistanceFromCamera;

    Transform rootNode;
    Transform carCam;
    Transform car;
    Rigidbody carPhysics;

    [Tooltip("If car speed is below this value, then the camera will default to looking forwards.")]
    public float rotationThreshold = 1f;
    
    [Tooltip("How closely the camera follows the car's position. The lower the value, the more the camera will lag behind.")]
    public float cameraStickiness = 10.0f;
    
    [Tooltip("How closely the camera matches the car's velocity vector. The lower the value, the smoother the camera rotations, but too much results in not being able to see where you're going.")]
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        carCam = GetComponentInChildren<Camera>().GetComponent<Transform>();
        rootNode = GetComponent<Transform>();
        car = rootNode.parent.GetComponent<Transform>();
        carPhysics = car.GetComponent<Rigidbody>();
        rootNode.position = car.position + DistanceFromCar;
        Vector3 direction = car.position - rootNode.position;
        rootNode.rotation = Quaternion.LookRotation(direction);
    }

    void Start()
    {
        // Detach the camera so that it can move freely on its own.
        rootNode.parent = null;
    }

    void FixedUpdate()
    {
        Quaternion look;

        // Moves the camera to match the car's position.
        float distance = (rootNode.position - car.position).magnitude;
        if (distance > MaxDistanceFromCamera)
        {
            rootNode.position = Vector3.Lerp(rootNode.position, car.position + DistanceFromCar, cameraStickiness * Time.fixedDeltaTime);
        }


        //if (carPhysics.velocity.magnitude < rotationThreshold)
        //    look = Quaternion.LookRotation(car.forward, rootNode.up);
        //else
        //    look = Quaternion.LookRotation(carPhysics.velocity.normalized, rootNode.up);
        //rootNode.rotation = Quaternion.Slerp(rootNode.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);

        //// If the car isn't moving, default to looking forwards. Prevents camera from freaking out with a zero velocity getting put into a Quaternion.LookRotation
        //if (carPhysics.velocity.magnitude < rotationThreshold)
        //    look = Quaternion.LookRotation(-rootNode.up);
        //else
        //    look = Quaternion.LookRotation(carPhysics.velocity.normalized);

        // Rotate the camera towards the velocity vector.
        //look = Quaternion.Slerp(rootNode.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);                
        //rootNode.rotation = Quaternion.LookRotation(-rootNode.up);
    }
}