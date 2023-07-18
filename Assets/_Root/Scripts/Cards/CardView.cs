using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

internal sealed class CardView : MonoBehaviour, IDestroyable
{
    public Transform Transform;
    public Transform ZTransform;
    public Transform YRotator;
    public TMP_Text NumberText;

    public event Action ActionOnDestroy = delegate { };
    public event Action ActionOnClick = delegate { };

    private void OnDestroy()
    {
        ActionOnDestroy.Invoke();
    }

    public void Click()
    {
        ActionOnClick.Invoke();
    }
}
