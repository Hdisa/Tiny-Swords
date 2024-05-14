using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    Camera cam;
    float movementSpeed;
    
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        movementSpeed = cameraSettings.normalSpeed;
    }

    private void Update()
    {
        CameraZoom();
        if (cameraSettings.edgeMode) EdgeMovement();
        if (cameraSettings.keyboardMode) KeyboardMode();
    }

    //Движение клавишами
    private void KeyboardMode()
    {
        movementSpeed = cameraSettings.normalSpeed;
        
        if (Input.GetKey(cameraSettings.switchFast))
        {
            movementSpeed = cameraSettings.fastSpeed;
        }
 
        if (Input.GetKey(cameraSettings.moveUp) || Input.GetKey(KeyCode.UpArrow))
            transform.position += (transform.up * movementSpeed);
        
        if (Input.GetKey(cameraSettings.moveDown) || Input.GetKey(KeyCode.DownArrow))
            transform.position += (transform.up * - movementSpeed);
        
        if (Input.GetKey(cameraSettings.moveRight) || Input.GetKey(KeyCode.RightArrow))
            transform.position += (transform.right * movementSpeed);
        
        if (Input.GetKey(cameraSettings.moveLeft) || Input.GetKey(KeyCode.LeftArrow))
            transform.position += (transform.right * - movementSpeed);
    }

    //Движение камеры наведением курсора
    private void EdgeMovement()
    {
        // Move Right
        if (Input.mousePosition.x > Screen.width - cameraSettings.edgeSize)
            transform.position += transform.right * movementSpeed;
 
        // Move Left
        if (Input.mousePosition.x < cameraSettings.edgeSize)
            transform.position += transform.right * - movementSpeed;
 
        // Move Up
        if (Input.mousePosition.y > Screen.height - cameraSettings.edgeSize)
            transform.position += transform.up * movementSpeed;
 
        // Move Down
        if (Input.mousePosition.y < cameraSettings.edgeSize)
            transform.position += transform.up * - movementSpeed;
    }

    private void CameraZoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            cam.orthographicSize -= Input.mouseScrollDelta.y * Time.deltaTime * cameraSettings.zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, cameraSettings.zoomMin, cameraSettings.zoomMax);
        }
    }
}
