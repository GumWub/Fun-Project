using UnityEngine;

[System.Serializable]
public class CharacterAttributesBluePrint
{
    public string Name;
    public float Mass;
    public float DragCoefficient;
    public float[] CrossSectionnalArea = new float[3];
}
