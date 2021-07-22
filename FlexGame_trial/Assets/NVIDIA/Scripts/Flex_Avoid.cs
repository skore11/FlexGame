using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

namespace Percubed.Flex
{
    public class Flex_Avoid : MonoBehaviour
    {
        public Flex_Collision m_collision_detect;

        private FlexSoftActor actor;

        private Vector4[] particles;

        private Vector3[] velocities;

        private void Awake()
        {
            actor = this.GetComponent<FlexSoftActor>();
        }
        // Start is called before the first frame update
        private void Start()
        {
            actor.onFlexUpdate += OnFlexUpdate;
            particles = new Vector4[actor.indexCount];
            velocities = new Vector3[particles.Length];
        }

        public void OnFlexUpdate(FlexContainer.ParticleData _particleData)
        {
            _particleData.GetParticles(actor.indices[0], actor.indexCount, particles);
            _particleData.GetVelocities(actor.indices[0], actor.indexCount, velocities);
            if (m_collision_detect.hitFlex)
            {
                StartCoroutine(avoid());
            }
            if (m_collision_detect.flex_distance > 5f)
            {
                print("moved away");
                for (int i = 0; i < velocities.Length; i++)
                {
                    velocities[i] += Vector3.back * particles[i].w * 0.5f;
                }
                _particleData.SetVelocities(actor.indices[0], actor.indexCount, velocities);
            }
            //_particleData.SetVelocities(actor.indices[0], actor.indexCount, velocities);
        }

        IEnumerator avoid()
        {
            for (int i = 0; i < velocities.Length; i++)
            {
                velocities[i] += Vector3.forward * particles[i].w * 0.1f;
            }
            
            yield return new WaitForSeconds(2);
        }

    }
}

