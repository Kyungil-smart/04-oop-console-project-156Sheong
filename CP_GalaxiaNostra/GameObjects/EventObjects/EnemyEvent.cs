using System;
using System.Collections.Generic;
using System.Text;


public class EnemyEvent : Item, IInteractable
{
    public EnemyEvent() => Init();

    private void Init()
    {
        Symbol = "🚨";
    }


    public override void UseItemEffect()
    {
        // 아이템 사용효과
        Owner.Encounter();

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
