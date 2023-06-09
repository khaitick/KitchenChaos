using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 25f;
    [SerializeField] private LayerMask counterLayerMask;

    private float playerRadius = 0.7f;
    private float playerHeight = 2f;
    private bool isWalking;
    private Vector3 lastInteractDir;

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        bool canInteract = Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask);
        if (canInteract)
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        isWalking = inputVector != Vector2.zero;

        if (isWalking)
        {
            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
            float moveDistance = moveSpeed * Time.deltaTime;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

            if (!canMove)
            {
                // Attempt only X movement
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirX;
                }
                else
                {
                    // Attempt only Z movement
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        moveDir = moveDirZ;
                    }
                }
            }

            if (canMove)
            {
                transform.position += moveDir * moveDistance;
                transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
            }
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
