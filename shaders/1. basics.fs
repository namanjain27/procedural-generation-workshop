void mainImage(out vec4 fragColor, in vec2 fragCoord)
{
    // Lies between 0 and 1
    vec2 uv = fragCoord / iResolution.xy;
    // Between -1 to 1
    uv= uv * 2.0f - 1.0f;
    // Between 0 to 1
    uv = abs(uv);
    // Outpur Color
    vec3 col = vec3(uv.x, uv.y, (sin(iTime)+1.0f)/2.0f);
    // Output to screen
    fragColor = vec4(col, 1.0);
}
