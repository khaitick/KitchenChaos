using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO KitchenObjectSO { get { return kitchenObjectSO; } } 
    public ClearCounter ClearCounter { get { return clearCounter; } set { clearCounter = value; } }
}
