using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Audio
{
	[CreateAssetMenu(fileName = "Audio setting", menuName = "SCN/Scriptable Objects/Audio setting")]
	public class AudioSetting : ScriptableObject
	{
		[SerializeField] bool isStopSoundOnLoadScene = true;
		[SerializeField] bool isStopMusicOnLoadScene = true;

		public bool IsStopSoundOnLoadScene => isStopSoundOnLoadScene;
		public bool IsStopMusicOnLoadScene => isStopMusicOnLoadScene;
	}
}