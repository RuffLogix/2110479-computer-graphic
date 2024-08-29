#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform sampler2D texture1;
uniform vec2 iResolution;
uniform float iTime;
uniform float rotationAngle; // Rotation angle in radians

void main()
{
    // Mirror the image along the y-axis by flipping the texture coordinates
    vec2 mirroredTexCoord = vec2(-TexCoord.x + 1.0, TexCoord.y);

    // Get the color from the mirrored texture
    vec4 texColor = texture(texture1, mirroredTexCoord);

    // Normalize coordinates to [0,1] range
    vec2 uv = TexCoord;

    // Rotation matrix for 90 degrees
    mat2 rotationMatrix = mat2(
        0.0, -1.0,
        1.0,  0.0
    );

    // Center of the texture (0.5, 0.5)
    vec2 center = vec2(0.5, 0.5);

    // Translate coordinates to origin (0, 0), apply rotation, then translate back
    vec2 centeredUV = uv - center;
    vec2 rotatedUV = rotationMatrix * centeredUV;
    vec2 finalUV = rotatedUV + center;

    // Set the height ratio of each stripe (5 stripes)
    float stripeHeight = 1.0 / 5.0;

    // Colors for the flag
    vec3 blue = vec3(0.0, 0.33, 0.64);  // Blue
    vec3 white = vec3(1.0, 1.0, 1.0);   // White
    vec3 red = vec3(0.85, 0.09, 0.11);  // Red

    // Create a time-based wave effect for the flag
    float time = iTime * 2.0;
    float wave = sin(finalUV.x * 10.0 + time) * 0.05; // Adjust amplitude and frequency

    // Apply the waving effect to the x-coordinate of the UVs
    finalUV.y += wave;

    // Determine which stripe the current fragment is in
    vec3 color;
    if (finalUV.y < stripeHeight) {
        color = blue;
    }
    else if (finalUV.y < 2.0 * stripeHeight) {
        color = white;
    }
    else if (finalUV.y < 3.0 * stripeHeight) {
        color = red;
    }
    else if (finalUV.y < 4.0 * stripeHeight) {
        color = white;
    }
    else {
        color = blue;
    }

    // Combine the flag color with the mirrored texture color
    vec4 flagColor = vec4(color, 1.0);
    vec4 finalColor = mix(flagColor, texColor, 0.5); // Adjust mix factor as needed

    // Output the final color
    FragColor = finalColor;
}
