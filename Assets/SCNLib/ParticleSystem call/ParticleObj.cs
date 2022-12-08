using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleObj : MonoBehaviour
{
	public System.Action OnStop;

	ParticleSystem par;
	public ParticleSystem Par
	{
		get
		{
			if (par == null)
			{
				par = GetComponent<ParticleSystem>();

				var main = Par.main;
				main.stopAction = ParticleSystemStopAction.Callback;
			}

			return par;
		}
	}

	void OnParticleSystemStopped()
	{
		OnStop?.Invoke();
	}
}
