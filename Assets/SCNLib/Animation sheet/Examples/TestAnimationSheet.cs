using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SCN.Animation
{
    public class TestAnimationSheet : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] SpriteRenderer spriteRend;

        [SerializeField] SpriteSheetSO textureSheet;

		Coroutine imageCorou;
		Coroutine spriteRendCorou;

		private void Start()
		{
			// Play animation on Image (UI) with FPS 25
			imageCorou = AnimationSheetManager.PlayAnimationFPS(image, textureSheet.ListSprites, 25, true, this, 
				frame => 
				{
					Debug.Log("frame: " + frame);
				}, ()=> 
				{
					Debug.Log("On done");
				});

			// Play animation on Image (UI) in 1s per loop
			//imageCorou = AnimationSheetManager.PlayAnimationTime(image, textureSheet.listSprites, 1, true, this);

			// ====================

			// Play animation on SpriteRenderer with FPS 25
			spriteRendCorou = AnimationSheetManager.PlayAnimationFPS(spriteRend, textureSheet.ListSprites, 25, true, this);

			// Play animation on SpriteRenderer in 1s per loop
			//spriteRendCorou = AnimationSheetManager.PlayAnimationTime(spriteRend, textureSheet.listSprites, 1, true, this);
		}

		private void Update()
		{
			// Press Space button to stop animation
			if (Input.GetKeyDown(KeyCode.Space))
			{
				AnimationSheetManager.StopAnimation(this, imageCorou);
				AnimationSheetManager.StopAnimation(this, spriteRendCorou);
			}
		}
	}
}