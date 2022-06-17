using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float camSpeed = 20f;
    public float borderThickness = 10f;
    public Vector2 camLimit;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 100f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderThickness)
        {
            pos.z += camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= borderThickness)
        {
            pos.z -= camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderThickness)
        {
            pos.x += camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= borderThickness)
        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -camLimit.x, camLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -camLimit.y, camLimit.y);

        transform.position = pos;
    }
}
