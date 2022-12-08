using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Common
{
    [CreateAssetMenu(fileName = "Load scene settings", menuName = "SCN/Scriptable Objects/LoadScene")]
    public class LoadSceneSettings : ScriptableObject
    {
        static LoadSceneSettings instance;
        public static LoadSceneSettings Instance
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
            instance = LoadSource.LoadObject<LoadSceneSettings>("Load scene settings");
        }

        [SerializeField] string layer;
        [SerializeField] int orderInLayer;

        [SerializeField] AnimLoadSceneBase loadAnim;

        public string Layer => layer;
        public int OrderInLayer => orderInLayer;
        public AnimLoadSceneBase LoadAnim => loadAnim;
    }
}