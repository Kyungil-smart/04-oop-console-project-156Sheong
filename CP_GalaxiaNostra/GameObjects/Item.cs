using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item : GameObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Inventory Inventory { get; set; }
    public bool InInventory
    {
        get => Inventory != null;
    }
    public Player Owner { get; set; }

    // 아이템 마다 사용이 다르기에 추상 함수로 함 
    public abstract void UseItemEffect();

    public void PrintInfo()
    {

    }
}