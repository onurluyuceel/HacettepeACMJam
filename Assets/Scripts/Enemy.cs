using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    protected float speed;
    protected float visionRadius;
    protected float awarenessTime;
    protected float awarenessDuration;
    protected bool isSuspicious;
    protected bool isAlerted;
    protected Timer timer;

    List<RaycastHit2D> hit = new List<RaycastHit2D>();

    private void Awake() {
        
    }
}
