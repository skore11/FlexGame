using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Percubed.Flex
{
    public class Flex_Inherit : MonoBehaviour
    {
        public Flex_Collision m_flex_collsion;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_flex_collsion.hitFlex)
            {
                Component c = m_flex_collsion.other_object.GetComponent(typeof(IStorable));
                var copy =  c.GetCopyOf(c);
                this.gameObject.AddComponent(copy);
            }
        }
    }
}

