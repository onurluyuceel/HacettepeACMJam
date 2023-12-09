using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HumanEnemy", menuName = "ScriptableObject/HumanEnemyScriptableObject")]
public class HumanEnemyScriptableObject : ScriptableObject
{
    #region Fields

    [SerializeField] private Sprite sprite;
    [SerializeField] private float defaultMovingSpeed;
    [SerializeField] private float sprintingSpeed;
    [SerializeField] private float visionRadius;
    [SerializeField] private float visionAngle;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask obstructionLayer;
    #endregion

    #region Properties
    public float DefaultMovingSpeed { get { return defaultMovingSpeed; } }
    public float SprintingSpeed { get { return sprintingSpeed; } }
    public Sprite Sprite { get { return sprite; } }
    public float VisionRadius { get { return visionRadius; } }
    public float VisionAngle { get {  return visionAngle; } }
    public LayerMask TargetLayer { get { return targetLayer; } }
    public LayerMask ObstructionLayer { get { return obstructionLayer; } }
    #endregion
}
