using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class TankInput : MonoBehaviour
    {

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

        private CarAI _carAI;
        private TankMovement _movement;

        private void Start()
        {
            m_MovementAxisName = "Vertical" + m_PlayerNumber;
            m_TurnAxisName = "Horizontal" + m_PlayerNumber;
            m_FireButton1 = "Fire" + m_PlayerNumber;
            m_FireButton2 = "Fire" + m_PlayerNumber + "_2";

            _carAI = GetComponent<CarAI>();
            _movement = GetComponent<TankMovement>();

            if (playerType == PlayerType.AI)
            {
                _carAI.enabled = true;
                _movement.enabled = false;
            }
            else
            {
                _carAI.enabled = false;
                _movement.enabled = true;
            }
        }

        void Update()
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
            m_VerticalAxis =    _carAI._VerticalAxis;
            m_HorizontalAxis =  _carAI._HorizontalAxis;
            m_Fire1Down =       _carAI._Fire1Down;
            m_Fire2Down =       _carAI._Fire2Down;
            m_Fire1 =           _carAI._Fire1;
            m_Fire2 =           _carAI._Fire2;
            m_Fire1Up =         _carAI._Fire1Up;
            m_Fire2Up =         _carAI._Fire2Up;
        }


        public enum PlayerType
        {
            Human,
            AI
        }
    }
}
