using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform Player;

    private Vector3 _mouseLook;

    [SerializeField] private float camSensitivity = 5f;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        LookInput();

        Player.Rotate(Vector3.up * _mouseX, Space.Self);
    }

    private void LookInput()
    {
        _mouseLook = NewInputManager.instance.playerInput.MouseLook.LookVector.ReadValue<Vector2>();

        _mouseX = _mouseLook.x * camSensitivity * Time.deltaTime;
    }
}
