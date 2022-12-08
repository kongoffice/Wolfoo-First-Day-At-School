using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SCN.Animation
{
    public static class AnimationSheetManager
    {
        /// <summary>
        /// Play animation on SpriteRenderer with FPS
        /// </summary>
        /// <param name="mono">Monobehaviour</param>
        /// <param name="onRun">the Event invoke at each frame</param>
        /// <param name="onComplete">the Event invoke when complete animation (no call if loop)</param>
        /// <param name="isUsingUnscaleTime"></param>
        /// <returns>the Coroutine for stop Animation</returns>
        public static Coroutine PlayAnimationFPS(SpriteRenderer spriteRenderer, IEnumerable<Sprite> listSpriteInput, float fps, bool isLoop
        , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false)
        {
            var listSprite = listSpriteInput.ToArray();

            var deltaTime = 1 / fps;
            return DoPlayAnimationFPS(spriteRenderer, listSprite, deltaTime, isLoop, mono, onRun, onComplete, isUsingUnscaleTime);
        }

        /// <summary>
        /// Play animation on SpriteRenderer in second
        /// </summary>
        /// <param name="mono">Monobehaviour</param>
        /// <param name="onRun">the Event invoke at each frame</param>
        /// <param name="onComplete">the Event invoke when complete animation (no call if loop)</param>
        /// <param name="isUsingUnscaleTime"></param>
        /// <returns>the Coroutine for stop Animation</returns>
        public static Coroutine PlayAnimationTime(SpriteRenderer spriteRenderer, IEnumerable<Sprite> listSpriteInput, float time, bool isLoop
        , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false)
        {
            var fps = listSpriteInput.Count() / time;
            return PlayAnimationFPS(spriteRenderer, listSpriteInput, fps, isLoop, mono, onRun, onComplete, isUsingUnscaleTime);
        }

        /// <summary>
        /// Play animation on Image with FPS
        /// </summary>
        /// <param name="mono">Monobehaviour</param>
        /// <param name="onRun">the Event invoke at each frame</param>
        /// <param name="onComplete">the Event invoke when complete animation (no call if loop)</param>
        /// <param name="isUsingUnscaleTime"></param>
        /// <returns>the Coroutine for stop Animation</returns>
        public static Coroutine PlayAnimationFPS(Image image, IEnumerable<Sprite> listSpriteInput, float fps, bool isLoop
        , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false)
        {
            var listSprite = listSpriteInput.ToArray();

            var deltaTime = 1 / fps;
            return DoPlayAnimationFPS(image, listSprite, deltaTime, isLoop, mono, onRun, onComplete, isUsingUnscaleTime);
        }

        /// <summary>
        /// Play animation on Image second
        /// </summary>
        /// <param name="mono">Monobehaviour</param>
        /// <param name="onRun">the Event invoke at each frame</param>
        /// <param name="onComplete">the Event invoke when complete animation (no call if loop)</param>
        /// <param name="isUsingUnscaleTime"></param>
        /// <returns>the Coroutine for stop Animation</returns>
        public static Coroutine PlayAnimationTime(Image image, IEnumerable<Sprite> listSpriteInput, float time, bool isLoop
            , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false)
        {
            var fps = listSpriteInput.Count() / time;
            return PlayAnimationFPS(image, listSpriteInput, fps, isLoop, mono, onRun, onComplete, isUsingUnscaleTime);
        }

        /// <summary>
        /// Stop animation
        /// </summary>
        /// <param name="mono">Monobehaviour call the animation</param>
        /// <param name="corou">Coroutine return from animation</param>
        public static void StopAnimation(MonoBehaviour mono, Coroutine corou)
        {
            if (corou != null)
                mono.StopCoroutine(corou);
        }

        #region private method
        static IEnumerator RepeatCall(float timeRate, System.Action action, bool isUsingUnscaleTime = false)
        {
            while (true)
            {
                action?.Invoke();
                yield return isUsingUnscaleTime ? (object)new WaitForSecondsRealtime(timeRate) : new WaitForSeconds(timeRate);
            }
        }

        static Coroutine DoPlayAnimationFPS(SpriteRenderer spriteRenderer, Sprite[] listSprite, float deltaTime, bool isLoop
        , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false, int count = 0)
        {
            Coroutine IE = null;

            IE = mono.StartCoroutine(RepeatCall(deltaTime, () =>
            {
                if (count == listSprite.Length)
                {
                    if (!isLoop)
                    {
                        mono.StopCoroutine(IE);
                        onComplete?.Invoke();
                        return;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                spriteRenderer.sprite = listSprite[count];
                count++;
                onRun?.Invoke(count);
            }, isUsingUnscaleTime));

            return IE;
        }

        static Coroutine DoPlayAnimationFPS(Image image, Sprite[] listSprite, float deltaTime, bool isLoop
        , MonoBehaviour mono, System.Action<int> onRun = null, System.Action onComplete = null, bool isUsingUnscaleTime = false, int count = 0)
        {
            Coroutine IE = null;

            IE = mono.StartCoroutine(RepeatCall(deltaTime, () =>
            {
                if (count == listSprite.Length)
                {
                    if (!isLoop)
                    {
                        mono.StopCoroutine(IE);
                        onComplete?.Invoke();
                        return;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                image.sprite = listSprite[count];
                count++;
                onRun?.Invoke(count);
            }, isUsingUnscaleTime));

            return IE;
        }
        #endregion
    }
}
