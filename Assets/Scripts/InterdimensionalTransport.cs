using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalTransport : MonoBehaviour 
{

	public Material[] materials;

	void Start () 
	{
		foreach (var mat in materials) 
		{
			mat.SetInt ("_StencilTest",(int)CompareFunction.Equal);
		}

	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.name != "Main Camera")
			return;

		//Outside of the other world
		if (transform.position.z > other.transform.position.z) 
		{

			Debug.Log ("Outside of the other world");
			foreach (var mat in materials) 
			{
				mat.SetInt ("_StencilTest",(int)CompareFunction.Equal);
			}

		//Inside other world
		} else 
		{
			Debug.Log ("Inside other world");
			foreach (var mat in materials) 
			{
				mat.SetInt ("_StencilTest", (int)CompareFunction.NotEqual);
			}
		}
	}

	void OnDestroy()
	{
		foreach (var mat in materials) 
		{
			mat.SetInt ("_StencilTest", (int)CompareFunction.NotEqual);
		}
	}


	void Update () 
	{
		
	}
}
