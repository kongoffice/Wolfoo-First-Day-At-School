using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Common 
{
	/// <summary>
	/// Viet lai cac trang thai cua Panel load scene, khi co load scene xay ra
	/// </summary>
	public abstract class AnimLoadSceneBase : MonoBehaviour
	{
		/// <summary>
		/// Trang thai luc bat dau khoi tao
		/// </summary>
		public abstract void Default();

		public virtual void BeforeLoad(string sceneName, System.Action onComplete)
		{
			onComplete?.Invoke();
		}

		/// <summary>
		/// Bat dau load scene nao do
		/// </summary>
		public abstract void StartLoad(string sceneName);

		/// <summary>
		/// Ket thuc load scene
		/// </summary>
		public abstract void EndLoad(string sceneName, System.Action onComplete = null);
	}
}