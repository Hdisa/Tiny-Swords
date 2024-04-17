using UnityEngine;

public class cameraControler : MonoBehaviour
{
    public float moveSpeed, zoomSpeed;

    private Camera _cam;

    public float minZoom, maxZoom, startZoom;

    private void Start()
    {
        _cam = GetComponent<Camera>();

        _cam.fieldOfView = startZoom;
    }

    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(new Vector3(hor, ver) * (Time.deltaTime * moveSpeed));

        if (_cam.fieldOfView >= minZoom || _cam.fieldOfView <= maxZoom)
        {
            _cam.fieldOfView += scroll * (zoomSpeed);
        }
        if(_cam.fieldOfView <= minZoom)
        {
            _cam.fieldOfView = minZoom + 1;
        }
        if(_cam.fieldOfView >= maxZoom)
        {
            _cam.fieldOfView = maxZoom - 1;
        }
        
    }
}
