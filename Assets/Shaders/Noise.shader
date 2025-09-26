Shader "CustomRenderTexture/Noise"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Sprite Texture", 2D) = "white" {}
     }

     SubShader
     {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" "CanUseSpriteAtlas"="True" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off
		
        Pass
        {
            Name "Noise"

            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
			
			struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }
			
            //float4 frag(v2f_customrendertexture IN) : SV_Target
            float4 frag(v2f IN) : SV_Target
            {
				
               // float2 uv = IN.localTexcoord.xy;
                float2 uv = IN.uv;
                float4 color = tex2D(_MainTex, uv) * _Color;

				// Randomize seed based on pixel position
				float2 seed = uv * _Time.y;
				
				// Generate random value
				float random = frac(sin(dot(seed.xy, float2(12.9898, 78.233))) * 43758.5453);
				
				// Quantize into levels to create banding    
			   random = floor(random * 8.0) / 8.0;
			   
			   // Apply static effect 
			   return float4(random, random, random, color.a);
			   
            }
            ENDCG
        }
    }
}
