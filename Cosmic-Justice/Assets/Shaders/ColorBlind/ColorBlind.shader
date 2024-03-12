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

            float4 _color;
            float4 _colorToChange; // check to see if this is more blue, green, or red, get which one

            //double getDistance(float4 a, float4 b){
                //return sqrt( pow((b.r - a.r),2), pow((b.g - a.g),2), pow((b.b - a.b),2), );
            //} // getDistance

            int getColor(float4 col){
                int color = 0; // white

                if(col.r > col.g && col.r > col.b){
                color = 1; //red
                }
                else if(col.g > col.r && col.g > col.b){
                color = 2; //green
                }
                else if(col.b > col.g && col.b > col.r){
                color = 3; //blue
                }
                return color;
            } // getColor

            fixed4 frag (v2f i) : SV_Target // applied to all pixels
            {
                float4 col = tex2D(_MainTex, i.uv);
                switch(getColor(_colorToChange)){
                    case(1): //red
                        if(col.r > col.g && col.r > col.b){
                            return col * _color;
                        }
                    break;
                    case(2): //green
                        if(col.g > col.r && col.g > col.b){
                            return col * _color;
                        }
                    break;
                    case(3): //blue
                        if(col.b > col.g && col.b > col.r){ // if color is more blue than any other coior
                            return col * _color;
                        }
                    break;
                }
                return col * fixed4(1,1,1,1);
            }
            ENDCG
        }
    }
}
