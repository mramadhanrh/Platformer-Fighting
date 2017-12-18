using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHuman
{
    void Walk(float _speed, Vector2 _direction);
    void Attack(float _damageOut);
    void Jump(float _jumpForce);
    void Damaged(float _damageIn);
}

public class Human : IHuman
{
    public GameObject m_GameObject;
    Rigidbody2D m_Rigidbody;

    public Human(GameObject _gameObject)
    {
        m_GameObject = _gameObject;
        m_Rigidbody = m_GameObject.GetComponent<Rigidbody2D>();
    }

    public virtual void Walk(float _speed, Vector2 _direction)
    {
        m_GameObject.transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public virtual void Attack(float _damageOut)
    {
        Debug.Log("attack");
    }

    public virtual void Jump(float _jumpForce)
    {
        m_Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public virtual void Damaged(float _damageIn)
    {
        throw new System.NotImplementedException();
    }
}