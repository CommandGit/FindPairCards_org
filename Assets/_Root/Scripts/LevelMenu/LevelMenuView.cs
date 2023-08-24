using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal sealed class LevelMenuView : MonoBehaviour
{
    [SerializeField] public GameObject levelMenuObject;
    [SerializeField] public List<Button> levelButtons;
    [SerializeField] public Button backToMenuButton;
}
