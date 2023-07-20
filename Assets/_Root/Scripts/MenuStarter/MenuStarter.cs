using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class MenuStarter : MonoBehaviour
{
    private Menu _menu;
   private void Start()
    {
        _menu = new Menu();
        _menu.Start();
    }
    private void Update()
    {
        _menu.Update(Time.deltaTime);
    }

}
