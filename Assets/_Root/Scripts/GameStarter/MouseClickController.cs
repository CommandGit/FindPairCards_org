
using UnityEngine;

internal sealed class MouseClickController : BaseEnabled, IUpdate
{
    public void Update(float deltaTime)
    {
        if (!_enable) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                CardView cardView = hitInfo.collider.GetComponentInParent<CardView>();
                if (cardView != null) cardView.Click();
            }
        }
    }

    public void OnPauseChanged(bool pauseValue)
    {
        _enable = !pauseValue;
    }
}
