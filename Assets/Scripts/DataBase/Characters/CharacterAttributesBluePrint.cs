using UnityEngine;

[System.Serializable]
public class CharacterAttributesBluePrint
{
    public string CharacterName;
    public float CharacterMass;
    public float DragCoefficient;
    public float[] CrossSectionnalArea = new float[3];
}
