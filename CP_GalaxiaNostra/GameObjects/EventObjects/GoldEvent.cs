using System;
using System.Collections.Generic;
using System.Text;


public class GoldEvent : Item, IInteractable
{
    public GoldEvent() => Init();

    private void Init()
    {
        Symbol = "💰";
    }


    public override void UseItemEffect()
    {
        // 골드 획득
        Owner.GetCoin(10);

        // 힐 사용후 끊을 것들
        Inventory.RemoveInven(this);
        Inventory = null;
        Owner = null;

        // Debug.Log("Use Potion");


    }

    public void Interact(Player player)
    {

        player.AddItem(this);
        UseItemEffect();

    }

    public void Interact(GameObject player)
    {

    }
}

