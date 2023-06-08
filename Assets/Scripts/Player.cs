using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 25f;

    private bool isWalking;
    private void Update()
    {
        Walk(gameInput.GetMovementVectorNormalized());
    }
    private void Walk(Vector2 inputVector)
    {
        isWalking = inputVector != Vector2.zero;
        if (isWalking)
        {
            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
