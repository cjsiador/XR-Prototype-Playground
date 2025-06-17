Shader "UI/StencilVisibleMask_XR_WorldSpace"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [IntRange]_StencilID ("Stencil ID", Range(0, 255)) = 1
    }
    SubShader
    {
        Tags { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "RenderPipeline"="UniversalPipeline" 
            "PreviewType"="Plane" 
            "CanUseSpriteAtlas"="True" 
        }

        Stencil
        {
            Ref [_StencilID]
            Comp NotEqual
            Pass Keep
        }

        Cull Back
        Lighting Off
        ZWrite On
        ZTest LEqual
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "Default"

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ XR_PASS
            #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;

            v2f vert(appdata_t v)
            {
                v2f o;

                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.color = v.color;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 texCol = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
                return texCol * i.color;
            }
            ENDHLSL
        }
    }
}
