Shader "Unlit/Gourad"
{
     Properties {
        _Color ("Color", Color) = (1, 1, 1, 1) //The color of our object
        _Tex ("Pattern", 2D) = "white" {} //Optional texture

        _Shininess ("Shininess", Float) = 10 //Shininess
        _SpecColor ("Specular Color", Color) = (1, 1, 1, 1) //Specular highlights color
    }
    SubShader {
        Tags { "RenderType" = "Opaque" } //We're not rendering any transparent objects
        LOD 200 //Level of detail

        Pass {
            Tags { "LightMode" = "ForwardBase" } //For the first light

            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc" //Provides us with light data, camera information, etc

                uniform float4 _LightColor0; //From UnityCG

                sampler2D _Tex; //Used for texture
                float4 _Tex_ST; //For tiling

                uniform float4 _Color; //Use the above variables in here
                uniform float4 _SpecColor;
                uniform float _Shininess;

                // vertex shader inputs
                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                };

                // vertex shader outputs ("vertex to fragment")
                struct v2f
                {
                    float4 pos : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                    float4 posWorld : TEXCOORD1;
                };

                v2f vert(appdata v) //computes the color at every vertex in the vertex shader
                //the normals are  interpolated across the mesh  to determine the light.
                {
                    v2f o;

                    o.posWorld = mul(unity_ObjectToWorld, v.vertex); //Calculate the world position for our point
                    o.normal = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz); //Calculate the normal
                    o.pos = UnityObjectToClipPos(v.vertex); //And the position
                    o.uv = TRANSFORM_TEX(v.uv, _Tex);

                    float3 normalDirection = normalize(o.normal);
                    float3 viewDirection = normalize(_WorldSpaceCameraPos - o.posWorld.xyz);

                    return o;
                }

                fixed4 frag(v2f v)
                {
                   return v.pos;
                }
            ENDCG
        }
    }
}
