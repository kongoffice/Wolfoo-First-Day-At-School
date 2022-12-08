using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SCN.Common
{
	public class DDOL : MonoBehaviour
	{
		/// <summary>
		/// bool: pause
		/// </summary>
		public System.Action<bool> OnApplicationPauseE;
		public System.Action OnApplicationQuitE;
		public System.Action OnUpdateE;

		[SerializeField] UnityEvent OnSetup;

		static DDOL _instance;
		public static DDOL Instance
		{
			get
			{
				Setup();
				return _instance;
			}
		}

		public static void Setup()
		{
			if (_instance != null)
			{
				return;
			}

			_instance = Instantiate(LoadSource.LoadObject<GameObject>("DDOL")).GetComponent<DDOL>();
			DontDestroyOnLoad(_instance.gameObject);

			_instance.OnSetup?.Invoke();
		}

		private void OnApplicationPause(bool pause)
		{
			OnApplicationPauseE?.Invoke(pause);
		}

		private void OnApplicationQuit()
		{
			OnApplicationQuitE?.Invoke();
		}

		private void Update()
		{
			OnUpdateE?.Invoke();
		}
	}
}