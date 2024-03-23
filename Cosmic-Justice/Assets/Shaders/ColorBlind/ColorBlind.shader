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
            float4 _replacingColors[9];
            float4 _colors[9];
            const float EPSILON = 0.00001;

            bool isLess(float a, float b) {
                return abs(a - b) < EPSILON;
            }

            float getDistance(float4 a, float4 b){ // returns distance
                return sqrt( pow((b.x - a.x),2.0) + pow((b.y - a.y),2.0) + pow((b.z - a.z),2.0) );
            } // getDistance

            int getColor(float4 col){ // categorizes into one of the color categories
                float distances[9];
                int smallestDistIndex = 0;

                [unroll]
                for (int i = 0; i < 9; i++) {
                    distances[i] = distance(col, _colors[i]);
                    if (isLess(distances[i], distances[smallestDistIndex])) { // if smaller than the smallest
                        smallestDistIndex = i;
                    }
                }

                return smallestDistIndex;
            } // getColor

            fixed4 frag (v2f i) : SV_Target // applied to all pixels -- WORKS LIKE THIS NOW 3/22/2024: no fxns lol
            {
                float4 col = tex2D(_MainTex, i.uv);
    
                float distances[9];
                int smallestDistIndex = 0;

                [unroll]
                for (int i = 0; i < 9; i++) // compare pixel to each color & get index of color category
                {
                    distances[i] = sqrt(pow((_colors[i].r - col.r), 2.0) + pow((_colors[i].g - col.g), 2.0) + pow((_colors[i].b - col.b), 2.0));
                    //if (isLess(distances[i], distances[smallestDistIndex]))
                    if (distances[i] - distances[smallestDistIndex] < EPSILON)
                    { // if smaller than the smallest
                        smallestDistIndex = i;
                    }
                }

                // change it to the color chosen to change for that category
                
                //return clamp(col * _replacingColors[getColor(col)], 0.0, 1.0);
                //return col * _replacingColors[getColor(col)];
                //return _colors[0];

                //return col * _replacingColors[smallestDistIndex];
                return _replacingColors[smallestDistIndex];
            }
            ENDCG
        }
    }
}
