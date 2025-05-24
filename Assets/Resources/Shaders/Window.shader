Shader "Custom/Window"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PortalTex ("Portal Texture", 2D) = "white" {}
        _DistortionStrength ("Distortion Strength", Range(0, 0.1)) = 0.01
        _DistortionSpeed ("Distortion Speed", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
                float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            sampler2D _PortalTex;
            float4 _MainTex_ST;
            float _DistortionStrength;
            float _DistortionSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.screenPos = ComputeScreenPos(o.vertex);
                o.viewDir = normalize(ObjSpaceViewDir(v.vertex));
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Искажение для эффекта портала
                float2 distortion = float2(
                    sin(_Time.y * _DistortionSpeed + i.uv.x * 10) * _DistortionStrength,
                    cos(_Time.y * _DistortionSpeed + i.uv.y * 10) * _DistortionStrength
                );
                
                // Координаты для проекции
                float2 portalUV = i.screenPos.xy / i.screenPos.w;
                portalUV += distortion;
                
                // Отражение нормали для более интересного эффекта
                float3 reflectDir = reflect(-i.viewDir, i.normal);
                float fresnel = pow(1.0 - saturate(dot(i.viewDir, i.normal)), 2);
                
                // Смешивание текстуры портала с эффектом отражения
                fixed4 portalCol = tex2D(_PortalTex, portalUV);
                fixed4 col = portalCol * (1 - fresnel) + fresnel * 0.5;
                
                return col;
            }
            ENDCG
        }
    }
}