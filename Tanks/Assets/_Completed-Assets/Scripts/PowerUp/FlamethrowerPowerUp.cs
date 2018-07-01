using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class FlamethrowerPowerUp : PowerUp
    {
        protected override void ApplyEffect(GameObject player)
        {
            player.GetComponent<TankFlamethrower>().Activate(effectDuration);
        }
    }
}

