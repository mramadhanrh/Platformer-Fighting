using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    
    CharacterScript m_CharacterScript;
    

    void Awake()
    {
        m_CharacterScript = GetComponent<CharacterScript>();
        
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Control();
	}


    void Control()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_CharacterScript.StartWalkRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_CharacterScript.StartWalkLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_CharacterScript.StopWalking();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_CharacterScript.Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_CharacterScript.Attack();
        }
    }

    
}
