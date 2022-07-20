// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "To7/Leaf"
{
	Properties
	{
		_BaseMap("BaseMap", 2D) = "white" {}
		_BaseColor("Base Color", Color) = (1,1,1,0)
		_EmissionMap("Emission Map", 2D) = "white" {}
		_EmissionColor("Emission Color", Color) = (0,0,0,0)
		_BumpTex("BumpTex", 2D) = "bump" {}
		_BumpStrength("Bump Strength", Float) = 1
		_Metallic("Metallic", Float) = 0
		_Smoothness("Smoothness", Float) = 0.5
		_Occlusion("Occlusion", 2D) = "white" {}
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[Enum(UnityEngine.Rendering.CullMode)]_CullMode("Cull Mode", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull [_CullMode]
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _CullMode;
		uniform sampler2D _BumpTex;
		uniform float4 _BumpTex_ST;
		uniform float _BumpStrength;
		uniform float4 _BaseColor;
		uniform sampler2D _BaseMap;
		uniform float4 _BaseMap_ST;
		uniform float4 _EmissionColor;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionMap_ST;
		uniform float _Metallic;
		uniform float _Smoothness;
		uniform sampler2D _Occlusion;
		uniform float4 _Occlusion_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_BumpTex = i.uv_texcoord * _BumpTex_ST.xy + _BumpTex_ST.zw;
			o.Normal = UnpackScaleNormal( tex2D( _BumpTex, uv_BumpTex ), _BumpStrength );
			float2 uv_BaseMap = i.uv_texcoord * _BaseMap_ST.xy + _BaseMap_ST.zw;
			float4 tex2DNode1 = tex2D( _BaseMap, uv_BaseMap );
			o.Albedo = ( _BaseColor * tex2DNode1 ).rgb;
			float2 uv_EmissionMap = i.uv_texcoord * _EmissionMap_ST.xy + _EmissionMap_ST.zw;
			o.Emission = ( _EmissionColor * tex2D( _EmissionMap, uv_EmissionMap ) ).rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			float2 uv_Occlusion = i.uv_texcoord * _Occlusion_ST.xy + _Occlusion_ST.zw;
			o.Occlusion = tex2D( _Occlusion, uv_Occlusion ).r;
			o.Alpha = 1;
			clip( tex2DNode1.a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
0;73.6;813.4;719;734.252;-60.65436;1.429859;True;False
Node;AmplifyShaderEditor.ColorNode;6;-497.4313,-280.6016;Inherit;False;Property;_BaseColor;Base Color;1;0;Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;8;-496.5621,85.21784;Inherit;False;Property;_EmissionColor;Emission Color;3;0;Create;True;0;0;0;False;0;False;0,0,0,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-583.379,-100.6605;Inherit;True;Property;_BaseMap;BaseMap;0;0;Create;True;0;0;0;False;0;False;-1;bb15d4f9f5fbbe74d99187a733224c66;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;10;-582.2777,263.2775;Inherit;True;Property;_EmissionMap;Emission Map;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;5;-783.0419,973.1509;Inherit;False;Property;_BumpStrength;Bump Strength;5;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-162.3623,-45.12321;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-238.8174,237.1075;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;12;-479.7203,473.7718;Inherit;False;Property;_Metallic;Metallic;6;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-484.6201,543.972;Inherit;False;Property;_Smoothness;Smoothness;7;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-549.4698,925.8154;Inherit;True;Property;_BumpTex;BumpTex;4;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;15;-528.016,642.6832;Inherit;True;Property;_Occlusion;Occlusion;8;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;16;-31.18056,647.1683;Inherit;False;Property;_CullMode;Cull Mode;10;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.CullMode;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;26.325,29.09606;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;To7/Leaf;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;9;-1;-1;-1;0;False;0;0;True;16;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;7;0;6;0
WireConnection;7;1;1;0
WireConnection;11;0;8;0
WireConnection;11;1;10;0
WireConnection;4;5;5;0
WireConnection;0;0;7;0
WireConnection;0;1;4;0
WireConnection;0;2;11;0
WireConnection;0;3;12;0
WireConnection;0;4;13;0
WireConnection;0;5;15;0
WireConnection;0;9;1;4
WireConnection;0;10;1;4
ASEEND*/
//CHKSM=53AD407ABF720ED9394C1A8E07254C32FD79B481