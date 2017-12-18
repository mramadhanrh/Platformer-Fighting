using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAIScript : MonoBehaviour {

    public delegate void WalkAction();
    public event WalkAction OnWalk;

    public delegate void AttackAction();
    public event AttackAction OnAttack;

    public Attribute m_Attribute;
    public Behaviour m_Behaviour;
    EnemyHuman m_EnemyHuman;

    void OnDisable()
    {
        Debug.Log("OnDisable");
        OnWalk = null;
    }

	// Use this for initialization
	void Start () {
        m_EnemyHuman = new EnemyHuman(gameObject, m_Behaviour, m_Attribute);
	}
	
	// Update is called once per frame
	void Update () {
        Walk();
	}

    void Walk()
    {
        OnWalk();
    }
}
