using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class NitroPowerUp : PowerUp
    {
        protected override void ApplyEffect(GameObject player)
        {
            player.GetComponent<Nitro>().AddNitro();
        }
    }
}