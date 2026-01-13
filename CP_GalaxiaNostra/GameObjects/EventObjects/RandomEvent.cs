using System;
using System.Collections.Generic;
using System.Text;


public class RandomEvent : Item, IInteractable
{
    public RandomEvent() => Init();

    private void Init()
    {
        Symbol = "❓";
    }


    public override void UseItemEffect()
    {
        Random randNumber = new Random();
        int number = randNumber.Next(0, 12);

        // 아이템 사용효과 (랜덤)
        if(number < 3)
        {
            Owner.GetFuel(6);
        }
        else if (number < 6)
        {
            Owner.GetRepair(6);
        }
        else if (number < 9)
        {
            Owner.GetCoin(5);
        }
        else
        {
            Owner.Encounter();
        }

            // 힐 사용후 끊을 것들
            Inventory.RemoveInven(this);
        Inventory = null;
        Owner = null;

        
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

