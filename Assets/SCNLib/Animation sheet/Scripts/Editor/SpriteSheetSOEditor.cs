using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SCN.Animation
{
    [CustomEditor(typeof(SpriteSheetSO))]
    public class SpriteSheetSOEditor : Editor
    {
        Texture spRend;
        SpriteSheetSO mytarget;

        public void OnEnable()
        {
            mytarget = (SpriteSheetSO)target;

            if(mytarget.ListSprites == null) mytarget.ListSprites = new Sprite[0];
        }

        public override void OnInspectorGUI()
        {
            if (mytarget.ListSprites.Length == 0)
            {
                spRend = (Texture)EditorGUILayout.ObjectField("Sheet", spRend, typeof(Texture), false);
                if (GUILayout.Button("Create sheet"))
                {
                    if (spRend != null)
                    {
                        var st = AssetDatabase.GetAssetPath(spRend);
                        var listObjs = AssetDatabase.LoadAllAssetsAtPath(st);

                        if (listObjs.Length > 0)
                        {
                            var list = new List<Sprite>();
                            for (int i = 0; i < listObjs.Length; i++)
                            {
                                if (listObjs[i] is Sprite sprite) list.Add(sprite);
                            }

                            mytarget.ListSprites = list.ToArray();
                        }
                    }

                    EditorUtility.SetDirty(mytarget); 
                    AssetDatabase.SaveAssets();
                }
            }
			else
			{
                base.OnInspectorGUI();
            }
        }
    }
}