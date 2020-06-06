using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public PlayerModel(float Health)
        {
            health = Health;
        }

        public float health { get; set; }
    }
}

