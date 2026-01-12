using System;
using System.Collections.Generic;
using System.Text;


// 캐릭터 메뉴, 인벤토리 응용해서 생성
internal class CharacterMenu
{
    private List<Item> _items = new List<Item>();

    public bool IsActive { get; set; }
    public MenuList _characterMenu = new MenuList();
    private GameObject _owner;


    public CharacterMenu(GameObject owner)
    {
        _owner = owner;
    }

    public void AddItem(Item item)
    {
        /*
        if (_items.Count >= 10) return;

        _items.Add(item);
        _itemMenu.AddMenu(item.Name, item.UseItemEffect);
        item.Inventory = this;
        item.Owner = _owner;
        */
    }


    public void RemoveInven(Item item)
    {
        /*
        _items.Remove(item);
        _itemMenu.RemoveMenu();
        */
    }


    // 가방의 아이템 출력
    public void Render()
    {
        if (!IsActive) return;

        _characterMenu.RenderLeft(15, 1);
    }



    public void Select()
    {
        if (!IsActive) return;

        _characterMenu.SelectMenu();
    }

    public void SelectUp()
    {
        if (!IsActive) return;

        _characterMenu.SelectUp();
    }

    public void SelectDown()
    {
        if (!IsActive) return;

        _characterMenu.SelectDown();
    }


    // 아무 동작 안하는 매서드
    public void TempMethod()
    {

    }

}

