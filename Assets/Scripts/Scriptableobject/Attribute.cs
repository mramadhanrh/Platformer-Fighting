using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Attribute", menuName="Attribute", order=1)]
public class Attribute : ScriptableObject {

    public float m_Health;
    public float m_Damage;
    public float m_Speed;
    public float m_JumpForce;
}
