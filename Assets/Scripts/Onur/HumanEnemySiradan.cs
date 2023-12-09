using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemySiradan : MonoBehaviour
{

    private Rigidbody2D humanEnemyRigidbody2D;
    private float alertDistance = 3f;
    private float moveSpeed;
    private GameObject player;
    private string PLAYER_TAG = "Player";
    [SerializeField] HumanEnemyScriptableObject humanEnemyScriptableObject;

    private void Awake()
    {
        moveSpeed = humanEnemyScriptableObject.DefaultMovingSpeed;
        alertDistance = humanEnemyScriptableObject.VisionRadius;
        humanEnemyRigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(PLAYER_TAG);
    }

    private void FixedUpdate()
    {
        Debug.Log(DistanceBetween());
        Chase();
    }

    private void Chase()
    {
        if(DistanceBetween() <= alertDistance)
        {
            Vector3 chaseDirection = player.transform.position - gameObject.transform.position;
            humanEnemyRigidbody2D.AddForce(chaseDirection * moveSpeed * Time.fixedDeltaTime);   
        }
    }

    private float DistanceBetween()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        return distance;
    }
}
