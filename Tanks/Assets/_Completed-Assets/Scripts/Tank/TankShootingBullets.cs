using UnityEngine;

namespace Complete
{
    public class TankShootingBullets : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
        public Rigidbody m_Shell;                   // Prefab of the shell.
        public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
        public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
        public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
        public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.

        public GameObject m_ShootingParticlesPrefab;                
        private ParticleSystem m_ShootingParticles;        // The particle system the will play when the tank is destroyed.

        public float m_FireRate = 0.1f;       // How long the shell can charge for before it is fired at max force.
        private float m_FireRateCount = 0f;
        

        private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.

        private TankInput TankInput;

        private void OnEnable()
        {
            TankInput = GetComponent<TankInput>();

            // When the tank is turned on, reset the launch force and the UI
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
        
        private void Start()
        {
            m_ShootingParticles = Instantiate(m_ShootingParticlesPrefab, m_FireTransform).GetComponent<ParticleSystem>();
            m_ShootingParticles.gameObject.SetActive(false);
        }
        
        private void Update()
        {
            if (TankInput.m_Fire1 && m_FireRateCount <= 0f)
            {
                Fire();
                m_FireRateCount = m_FireRate;
            }
            else if (m_FireRateCount > 0f) 
            {
                m_FireRateCount -= Time.deltaTime;
            }
        }
        
        private void Fire()
        {
            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance =
                Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            shellInstance.GetComponent<BulletExplosion>().player = gameObject;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

            ShootingParticle();

            // Change the clip to the firing clip and play it.
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();

            // Reset the launch force.  This is a precaution in case of missing button events.
            m_CurrentLaunchForce = m_MinLaunchForce;
        }

        private void ShootingParticle()
        {
            //m_ShootingParticles.transform.position = transform.position;
            m_ShootingParticles.gameObject.SetActive(true);
            m_ShootingParticles.Play();
        }
    }
}

