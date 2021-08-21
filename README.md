# UnityMLAgentsTraining
This repository is used to publish my Unity projects used to learn mlagents in order to create reliable AIs. To get started with ml-agents please refer to https://github.com/Unity-Technologies/ml-agents

## PillarsGame
#### Game rules
The player is a cube that has to touch the cylinder placed in the center of one of the nine square floors randomly. The floors change color randomly from green to yellow and then from yellow to red. If the cube is on a red floor the episodes ends and the agents is rewarded -1 points. If the cube goes outside of the playfield the episode ends and the agent is rewarded with -1 points. If the cube touches the cylinder the agent is rewarded with 1 point.
#### Results
Config file name | Trainer | Mean reward
---------------- | ------- | ------------------------
To be completed | poca | 0.6342
To be completed | sac  | 0.6038
To be completed | ppo  | 0.5426

## Game 2
