using UnityEngine;
using System;
using System.Collections;

public class SplitScreen : MonoBehaviour {

    /*Reference both the transforms of the two players on screen.
	Necessary to find out their current positions.*/
    public Transform player1;
	public Transform player2;

	//The distance at which the splitscreen will be activated.
	public float splitDistance = 10;

	//The color and width of the splitter which splits the two screens up.
	public Color splitterColor;
	public float splitterWidth;

	//The two cameras, both of which are initalized/referenced in the start function.
	private GameObject camera1;
	private GameObject camera2;

	//The two quads used to draw the second screen, both of which are initalized in the start function.
	private GameObject split;
	private GameObject splitter;

    private Rigidbody player1RigidBody;
    private Rigidbody player2RigidBody;

    private Vector3 minOffset = new Vector3(0, 10f, -10f);
    private Vector3 maxOffset = new Vector3(0, 50f, -10f);

	void Start ()
	{
		//Referencing camera1 and initalizing camera2.
	    camera1 = GetComponentInChildren<Camera>().gameObject;
		camera2 = new GameObject("New Camera");
        camera2.transform.SetParent(player2);

        var cameraChild = new GameObject();
        cameraChild.AddComponent<Camera>();
        cameraChild.AddComponent<AudioListener>();
        cameraChild.transform.SetParent(camera2.transform);

	    //camera2.AddComponent<CarCam>();
	    camera2.transform.parent = null;
        camera2.SetActive(false);

	    camera2.transform.position = camera1.transform.position;
	    camera2.transform.rotation = camera1.transform.rotation;

        //Setting up the culling mask of camera2 to ignore the layer "TransparentFX" as to avoid rendering the split and splitter on both cameras.
        cameraChild.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("TransparentFX"));

        //Setting up the splitter and initalizing the gameobject.
        splitter = GameObject.CreatePrimitive(PrimitiveType.Quad);
        splitter.transform.parent = gameObject.transform;
        splitter.transform.localPosition = Vector3.forward;
        splitter.transform.localScale = new Vector3(3, splitterWidth / 10, 1);
        splitter.transform.localEulerAngles = Vector3.zero;
        splitter.SetActive(false);

        //Setting up the split and initalizing the gameobject.
        split = GameObject.CreatePrimitive(PrimitiveType.Quad);
	    split.GetComponent<MeshCollider>().enabled = false;
        split.transform.parent = splitter.transform;
        split.transform.localPosition = new Vector3(0, -(1 / (splitterWidth / 10)), 0);
        split.transform.localScale = new Vector3(2, 2 / (splitterWidth / 10), 1);
        split.transform.localEulerAngles = Vector3.zero;

        //Creates both temporary materials required to create the splitscreen.
        Material tempMat = new Material(Shader.Find("Unlit/Color"));
        tempMat.color = splitterColor;
        splitter.GetComponent<Renderer>().material = tempMat;
        splitter.GetComponent<Renderer>().sortingOrder = 2;
        splitter.layer = LayerMask.NameToLayer("TransparentFX");
        Material tempMat2 = new Material(Shader.Find("Mask/SplitScreen"));
        split.GetComponent<Renderer>().material = tempMat2;
        split.layer = LayerMask.NameToLayer("TransparentFX");

	    Camera.SetupCurrent(camera1.GetComponent<Camera>());

	    player1RigidBody = player1.GetComponent<Rigidbody>();
	    player2RigidBody = player2.GetComponent<Rigidbody>();
	}

	void LateUpdate ()
	{
        //Gets the z axis distance between the two players and just the standard distance.
        float zDistance = player1.position.z - player2.transform.position.z;
        float distance = Vector3.Distance(player1.position, player2.transform.position);

        //Sets the angle of the player up, depending on who's leading on the x axis.
        float angle;
        if (player1.transform.position.x <= player2.transform.position.x)
        {
            angle = Mathf.Rad2Deg * Mathf.Acos(zDistance / distance);
        }
        else
        {
            angle = Mathf.Rad2Deg * Mathf.Asin(zDistance / distance) - 90;
        }

        //Rotates the splitter according to the new angle.
        splitter.transform.localEulerAngles = new Vector3(0, 0, angle);

        //Gets the exact midpoint between the two players.
        Vector3 midPoint = new Vector3((player1.position.x + player2.position.x) / 2, (player1.position.y + player2.position.y) / 2, (player1.position.z + player2.position.z) / 2);

        //Waits for the two cameras to split and then calcuates a midpoint relevant to the difference in position between the two cameras.
        if (distance > splitDistance)
        {
            Vector3 offset = midPoint - player1.position;
            offset.x = Mathf.Clamp(offset.x, -splitDistance / 2, splitDistance / 2);
            offset.y = Mathf.Clamp(offset.y, -splitDistance / 2, splitDistance / 2);
            offset.z = Mathf.Clamp(offset.z, -splitDistance / 2, splitDistance / 2);
            midPoint = player1.position + offset;

            Vector3 offset2 = midPoint - player2.position;
            offset2.x = Mathf.Clamp(offset.x, -splitDistance / 2, splitDistance / 2);
            offset2.y = Mathf.Clamp(offset.y, -splitDistance / 2, splitDistance / 2);
            offset2.z = Mathf.Clamp(offset.z, -splitDistance / 2, splitDistance / 2);
            Vector3 midPoint2 = player2.position - offset;

            //Sets the splitter and camera to active and sets the second camera position as to avoid lerping continuity errors.
            if (splitter.activeSelf == false)
            {
                splitter.SetActive(true);
                camera2.SetActive(true);

                camera2.transform.position = camera1.transform.position;
                camera2.transform.rotation = camera1.transform.rotation;

            }
            else
            {
                float velocity2 = player2RigidBody.velocity.magnitude / 50f;
                Vector3 cameraOffset2 = Vector3.Lerp(minOffset, maxOffset, velocity2);
                //Lerps the second cameras position and rotation to that of the second midpoint, so relative to the second player.
                camera2.transform.position = Vector3.Lerp(camera2.transform.position, midPoint2 + cameraOffset2, Time.deltaTime * 5);
                Quaternion newRot2 = Quaternion.LookRotation(midPoint2 - camera2.transform.position);
                camera2.transform.rotation = Quaternion.Lerp(camera2.transform.rotation, newRot2, Time.deltaTime * 5);
            }

        }
        else
        {
            //Deactivates the splitter and camera once the distance is less than the splitting distance (assuming it was at one point).
            if (splitter.activeSelf)
                splitter.SetActive(false);
            camera2.SetActive(false);
        }

        /*Lerps the first cameras position and rotation to that of the second midpoint, so relative to the first player
		or when both players are in view it lerps the camera to their midpoint.*/
	    float velocity = player1RigidBody.velocity.magnitude / 50f;
	    Vector3 cameraOffset = Vector3.Lerp(minOffset, maxOffset, velocity);
        camera1.transform.position = Vector3.Lerp(camera1.transform.position, midPoint + cameraOffset, Time.deltaTime * 5);
        Quaternion newRot = Quaternion.LookRotation(midPoint - camera1.transform.position);
        camera1.transform.rotation = Quaternion.Lerp(camera1.transform.rotation, newRot, Time.deltaTime * 5);
    }
}
