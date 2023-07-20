using UnityEngine;

internal sealed class PauseKeyController
{
    public EventHandler OnKeyPressed = new EventHandler();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnKeyPressed.Handle();
        }
    }
}
