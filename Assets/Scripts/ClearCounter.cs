using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CountertopPoint;

    private KitchenObject kitchenObject;
    private Vector3 spawnOffset = new Vector3(0, 1.25f, 0);

    public void Interact()
    {
        if(kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, CountertopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.ClearCounter = this;
        }
        else
        {
            Debug.Log(kitchenObject.ClearCounter);
        }
    }
}
