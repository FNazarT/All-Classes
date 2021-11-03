Shader "Custom/Color MPB"
{
    Properties
    {
        // [PerRendererData]: Texture value for this property will be queried from renderer's MaterialPropertyBlock, instead of from the material
        [PerRendererData] _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"Queue" = "Geometry" "RenderType" = "Opaque"}
        LOD 200

        ZWrite On

        Pass {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                fixed4 _Color;
                sampler2D _MainTex;
                float4 _MainTex_ST;

                v2f vert(appdata_base v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : COLOR
                {
                    fixed4 col = _Color;
                    fixed4 tex = tex2D(_MainTex, i.uv);
                    tex.rgb *= col.rgb;
                    return tex;
                }
            ENDCG
        }
    }
}
