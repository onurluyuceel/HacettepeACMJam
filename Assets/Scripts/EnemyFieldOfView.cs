using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyFieldOfView : MonoBehaviour {
    [SerializeField] private HumanEnemyScriptableObject humanEnemyScriptableObject;
    private float radius;
    private float angle;
    private LayerMask targetLayer;
    private LayerMask obstructionLayer;

    private GameObject playerRef;

    public bool CanSeePlayer { get; private set; }

    private void Start() {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
        radius = humanEnemyScriptableObject.VisionRadius;
        angle = humanEnemyScriptableObject.VisionAngle;
        targetLayer = humanEnemyScriptableObject.TargetLayer;
        obstructionLayer = humanEnemyScriptableObject.ObstructionLayer;
    }

    private IEnumerator FOVCheck() {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true) {
            yield return wait;
            FOV();
        }
    }

    private void FOV() {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0 ) {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right, directionToTarget) < angle / 2) {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer)) { 
                    CanSeePlayer = true;
                }
                else {
                    CanSeePlayer = false;
                }
            }
            else {
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer) {
            CanSeePlayer = false;
        }
    }
}    

