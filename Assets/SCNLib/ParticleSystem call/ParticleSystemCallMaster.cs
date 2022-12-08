using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Effect
{
    [CreateAssetMenu(fileName = "ParticleSystem Settings", menuName = "SCN/Scriptable Objects/ParticleSystem Settings")]
    public class ParticleSystemCallMaster : ScriptableObject
    {
        static ParticleSystemCallMaster instance;
        public static ParticleSystemCallMaster Instance
        {
            get
            {
                if (instance == null) Setup();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        static void Setup()
        {
            instance = LoadSource.LoadObject<ParticleSystemCallMaster>("ParticleSystem Settings");
            instance.trans = new GameObject("Particle trans").transform;
            instance.trans.SetParent(DDOL.Instance.transform);

            for (int i = 0; i < instance.parsP.Length; i++)
            {
                instance.parsP[i].pool = new ObjectPool(instance.parsP[i].prefab.gameObject, instance.trans);
            }
        }

        [SerializeField] ParticlePrefab[] parsP;
        Transform trans;

        public ParInfor PlayParticle(Transform parent, string particleName)
        {
            var par = System.Array.Find(parsP, p => p.prefab.name == particleName);
            return par.Play(parent);
        }

        public ParInfor PlayParticle(Transform parent, string particleName, Vector2 anchor, Vector2 pos)
        {
            var par = System.Array.Find(parsP, p => p.prefab.name == particleName);
            return par.Play(parent, anchor, pos);
        }

        public void StopParticle(ParInfor par)
        {
            var _parP = System.Array.Find(parsP, p => p.prefab.name == par.parName);
            if (_parP != null) _parP.Stop(par);
        }

        [System.Serializable]
        public class ParticlePrefab
        {
            public ParticleObj prefab;

            [HideInInspector] public ObjectPool pool;

            public ParInfor Play(Transform parent)
            {
                var par = PlayBase(parent);
                return par;
            }

            public ParInfor Play(Transform parent, Vector2 anchor, Vector2 pos)
            {
                var par = PlayBase(parent);
                var rect = par.particleObj.GetComponent<RectTransform>();

                rect.anchorMin = rect.anchorMax = anchor;
                rect.anchoredPosition = pos;

                return par;
            }

            ParInfor PlayBase(Transform parent)
            {
                var particleObj = pool.GetObjInPool().GetComponent<ParticleObj>();
                var par = new ParInfor
                {
                    particleObj = particleObj,
                    able = true,
                    parName = prefab.name
                };

                particleObj.gameObject.SetActive(true);
                particleObj.transform.SetParent(parent);

                particleObj.transform.localPosition = Vector2.zero;
                particleObj.transform.localScale = Vector2.one;

                _ = DDOL.Instance.StartCoroutine(DelayCallMaster.WaitForEndOfFrame(() =>
                {
                    particleObj.Par.Play();
                    particleObj.OnStop = () =>
                    {
                        Remove(par);
                    };
                }));

                return par;
            }

            /// <summary>
            /// Stop particle, 
            /// </summary>
            public void Stop(ParInfor parInfor)
            {
                if (parInfor.particleObj == null || !parInfor.able) return;

                parInfor.particleObj.Par.Stop();
            }

            /// <summary>
            /// Dua object ve Pool
            /// </summary>
            void Remove(ParInfor parInfor)
            {
                if (parInfor.particleObj == null || !parInfor.able) return;

                parInfor.able = false;
                parInfor.particleObj.gameObject.SetActive(false);
                pool.RemoveObj(parInfor.particleObj.gameObject);
            }
        }

        [System.Serializable]
        public class ParInfor
        {
            public string parName;
            public ParticleObj particleObj;
            public bool able;
        }
    }
}