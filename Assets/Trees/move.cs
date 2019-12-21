using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]

public class move : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float cameraSensitivity = 100f;
    //public float gravity = 100f;

    Vector2 rotation = new Vector2();
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        rotation.x += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotation.y, Vector3.left);

        Vector3 rotatedMovement = Vector3.RotateTowards(new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * movementSpeed * Time.fixedDeltaTime), transform.forward, 2 * Mathf.PI, 0f);

        transform.localPosition += new Vector3(rotatedMovement.x, 0, rotatedMovement.z);
    }
}