using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SettingsPanelModelSettings), menuName = "ScriptableObject/" + nameof(SettingsPanelModelSettings))]
internal sealed class SettingsPanelModelSettings : ScriptableObject
{
  public bool IsEnable { get;  set; }
}
