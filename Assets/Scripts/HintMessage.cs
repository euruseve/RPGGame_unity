using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text message;
    public GameObject hintBox;

    private bool displaying = true;
    private bool overIcon = false;
    private Vector3 screenPoint;

    public int objectType = 0;

    private void Start() 
    {
        hintBox.SetActive(false);
    }

    private void Update() {
        if(overIcon)
        {
            if(Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;

        if(displaying)
        {
            hintBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x + 400;
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
        }

        hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        MessageDisplay();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon = false;
        hintBox.SetActive(false);
    }

    void MessageDisplay()
    {

        switch(objectType)
        {
            case 0:
                message.text = "empty";
            break;

            case 1:
                message.text = InventoryItems.redMushrooms.ToString() + " red mushrooms to be used in potions";
            break;

            case 2:
                message.text = InventoryItems.redMushrooms.ToString() + " purple mushrooms to be used in potions";
            break;

            case 3:
                message.text = InventoryItems.redMushrooms.ToString() + " brown mushrooms to be used in potions";
            break;

            case 4:
                message.text = InventoryItems.blueFlowers.ToString() + " blue flower to be used in potions";
            break;

            case 5:
                message.text = InventoryItems.blueFlowers.ToString() + " red flower to be used in potions";
            break;

            case 6:
                message.text = InventoryItems.blueFlowers.ToString() + " roots to be used in potions";
            break;

            case 7:
                message.text = InventoryItems.blueFlowers.ToString() + " leaf dew to be used in potions";
            break;

            case 8:
                message.text = InventoryItems.blueFlowers.ToString() + "key to open chests";
            break;

            case 9:
                message.text = InventoryItems.blueFlowers.ToString() + " dragon eggs to be used in potions";
            break;

            case 10:
                message.text = InventoryItems.blueFlowers.ToString() + " blue potion to be used in potions";
            break;

            case 11:
                message.text = InventoryItems.blueFlowers.ToString() + " purple potion to be used in potions";
            break;

            case 12:
                message.text = InventoryItems.blueFlowers.ToString() + " green potion to be used in potions";
            break;

            case 13:
                message.text = InventoryItems.blueFlowers.ToString() + " red potion to be used in potions";
            break;

            case 14:
                message.text = InventoryItems.blueFlowers.ToString() + " bread used to replenish health";
            break;

            case 15:
                message.text = InventoryItems.blueFlowers.ToString() + " cheese used to replenish health";
            break;

            case 16:
                message.text = InventoryItems.blueFlowers.ToString() + " meat used to replenish health";
            break;

            default:
                message.text = "empty";
                break;
        }
    }
}
