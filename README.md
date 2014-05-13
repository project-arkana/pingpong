pingpong
========

Quick test of Unity RPC ordering
- Open the Project file in Unity
- Load Main.scene
- Build and Run a standalone using Main.scene
- Using both the Unity IDE and the standalone build: 
- Start a server
- Connect locally on the client
- Observe:
-   The server sends PING and then PONG
-   The client receives PONG and then PING
