using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInput : MonoBehaviour {

    public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.

    public PlayerType playerType;

    public float m_VerticalAxis;
    public float m_HorizontalAxis;

    public bool m_Fire1Down;
    public bool m_Fire2Down;
    public bool m_Fire1;
    public bool m_Fire2;
    public bool m_Fire1Up;
    public bool m_Fire2Up;

    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
    private string m_FireButton1;                // The input axis that is used for launching shells.
    private string m_FireButton2;                // The input axis that is used for launching shells.

    private void Start ()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        m_FireButton1 = "Fire" + m_PlayerNumber;
        m_FireButton2 = "Fire" + m_PlayerNumber + "_2";
    }
	
	void Update ()
    {
        if (playerType == PlayerType.Human)
        {
            ReadPlayerInput();
        }
        else
        {
            ReadAiInput();
        }
    }

    private void ReadPlayerInput()
    {
        m_VerticalAxis = Input.GetAxis(m_MovementAxisName);
        m_HorizontalAxis = Input.GetAxis(m_TurnAxisName);

        m_Fire1Down = Input.GetButtonDown(m_FireButton1);
        m_Fire1 = Input.GetButton(m_FireButton1);
        m_Fire1Up = Input.GetButtonUp(m_FireButton1);

        m_Fire2Down = Input.GetButtonDown(m_FireButton2);
        m_Fire2 = Input.GetButton(m_FireButton2);
        m_Fire2Up = Input.GetButtonUp(m_FireButton2);
    }

    private void ReadAiInput()
    {

    }


    public enum PlayerType
    {
        Human,
        AI
    }
}
