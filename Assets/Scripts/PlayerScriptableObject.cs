using UnityEngine;

[CreateAssetMenu (fileName = "Player", menuName = "ScriptableObject/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    #region Fields

    [SerializeField] private float jumpSpeed;
    [SerializeField] private float defaultMovingSpeed;
    [SerializeField] private float sprintingSpeed;
    [SerializeField] private float sneakingSpeed;

    #endregion

    #region Properties

    public float JumpSpeed { get { return jumpSpeed; } }
    public float DefaultMovingSpeed { get { return defaultMovingSpeed; } }
    public float SneakingSpeed { get { return sneakingSpeed; } }
    public float SprintingSpeed { get {  return sprintingSpeed; } }

    #endregion
}
