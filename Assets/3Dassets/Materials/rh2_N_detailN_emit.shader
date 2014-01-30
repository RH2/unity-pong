Shader "NormalMap"
{
	Properties 
	{
_Diffuse("_Diffuse", 2D) = "gray" {}
_Specular("_Specular", 2D) = "black" {}
_Emit("_Emit", 2D) = "black" {}
_Normal("_Normal", 2D) = "bump" {}
_DetailNormal("_DetailNormal", 2D) = "black" {}
_Normal_I("_Normal_I", Float) = 1
_DetailNormal_I("_DetailNormal_I", Float) = 0
_Diffuse_Tint("_Diffuse_Tint", Color) = (1,1,1,1)
_Specular_power("_Specular_power", Float) = 2
_Specular_multiply("_Specular_multiply", Float) = 2
_Emit_multiply("_Emit_multiply", Float) = 1

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 3.0


sampler2D _Diffuse;
sampler2D _Specular;
sampler2D _Emit;
sampler2D _Normal;
sampler2D _DetailNormal;
float _Normal_I;
float _DetailNormal_I;
float4 _Diffuse_Tint;
float _Specular_power;
float _Specular_multiply;
float _Emit_multiply;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}

			inline half4 LightingBlinnPhongEditor_DirLightmap (EditorSurfaceOutput s, fixed4 color, fixed4 scale, half3 viewDir, bool surfFuncWritesNormal, out half3 specColor)
			{
				UNITY_DIRBASIS
				half3 scalePerBasisVector;
				
				half3 lm = DirLightmapDiffuse (unity_DirBasis, color, scale, s.Normal, surfFuncWritesNormal, scalePerBasisVector);
				
				half3 lightDir = normalize (scalePerBasisVector.x * unity_DirBasis[0] + scalePerBasisVector.y * unity_DirBasis[1] + scalePerBasisVector.z * unity_DirBasis[2]);
				half3 h = normalize (lightDir + viewDir);
			
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular * 128.0);
				
				// specColor used outside in the forward path, compiled out in prepass
				specColor = lm * _SpecColor.rgb * s.Gloss * spec;
				
				// spec from the alpha component is used to calculate specular
				// in the Lighting*_Prepass function, it's not used in forward
				return half4(lm, spec);
			}
			
			struct Input {
				float2 uv_Diffuse;
float2 uv_Normal;
float2 uv_DetailNormal;
float2 uv_Emit;
float2 uv_Specular;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D4=tex2D(_Diffuse,(IN.uv_Diffuse.xyxy).xy);
float4 Multiply4=Tex2D4 * _Diffuse_Tint;
float4 Tex2D5=tex2D(_Normal,(IN.uv_Normal.xyxy).xy);
float4 UnpackNormal2=float4(UnpackNormal(Tex2D5).xyz, 1.0);
float4 Multiply1=UnpackNormal2 * _Normal_I.xxxx;
float4 Tex2D6=tex2D(_DetailNormal,(IN.uv_DetailNormal.xyxy).xy);
float4 UnpackNormal3=float4(UnpackNormal(Tex2D6).xyz, 1.0);
float4 Multiply2=UnpackNormal3 * _DetailNormal_I.xxxx;
float4 Add1=Multiply1 + Multiply2;
float4 Tex2D1=tex2D(_Emit,(IN.uv_Emit.xyxy).xy);
float4 Multiply5=Tex2D1 * _Emit_multiply.xxxx;
float4 Tex2D3=tex2D(_Specular,(IN.uv_Specular.xyxy).xy);
float4 Multiply3=Tex2D3 * _Specular_multiply.xxxx;
float4 Pow0=pow(Multiply3,_Specular_power.xxxx);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Multiply4;
o.Normal = Add1;
o.Emission = Multiply5;
o.Gloss = Pow0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}