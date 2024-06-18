using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIinventory InventoryUI;

    public int inventorySize = 10;

    private void Start()
    {
        InventoryUI.InitalizeInventoryUI(inventorySize);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.isActiveAndEnabled == false)
            {
                //활성화
                InventoryUI.Show();
            }
            else
            {
                //비활성화
                 InventoryUI.Hide();
            }
        
        }
    }

}
