//----------------------------------------------------
// VORONOI_NOISE_GENERATOR
//----------------------------------------------------
#define GRID_HEIGHT 10

float rand(vec2 pos)
{
    return fract(sin(dot(pos, vec2(12.9898f, 78.233f))) * 43758.5453f);
}

float get_voronoi_noise(vec2 pos)
{
    float dist=2.0f;
    for(int y=-1;y<=1;y++)
    {
        for(int x=-1;x<=1;x++)
        {
            vec2 gridP = vec2(floor(pos.x+float(x)),floor(pos.y+float(y)));
            vec2 rP = gridP+vec2(rand(gridP),rand(gridP.yx));
            vec2 offset=vec2(sin(iTime*6.0f*rand(gridP)),cos(iTime*9.0f*rand(gridP.yx)))*0.1f;
            float dis=distance(pos,rP+offset);
            if(dis<dist)
            {
                dist=dis;
            }
        }
    }
    return dist/sqrt(2.0f);
}
//----------------------------------------------------
//----------------------------------------------------


vec3 get_color(vec2 pos)
{
    float h = get_voronoi_noise(pos);
    return vec3(h);
}

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    // Gets UVs
    vec2 uv = fragCoord/iResolution.y;
    uv*=float(GRID_HEIGHT);
    
    // Gets final Col
    vec3 col = get_color(uv);

    // Output to screen
    fragColor = vec4(col,1.0);
}
