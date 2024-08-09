#include <GLFW/glfw3.h>
#include <iostream>

int main() {
    // Initialize GLFW
    glfwInit();

    // Specific the version of OpenGL
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

    // Create a window
    GLFWwindow* window = glfwCreateWindow(800, 600, "Hello OpenGL", NULL, NULL);
    if (!window) {
        std::cout << "Fail to create GLFW window\n";
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);

    unsigned i = 0;
    bool toggle = true;
    while (!glfwWindowShouldClose(window)) {
        // Change the background color every 1000 frames
        if (i%1000 == 0) toggle = !toggle;
        toggle ? glClearColor(0.1f, 0.5f, 0.5f, 1.0f) : glClearColor(0.1f, 0.1f, 0.1f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        // Swap the front and back buffers
        glfwSwapBuffers(window);
        glfwPollEvents();

        i += 1;
        i %= 100;
    }

    // Terminate GLFW
    glfwDestroyWindow(window);
    glfwTerminate();
    return 0;
}
