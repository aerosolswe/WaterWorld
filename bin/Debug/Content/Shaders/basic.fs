#version 330

in vec2 texCoord0;

uniform sampler2D diffuse;

out vec4 fragColor;

void main() 
{
	fragColor = texture2D(diffuse, texCoord0.xy);
}