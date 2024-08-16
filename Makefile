BREW_PREFIX=/opt/homebrew
LIB_DIR=/usr/local/include

build:
	clang++ -o main main.cpp $(LIB_DIR)/glad/glad.c -I$(BREW_PREFIX)/include -L$(LIB_DIR) -L$(BREW_PREFIX)/lib -lglfw -framework OpenGL

run:
	./main

all:
	clang++ -o main main.cpp $(LIB_DIR)/glad/glad.c -I$(BREW_PREFIX)/include -L$(LIB_DIR) -L$(BREW_PREFIX)/lib -lglfw -framework OpenGL
	./main
