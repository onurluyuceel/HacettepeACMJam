using UnityEngine;

[CreateAssetMenu(fileName = "RobotEnemy", menuName = "ScriptableObject/RobotEnemyScriptableObject")]
public class RobotEnemyScriptableObject : ScriptableObject
{
    #region Fields

    [SerializeField] private Sprite sprite;
    [SerializeField] private float defaultMovingSpeed;
    [SerializeField] private float sprintingSpeed;
    [SerializeField] private float visionRadius;



    #endregion

    #region Properties
    public float DefaultMovingSpeed { get { return defaultMovingSpeed; } }
    public float SprintingSpeed { get { return sprintingSpeed; } }
    public Sprite Sprite { get { return sprite; } }
    public float VisionRadius { get { return visionRadius; } }
    #endregion
}