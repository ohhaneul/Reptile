Shader "Custom/TransparentIgnoreBlack"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
            struct v2f { float2 uv : TEXCOORD0; float4 vertex : SV_POSITION; };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

            // 검정색이면 투명하게
            if (col.r < 0.1 && col.g < 0.1 && col.b < 0.1)
            {
                col.a = 0;
            }
            else
            {
                col.a = 1;
            }

            return col;
        }
        ENDCG
    }
    }
}
