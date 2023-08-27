using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringCollection", menuName = "ScriptableObject/StringCollection")]
internal sealed class StringCollection : ScriptableObject
{
    public List<string> Collection;
}
