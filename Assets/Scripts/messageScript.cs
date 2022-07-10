using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class messageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;

    public GameObject shopUI;


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMove.canMove = true;
    }

    private void Start() 
    {
        shopOwnerMessage.text = $"hello {SaveScript.pname} how can i help you";
    }

    private void Update() 
    {
        if(PlayerMove.canMove == true && PlayerMove.moving == true)
        {
            if(shopUI != null)
            {
                shopUI.SetActive(false);
            }    
        }
    }

    public void Message1()
    {
        shopOwnerMessage.text = "not much going on around here";
    }

    public void Message2()
    {
        shopOwnerMessage.text = "select items from the list";
        shopUI.SetActive(true);
        shopUI.GetComponent<BuyScript>().UpdateGold();
    }
}
