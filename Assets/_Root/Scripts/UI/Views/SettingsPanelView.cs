using UnityEngine;
using UnityEngine.UI;

internal sealed class SettingsPanelView : MonoBehaviour
{
    [SerializeField] public GameObject settingsPanelObject;
    [SerializeField] public Button closeSettingsPanelButton;
    [SerializeField] public Slider MasterVolumeSlider;
    [SerializeField] public Button SubmitButton;
}
