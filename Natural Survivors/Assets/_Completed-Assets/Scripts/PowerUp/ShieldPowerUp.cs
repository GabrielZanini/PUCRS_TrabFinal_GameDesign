using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class ShieldPowerUp : PowerUp
    {
        protected override void ApplyEffect(GameObject player)
        {
            player.GetComponent<TankShield>().ActivateShield(effectDuration);
        }
    }
}
