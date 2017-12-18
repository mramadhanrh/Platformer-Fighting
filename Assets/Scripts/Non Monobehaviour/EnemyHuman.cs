using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviour
{
    void SetWalkBehaviour();
    void SetAttackBehaviour();
}

public class EnemyHuman : Human, IBehaviour {

    public Attribute m_Attribute;
    public Behaviour m_Behaviour;
    EnemyAIScript m_EnemyAI;

    public EnemyHuman(GameObject _gameObject, Behaviour _behaviour, Attribute _Attribute) : base(_gameObject)
    {
        m_Attribute = _Attribute;
        m_Behaviour = _behaviour;
        m_EnemyAI = m_GameObject.GetComponent<EnemyAIScript>();
        SetWalkBehaviour();
    }

    public void ChaseOnRange()
    {
        Vector2 _direction = new Vector2(getCharacterDirectionX(), 0);
        Debug.Log(getCharacterDirectionX());
        float _speed = m_Attribute.m_Speed;
        base.Walk(_speed, _direction);        
    }

    int getCharacterDirectionX()
    {
        Transform _charTrans = CharacterScript.Instance.transform;
        Vector2 _dir = new Vector2(_charTrans.position.x, 0) - new Vector2(m_GameObject.transform.position.x, 0);
        if (_dir.normalized.x > 0f)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public void SetWalkBehaviour()
    {
        switch (m_Behaviour.m_WalkBehaviour)
        {
            case WalkBehaviour.Chase_On_Range:
                m_EnemyAI.OnWalk += ChaseOnRange;
                break;
            default:
                break;
        }
    }

    public void SetAttackBehaviour()
    {
        throw new System.NotImplementedException();
    }
}
