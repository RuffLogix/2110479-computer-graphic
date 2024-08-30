#version 330 core

layout (location = 0) in vec3 aPos;   // Vertex position
layout (location = 1) in vec2 aTexCoord; // Texture coordinates

out vec2 TexCoord;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform float iTime; // Pass the time uniform

void main()
{
    // Cube vertex positions
    vec3 cubePosition = aPos;

    // Pyramid vertex positions (pyramid with base at y = -0.5 and apex at y = 0.5)
    vec3 pyramidPosition;

    // Define the pyramid positions based on the cube's layout
    if (aPos.y == -0.5) {
        // Base of the pyramid stays the same as the bottom face of the cube
        pyramidPosition = aPos;
    } else {
        // Top of the cube is morphed to the apex of the pyramid (0.0, 0.5, 0.0)
        pyramidPosition = vec3(0.0, 0.5, 0.0);
    }

    // Morphing factor: ranges from 0 to 1 over time
    float morphFactor = sin(iTime) * 0.5 + 0.5;

    // Interpolate between the cube and pyramid positions
    vec3 morphedPosition = mix(cubePosition, pyramidPosition, morphFactor);

    // Standard transformations
    gl_Position = projection * view * model * vec4(morphedPosition, 1.0);

    TexCoord = aTexCoord;
}
