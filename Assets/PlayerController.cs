using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (plane == null)
        {
            plane = GameObject.Find("Plane").transform; // finds object named "Plane"
        }
        // Get plane size based on scale (Unity's default plane is 10x10 units)
        float planeWidth = plane.localScale.x * 10f;
        float planeHeight = plane.localScale.z * 10f;

        // Calculate boundaries based on plane position and size
        Vector3 planePos = plane.position;
        minX = planePos.x - planeWidth / 2f;
        maxX = planePos.x + planeWidth / 2f;
        minZ = planePos.z - planeHeight / 2f;
        maxZ = planePos.z + planeHeight / 2f;
    }

    //Update
    public float speed = 5.0f;
    public Transform plane; // reference to the Plane object in the scene
    private float minX, maxX, minZ, maxZ;
    public float planeY = 0.5f; // height of sphere above the plane
    // Update is called once per frame void Update()
    void Update()
    {
        // Get player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);

        //sphere stays on the plane
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        pos.y = planeY; // lock sphere height
        transform.position = pos;

    }

}
