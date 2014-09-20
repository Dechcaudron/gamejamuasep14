Shader "Vertex color" {

Properties {
    _Color ("Color", Color) = (1,1,1)
}

Category {
    Tags { "Queue"="Geometry" }
    Lighting Off
	
    BindChannels {
        Bind "Color", color
        Bind "Vertex", vertex
    }
   
	SubShader{
		Pass 
		{
			SetTexture[_]
			{
				ConstantColor [_Color]
				Combine constant Lerp(constant) primary
			}
		}
	}
	//Fallback "VertexLit"
}
}
