using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Animation
{
	[CreateAssetMenu(fileName = "Sprite sheet", menuName = "SCN/Scriptable Objects/Sprite sheet")]
	public class SpriteSheetSO : ScriptableObject
	{
		[SerializeField] Sprite[] listSprites;

		public Sprite[] ListSprites
		{
			get => listSprites;
			set => listSprites = value;
		}

		public Sprite[] ReverseList
		{
			get
			{
				var tempList = new Sprite[listSprites.Length];
				for (int i = 0; i < tempList.Length; i++)
				{
					tempList[i] = listSprites[tempList.Length - i - 1];
				}

				return tempList;
			}
		}
	}
}