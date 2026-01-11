using System;
using System.Collections.Generic;
using System.Text;


public class Inventory
{
    private List<Item> _items = new List<Item>();
    public bool IsActive { get; set; }
    public MenuList _itemMenu = new MenuList();
    private Player _owner;

    public Inventory(Player owner)
    {
        _owner = owner;
    }


    public void Add(Item item)
    {
        if (_items.Count >= 10) return;

        _items.Add(item);
        _itemMenu.AddMenu(item.Name, item.UseItemEffect);
        item.Inventory = this;
        item.Owner = _owner;
    }


    public void RemoveInven(Item item)
    {
        _items.Remove(item);
        _itemMenu.RemoveMenu();
    }


    // 가방의 아이템 출력
    public void Render()
    {
        if (!IsActive) return;

        _itemMenu.RenderLeft(15, 1);
    }



    public void Select()
    {
        if (!IsActive) return;

        _itemMenu.SelectMenu();
    }

    public void SelectUp()
    {
        if (!IsActive) return;

        _itemMenu.SelectUp();
    }

    public void SelectDown()
    {
        if (!IsActive) return;

        _itemMenu.SelectDown();
    }


    // 아무 동작 안하는 매서드
    public void TempMethod()
    {

    }
}



