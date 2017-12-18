using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Behaviour))]
public class BehaviourEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Behaviour m_Behaviour = (Behaviour)target;

        if (m_Behaviour.m_AttackBehaviour == AttackBehaviour.Ranged_Attack)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Assign Projectile : ", EditorStyles.boldLabel);
            m_Behaviour.m_Projectile = (GameObject)EditorGUILayout.ObjectField("Projectile", m_Behaviour.m_Projectile, typeof(GameObject), true);
        }
        else
        {
            m_Behaviour.m_Projectile = null;
        }
    }

}
