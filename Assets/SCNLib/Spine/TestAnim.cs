
using System.Collections;
using UnityEngine;

namespace SCN.Animation 
{
	[RequireComponent(typeof(AnimationSpineController))]
	public class TestAnim : MonoBehaviour
	{
		AnimationSpineController spineControl;
		[SerializeField] AnimationSpineController.SpineAnim anim;
		//[SerializeField] KeyCode key;		

		private void Start()
		{
			spineControl = GetComponent<AnimationSpineController>();
			spineControl.InitValue();
		}

		private void Update()
		{
			Jump();
		}

		void Jump()
        {
			if (Input.GetMouseButtonDown(0))
			{
				spineControl.PlayAnimation(anim, false);
				StartCoroutine(IEjumpWolfoo());
				
			}
		}
		
		IEnumerator IEjumpWolfoo()
        {
			yield return new WaitForSeconds(1f);
        }
	}
}