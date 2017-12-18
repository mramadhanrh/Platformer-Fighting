using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Human {

    public Attribute m_Attribute;

    public Character(GameObject _gameObject, Attribute _attribute) : base(_gameObject)
    {
        //Initialized
    }
    

    public override void Walk(float _speed, Vector2 _direction)
    {
        base.Walk(_speed, _direction);
        m_GameObject.transform.localScale = new Vector3(_direction.x, m_GameObject.transform.localScale.y, m_GameObject.transform.localScale.z);
    }

    public override void Jump(float _jumpForce)
    {
        base.Jump(_jumpForce);
    }

    public override void Attack(float _damageOut)
    {
        base.Attack(_damageOut);
    }
}
