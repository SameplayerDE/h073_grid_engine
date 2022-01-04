#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;
matrix World;
matrix View;
matrix Projection;
float4 Color = float4(1, 1, 1, 1);
float2 Tiling = float2(1, 1);
float2 Offset = float2(0, 0);
bool useTexture = true;
bool FlipX = false;
bool FlipY = false;

Texture2D Texture : register(t0);
sampler TextureSampler : register(s0)
{
	Texture = (Texture);
	MinFilter = Point; // Minification Filter
	MagFilter = Point; // Magnification Filter
	MipFilter = Point; // Mip-mapping
	AddressU = Wrap; // Address Mode for U Coordinates
	AddressV = Wrap; // Address Mode for V Coordinates
};

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float2 TextureUVs : TEXCOORD0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float2 TextureUVs : TEXCOORD0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;
    
    output.Position = mul(input.Position, WorldViewProjection);
    output.TextureUVs = input.TextureUVs;

	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
	if (useTexture) {

        float U = input.TextureUVs.x;
        float V = input.TextureUVs.y;

        if (FlipX && !FlipY) {
            return tex2D(TextureSampler, float2(1 - U, V) * Tiling) * Color;
        }
        if (FlipY && !FlipX) {
            return tex2D(TextureSampler, float2(U, 1 - V) * Tiling) * Color;
        }
        if (FlipX && FlipY) {
            return tex2D(TextureSampler, float2(1 - U, 1 - V) * Tiling) * Color;
        }
        return tex2D(TextureSampler, float2(U, V) * Tiling) * Color;
    }
    else {
        return Color;
    }
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};