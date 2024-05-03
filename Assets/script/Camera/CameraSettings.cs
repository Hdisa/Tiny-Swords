using UnityEngine;

[CreateAssetMenu (menuName = "Game Tools/Camera Settings")]
public class CameraSettings : ScriptableObject
{
    [Header("Camera Modes")]
    public bool edgeMode; //Управление мышкой
    public bool keyboardMode; //Управление клавиатурой
    
    [Header("Velocity Modes")]
    public float fastSpeed = 0.05f;
    public float normalSpeed = 0.01f;
    public KeyCode switchFast = KeyCode.LeftShift;
    
    [Header("Edge Settings")]
    public int edgeSize = 50;

    [Header("Zoom Settings")]
    public int zoomSpeed = 50;
    public int zoomMin = 5;
    public int zoomMax = 15;

    [Header("Keyboard Settings")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
}
