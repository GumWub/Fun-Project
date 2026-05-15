using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Databases")]
    [SerializeField] public CharacterAttributesDB CharacterDB;
    [HideInInspector] public int CurrentCharacterIndex;

    [SerializeField] public EnvironmentDB EnvironmentDB;
    [HideInInspector] public int CurrentEnvironmentIndex;

    //Current Character Attributes
    [HideInInspector] public CharacterAttributesBluePrint CurrentCharacter;

    //Current Environment Attributes
    [HideInInspector] public EnvironmentPropertiesBluePrint CurrentEnvironment;


    private void Start()
    {
        HandleCharacterSelection();
        HandleEnvironmentSelection();
    }

    public void HandleCharacterSelection(int index)
    {
        CurrentCharacter.Name = CharacterDB.characterAttributes[CurrentCharacterIndex].Name;
        CurrentCharacter.Mass = CharacterDB.characterAttributes[CurrentCharacterIndex].Mass;
        CurrentCharacter.DragCoefficient = CharacterDB.characterAttributes[CurrentCharacterIndex].DragCoefficient;
        CurrentCharacter.CrossSectionnalArea = CharacterDB.characterAttributes[CurrentCharacterIndex].CrossSectionnalArea;
    }

    public void HandleEnvironmentSelection(int index)
    {
        CurrentEnvironment.Name = EnvironmentDB.EnvironmentProperties[CurrentEnvironmentIndex].Name;
        CurrentEnvironment.GravitationalAcceleration = EnvironmentDB.EnvironmentProperties[CurrentEnvironmentIndex].GravitationalAcceleration;
        CurrentEnvironment.AirDensity = EnvironmentDB.EnvironmentProperties[CurrentEnvironmentIndex].AirDensity;
    }
}
