#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform float mixValue;

uniform sampler2D Ourtexture1;//ÎÆÀí²ÉÑùÆ÷
uniform sampler2D Ourtexture2;

void main()
{
    FragColor = mix(texture(Ourtexture1,TexCoord),texture(Ourtexture2, TexCoord),mixValue);
}