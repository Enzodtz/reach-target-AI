# snake-game-AI
A Machine Learning project in Unity to teach the agent how to play the snake game.

## Running

The project is developed using the Unity MLAgents package, so there are 3 modes that you can run it. To change the mode, `Inspect` the Agent, and open the `Behaviour Parameters` group, then you will be able to select one.

#### Default

This is where you train your agents, the MLAgents package trains them by connecting unity to a python server. 
To setup it, follow the instructions of MLAgent instalation for the unity's `1.9.0` version.
Then, run it via the MLAgents CLI.

#### Inference

In this mode, you can run my pre-trainned brain, or add yours into the `NN-Brain` section of the `Behaviour Parameters` group.

#### Heuristic

To test it, you can run it in the Heuristic mode, where you will be able to test the agent with the input arrows or WASD.

## How it works

Each Agent and each target starts in a random position, and if he reaches the target, it will get a point. 
If the Agent hit the limits of the floor, it will die.
The Agents is able to see his own X and Y position, and the target's X and Y position.

## Modifying

You can add more agents if you want by adding the `Environment` prefab, or copying the `Environment` instance.
