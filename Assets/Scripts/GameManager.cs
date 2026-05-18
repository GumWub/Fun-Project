using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private PlayerMovement playerMovement;

    [Space(20f)]
    [Header("Databases")]
    [SerializeField] public CharacterAttributesDB CharacterDB;
    [HideInInspector] public int CurrentCharacterIndex;

    [SerializeField] public EnvironmentDB EnvironmentDB;
    [HideInInspector] public int CurrentEnvironmentIndex;

    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        }
    }

    private void Start()
    {
        HandleCharacterSelection(CurrentCharacterIndex);
        HandleEnvironmentSelection(CurrentEnvironmentIndex);
    }
    public void HandleCharacterSelection(int index)
    {
        playerMovement.CurrentCharacter = CharacterDB.characterAttributes[index];
    }

    public void HandleEnvironmentSelection(int index)
    {
        playerMovement.CurrentEnvironment = EnvironmentDB.EnvironmentProperties[index];
    }
}
