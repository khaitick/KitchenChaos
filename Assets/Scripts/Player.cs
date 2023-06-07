using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Vector2 inputVector;
    private float speed = 0;

    private void Start()
    {
        speed = moveSpeed;
    }

    private void Update()
    {
        inputVector = new Vector2(0, 0);
        speed = moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y += -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position +=  moveDir * Time.deltaTime * speed;
        Debug.Log(inputVector);
    }
}
