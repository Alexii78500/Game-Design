using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float panSpeed = 30f;
    private float margin = 10f;
    private bool canMove = true;
    private float scrollSpeed = 5;
    private float scroll;
    
    private float minY = 10;
    private float maxY = 120;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y > Screen.height - margin)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        
        else if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y < -margin)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        
        else if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x > Screen.width - margin)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x < -margin)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
