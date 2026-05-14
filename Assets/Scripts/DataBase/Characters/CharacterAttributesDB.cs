using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Character DB/Attributes")]
public class CharacterAttributesDB:ScriptableObject
{
    public List<CharacterAttributesBluePrint> characterAttributes;
}
