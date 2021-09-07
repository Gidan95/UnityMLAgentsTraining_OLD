# UnityMLAgentsTraining
This repository is used to publish my Unity projects used to learn mlagents in order to create reliable AIs. To get started with ml-agents please refer to https://github.com/Unity-Technologies/ml-agents

## PillarsGame
![Alt Text](https://media.giphy.com/media/PlvCwjLVA9LCSfcQOU/giphy.gif?cid=790b7611999c32a417a73b425a2083f81cfb6a587a13b281&rid=giphy.gif&ct=g)
#### Game rules
The player is a cube that has to touch the cylinder placed in the center of one of the nine square floors randomly. The floors change color randomly from green to yellow and then from yellow to red. If the cube is on a red floor the episodes ends and the agents is rewarded -1 points. If the cube goes outside of the playfield the episode ends and the agent is rewarded with -1 points. If the cube touches the cylinder the agent is rewarded with 1 point.
#### Results
Config file name | Trainer | Mean reward
---------------- | ------- | ------------------------
To be completed | poca | 0.656
To be completed | sac  | 0.6038*
To be completed | ppo  | 0.4343

\* value is not correct because the model has been trained with faster floor switch times. I will update it as soon as possible

#### Observations
~~I think I can achieve much better training results by using stacked vectors so that the agent can remember previous states and manage better the yellow zones. For example if the agent is in a yellow zone it can understand if it has time to reach the objective or not~~ Tested but the mean reward increases much more slowly compared to no stacked vectors at all 
