using UnityEngine;

public class Player : MonoBehaviour
{
    private float time;
    private int counter = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if(time > counter)
        {
            counter += 1;
            Debug.Log(counter);
        }
    }
}
