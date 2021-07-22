using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

namespace NVIDIA.Flex
{
    public class GenerateOctree : MonoBehaviour
    {
        public GameObject MyContainer;

        PointOctree<GameObject> pointTree;

        PointOctree<Vector4> particleTree;

        public FlexActor m_Actor;

        private Vector4[] m_particles;

        private Vector3[] m_velocities;
        public void Awake() => m_Actor = GetComponent<FlexActor>();

        public bool firstRun = false;
        public void Start()
        {
            m_Actor.onFlexUpdate += OnFlexUpdate;
            pointTree = new PointOctree<GameObject>(15, MyContainer.transform.position, 1);
            m_particles = new Vector4[m_Actor.indexCount];
            m_velocities = new Vector3[m_particles.Length];
        }

        void OnFlexUpdate(FlexContainer.ParticleData _particleData)
        {
            if (firstRun)
            {
                _particleData.GetParticles(m_Actor.indices[0], m_Actor.indexCount, m_particles);
                _particleData.GetVelocities(m_Actor.indices[0], m_Actor.indexCount, m_velocities);
                particleTree = new PointOctree<Vector4>(15, MyContainer.transform.position, 0.1f);
                foreach (var i in m_particles)
                {
                    particleTree.Add(i, new Vector3(i.x, i.y, i.z));
                }
                
                firstRun = false;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDrawGizmos()
        {

            pointTree.DrawAllBounds(); // Draw node boundaries
            pointTree.DrawAllObjects(); // Mark object positions

            particleTree.DrawAllBounds();
        }
    }
}

