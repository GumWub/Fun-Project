using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Environment DB/Attributes")]
public class EnvironmentDB : ScriptableObject
{
    public List<EnvironmentAttributesBluePrint> EnvironmentAttributes;
}
