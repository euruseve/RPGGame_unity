using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    public GameObject shopUI;

    public int[] amt;
    public int[] cost;
    public int[] iconNum;
    public int[] invetoryItems;

    public Text[] itemAmtText;
    public Text currencyText;
    private Text compare;

    private int max = 0;
    private bool canClick = true;

    public bool tavern = false;

    private void Start() 
    {
        max = itemAmtText.Length;   
        currencyText.text = InventoryItems.gold.ToString();    
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void BuyButton()
    {
        if(canClick)
        {   
            for(int i = 0; i < max; i++)
            {
                if(itemAmtText[i] == compare)
                {
                    max = i;

                    if(amt[i] > 0)
                    {
                        if(tavern)
                        {
                            UpdateTavernAmt();
                        }

                        if(InventoryItems.gold >= cost[i])
                        {
                            if(invetoryItems[i] == 0)
                            {
                                InventoryItems.newIcon = iconNum[i];
                                InventoryItems.iconUpdate = true;
                            }

                            InventoryItems.gold -= cost[i];

                            if(tavern)
                            {
                                SetTavernAmt(i);
                            }
                        }
                    }
                }
            }
        }
    }

    void UpdateTavernAmt()
    {
        invetoryItems[0] = InventoryItems.bread;
        invetoryItems[1] = InventoryItems.cheese;
        invetoryItems[2] = InventoryItems.meat;
    }

    public void UpdateGold()
    {
        currencyText.text = InventoryItems.gold.ToString();
    }

    void SetTavernAmt(int item)
    {
        if(item == 0)
        {
            InventoryItems.bread++;
        }
        if(item == 1)
        {
            InventoryItems.cheese++;
        }
        if(item == 2)
        {
            InventoryItems.meat++;
        }
        amt[item]--;
        itemAmtText[item].text = amt[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmtText.Length;
    }

    public void Bread()
    {
        compare = itemAmtText[0];
        Check(0);
    }
    public void Cheese()
    {
        compare = itemAmtText[1];
        Check(1);
    }
    public void Meat()
    {
        compare = itemAmtText[2];
        Check(2);
    }

    void Check(int val)
    {
        if(amt[val] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;   
        }
    }
}
