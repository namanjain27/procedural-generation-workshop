#define TO_CLAMP 1
#define TO_OFFSET 1

float scale=25.0f;


// Generates a random noise between 0.0 and 1.0
float rand(vec2 pos)
{
    return fract(sin(dot(pos, vec2(12.9898f, 78.233f))) * 43758.5453f);
}

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    // Grt UV Position
    vec2 uv = fragCoord / iResolution.xy;
    uv *= scale;
    uv.x *= iResolution.x / iResolution.y;
    
    // Change position by some offset
    vec2 offset = vec2(0.0f);
#if TO_OFFSET
    offset.x += iTime * 5.0f;
    offset.y = sin(iTime * 3.0f) * 4.0f;
#endif

    // Clamp point to closest int to get distinct values
#if TO_CLAMP
     float h = rand(floor(uv + offset));
#else
     float h = rand(uv + offset);
#endif
   
    // Output Color
    vec3 col = vec3(h);
    
    // Output to screen
    fragColor = vec4(col, 1.0);
}
