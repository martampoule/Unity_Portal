/*
 *Most basic shader for only rendereing objects depending on the stencil buffer
 *And the state of the global _StencilTest property
 */


Shader "Custom/StencilFilter"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6

	}
	SubShader
	{	

		Color [_Color]
		Stencil{
			Ref 1
			Comp [_StencilTest]
		}

		Pass
		{
		}
	}
}
