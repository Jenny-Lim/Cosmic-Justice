Shader "Hidden/ColorBlind"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#pragma enable_d3d11_debug_symbols

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            // colors player can change
            static const float4 _red = (1, 0, 0, 1); // 0
            static const float4 _green = (0, 0, 1, 1); // 1
            static const float4 _blue = (0, 1, 0, 1); // 2
            static const float4 _yellow = (1, 1, 0, 1); // 3
            static const float4 _orange = (1, 0.65, 0, 1); // 4
            static const float4 _purple = (0.63, 0.13, 0.94, 1); // 5
            static const float4 _cyan = (0, 1, 1, 1); // 6

            /*float4 _replacingRed;
            float4 _replacingGreen;
            float4 _replacingBlue;
            float4 _replacingYellow;
            float4 _replacingOrange;
            float4 _replacingPurple;
            float4 _replacingCyan;*/

            static float4 _colors[7] = {_red, _green, _blue, _yellow, _orange, _purple, _cyan};
            float4 _replacingColors[7];
            //static float4 _replacingColors[7] = { _replacingRed, _replacingGreen, _replacingBlue, _replacingYellow, _replacingOrange, _replacingPurple, _replacingCyan };

            const float EPSILON = 0.00001;
            bool isLess(float a, float b) {
                return abs(a - b) < EPSILON;
            }

            float getDistance(float4 a, float4 b){ // returns distance
                return sqrt( pow((b.x - a.x),2.0) + pow((b.y - a.y),2.0) + pow((b.z - a.z),2.0) );
            } // getDistance

            int getColor(float4 col){ // categorizes into one of the color categories
                float distances[7];
                int smallestDistIndex = 0;

                for (int i = 0; i < 7; i++) {
                    distances[i] = getDistance(_colors[i], col);
                    if (isLess(distances[i], distances[smallestDistIndex])) { // if smaller than the smallest
                        smallestDistIndex = i;
                    }
                }
                return smallestDistIndex;
            } // getColor

            fixed4 frag (v2f i) : SV_Target // applied to all pixels
            {
                float4 col = tex2D(_MainTex, i.uv);

                // compare pixel to each color & get index of color category
                // change it to the color chosen to change for that category
                return clamp(col * _replacingColors[getColor(col)], 0.0, 1.0);
                //return col * float4(1,1,1,1);
            }
            ENDCG
        }
    }
}
