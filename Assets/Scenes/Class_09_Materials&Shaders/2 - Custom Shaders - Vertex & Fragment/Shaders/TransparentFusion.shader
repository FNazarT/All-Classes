Shader "Custom/Transparent Fusion"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _PrimaryTex ("Primary Texture", 2D) = "white" {}
        _SecondaryTex ("Secondary Texture", 2D) = "white" {}
        _TextInfluence("Texture Influence", Range(0, 1)) = 1
    }
    SubShader
        {
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Fade" }
            LOD 200

            // Disabled culled side
            Cull Off

            // Dont subscribe to depth buffer 
            ZWrite Off

            // Blend (Source (*SrcAlpha),   Destination(*(1-SrcAlpha)))
            Blend SrcAlpha OneMinusSrcAlpha

            Pass{
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 2.0

                #include "UnityCG.cginc"

                fixed4 _Color;
                sampler2D _PrimaryTex;
                float4 _PrimaryTex_ST;
                sampler2D _SecondaryTex;
                float4 _SecondaryTex_ST;
                float _TextInfluence;

                 struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv1 : TEXCOORD0;
                    float2 uv2 : TEXCOORD0;
                };

                v2f vert(appdata_base v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv1 = TRANSFORM_TEX(v.texcoord, _PrimaryTex);
                    o.uv2 = TRANSFORM_TEX(v.texcoord, _SecondaryTex);
                    return o;
                }

                fixed4 frag(v2f i) : COLOR
                {
                    fixed4 col = _Color;
                    fixed4 primaryTex = tex2D(_PrimaryTex, i.uv1);
                    fixed4 secondaryTex = tex2D(_SecondaryTex, i.uv2);
                    fixed4 finalTex = lerp(primaryTex, secondaryTex, _TextInfluence);
                    finalTex.rgb *= col.rgb;
                    return finalTex;
                }
                ENDCG
            }
        }
}
