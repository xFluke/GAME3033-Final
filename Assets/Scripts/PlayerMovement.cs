using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private CharacterController characterController;

    private Vector2 movementInputVector = Vector2.zero;
    private Vector3 movementDirection = Vector3.zero;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = transform.forward * movementInputVector.y + transform.right * movementInputVector.x;

        characterController.Move(movementDirection * speed * Time.deltaTime);
    }

    public void OnMovement(InputValue value) {
        movementInputVector = value.Get<Vector2>();
    }
}
