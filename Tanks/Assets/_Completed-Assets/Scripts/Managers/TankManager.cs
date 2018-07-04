using System;
using UnityEngine;

namespace Complete
{
    [Serializable]
    public class TankManager
    {
        // This class is to manage various settings on a tank.
        // It works with the GameManager class to control how the tanks behave
        // and whether or not players have control of their tank in the 
        // different phases of the game.

        public Color m_PlayerColor;                             // This is the color this tank will be tinted.
        public Transform m_SpawnPoint;                          // The position and direction the tank will have when it spawns.
        public TankInput.PlayerType playerType;
        public TankMovement.MovementType movementType;
        [HideInInspector] public int m_PlayerNumber;            // This specifies which player this the manager for.
        [HideInInspector] public string m_ColoredPlayerText;    // A string that represents the player with their number colored to match their tank.
        [HideInInspector] public GameObject m_Instance;         // A reference to the instance of the tank when it is created.
        [HideInInspector] public int m_Wins;                    // The number of wins this player has so far.

        public int kills = 0;
        public int deaths = 0;

        private TankInput m_Input;
        private TankMovement m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
        private TankShooting m_Shooting;                       // Reference to tank's movement script, used to disable and enable control.
        private TankShootingBullets m_ShootingBullets;                        
        private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.

        private bool _started = false;

        public void Setup ()
        {
            // Get references to the components.
            m_Input = m_Instance.GetComponent<TankInput>();
            m_Movement = m_Instance.GetComponent<TankMovement>();
            m_Shooting = m_Instance.GetComponent<TankShooting>();
            m_ShootingBullets = m_Instance.GetComponent<TankShootingBullets>();
            m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas> ().gameObject;

            // Set the player numbers to be consistent across the scripts.
            m_Input.m_PlayerNumber = m_PlayerNumber;
            m_Input.playerType = playerType;
            m_Movement.m_PlayerNumber = m_PlayerNumber;
            m_Movement.movementType = movementType;
            m_Shooting.m_PlayerNumber = m_PlayerNumber;
            m_ShootingBullets.m_PlayerNumber = m_PlayerNumber;

            // Create a string using the correct color that says 'PLAYER 1' etc based on the tank's color and the player's number.
            m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

            // Get all of the renderers of the tank.
            MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer> ();

            // Go through all the renderers...
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].tag == "CarBody")
                {
                    // ... set their material color to the color specific to this tank.
                    renderers[i].material.color = m_PlayerColor;
                }
                
            }
        }


        // Used during the phases of the game where the player shouldn't be able to control their tank.
        public void DisableControl ()
        {
            m_Input.enabled = false;
            m_Movement.enabled = false;
            m_Shooting.enabled = false;
            m_ShootingBullets.enabled = false;

            m_CanvasGameObject.SetActive (false);
        }


        // Used during the phases of the game where the player should be able to control their tank.
        public void EnableControl ()
        {
            m_Input.enabled = true;
            m_Movement.enabled = true;
            m_Shooting.enabled = true;
            m_ShootingBullets.enabled = true;

            m_CanvasGameObject.SetActive (true);
        }


        // Used at the start of each round to put the tank into it's default state.
        public void Reset ()
        {
            var heath = m_Instance.GetComponent<TankHealth>();

            if (heath.m_CurrentHealth <= 0f)
            {
                m_Instance.transform.position = m_SpawnPoint.position;
                m_Instance.transform.rotation = m_SpawnPoint.rotation;

                m_Instance.SetActive(false);
                m_Instance.SetActive(true);

                if (_started)
                {
                    deaths++;
                }
                else
                {
                    _started = true;
                }
                
            }
            else
            {
                if (_started)
                {
                    kills++;
                }
                else
                {
                    _started = true;
                }
            }
        }
    }
}