using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackBehaviour
{
    Charge_On_Distance,
    Close_Attack,
    Ranged_Attack
}

public enum WalkBehaviour
{
    Chase_On_Range,
    Chase_Anywhere,
    Loop_Patrol
}

[CreateAssetMenu(fileName="Behaviour", menuName="Behaviour", order=2)]
[System.Serializable]public class Behaviour : ScriptableObject {

    public AttackBehaviour m_AttackBehaviour;
    public WalkBehaviour m_WalkBehaviour;
    [HideInInspector] public GameObject m_Projectile;
    public float m_AttackDistanceThreshold;
    public float m_WalkDistanceThreshold;

}
