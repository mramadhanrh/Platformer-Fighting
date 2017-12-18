using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControl))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterScript : MonoBehaviour {

    private static CharacterScript instance;
    public static CharacterScript Instance { get { return instance; } }

    public Attribute m_Attribute;

    public float m_RayJumpRange;
    public bool m_IsGrounded;

    [Space(10f)]

    RaycastHit2D m_GroundHit;
    Animator m_Animator;
    Character m_Character;

    bool m_IsWalking;
    bool m_IsAttacking;

    void Awake()
    {
        instance = this;
        m_Character = new Character(this.gameObject, m_Attribute);
    }

	// U se this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        ExecuteHere();
	}


    void ExecuteHere()
    {
        CheckGroundStatus();
        Move();
    }

    void CheckGroundStatus()
    {
        Debug.DrawRay(transform.position, Vector2.down * m_RayJumpRange, Color.red);
        m_GroundHit = Physics2D.Raycast(transform.position, Vector2.down, m_RayJumpRange, 1 << LayerMask.NameToLayer("Ground"));
        if (m_GroundHit.collider)
        {
            m_IsGrounded = true;
        }
        else
        {
            m_IsGrounded = false;
        }
    }

    public void Attack()
    {
        if (!m_IsAttacking && !m_IsWalking)
        {
            m_Character.Attack(m_Attribute.m_Damage);
            m_Animator.SetTrigger("attack");
            m_IsAttacking = true;
            Invoke("SetAttack", getAnimationLength("C3_Shield1_1_Idle"));
        }
    }
    
    int getAnimationIndex(string _name)
    {
        AnimationClip[] anim = m_Animator.runtimeAnimatorController.animationClips;
        int i = 0;
        foreach (AnimationClip _anim in anim)
        {
            if (_anim.name == _name)
                return i;
            i++;
        }
        return 0;
    }

    float getAnimationLength(string _name)
    {
        return m_Animator.runtimeAnimatorController.animationClips[getAnimationIndex(_name)].length;
    }

    #region Walk

    public void StartWalkLeft()
    {
        if (!m_IsAttacking)
        {
            m_Character.Walk(m_Attribute.m_Speed, Vector2.left);
            m_IsWalking = true;
        }
    }

    public void StartWalkRight()
    {
        if (!m_IsAttacking)
        {
            m_Character.Walk(m_Attribute.m_Speed, Vector2.right);
            m_IsWalking = true;
        }
    }

    public void StopWalking()
    {
        m_IsWalking = false;
    }

    #endregion

    public void Jump()
    {
        if (m_IsGrounded)
            m_Character.Jump(m_Attribute.m_JumpForce);
    }

    public void Move()
    {
        if (!m_IsGrounded)
        {
            m_Animator.SetBool("walk", false);
            return;
        }
        else
        {
            m_Animator.SetBool("walk", m_IsWalking);
        }
    }

    public void SetAttack()
    {
        m_IsAttacking = false;
    }
}
