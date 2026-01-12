using System;
using System.Collections.Generic;
using System.Text;


public interface IInteractable
{
    public void Interact(Player player);
    public void Interact(GameObject player);
}

