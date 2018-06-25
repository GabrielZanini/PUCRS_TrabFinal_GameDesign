using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class MissilePowerUp : PowerUp
    {
        public int ammo = 5;

        protected override void ApplyEffect(GameObject player)
        {
            player.GetComponent<TankShooting>().m_Ammo += ammo;
        }
    }
}
