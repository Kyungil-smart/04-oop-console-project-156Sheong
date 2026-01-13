using System;
using System.Collections.Generic;
using System.Text;


public class RepairEvent : Item, IInteractable
{
    public RepairEvent() => Init();

    private void Init()
    {
        Symbol = "⚓";
    }


    public override void UseItemEffect()
    {
        // 골드 소모 및 아이템 사용효과
        if(Owner.Coin >= 8)
        {
            Owner.UseCoin(8);
            Owner.GetRepair(12);

            // 힐 사용후 끊을 것들
            Inventory.RemoveInven(this);
            Inventory = null;
            Owner = null;

            // Debug.Log("Use Potion");
        }

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
