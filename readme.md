<div align="center">

# 🏃‍♀️ Player Movement Controller
### *Smooth Physics & Snappy Combat*

<br>

> *The core logic behind the character's movement. Handles running, jumping, and looking cool while doing it.* ✨

<div align="center">

<br>

![Unity](https://img.shields.io/badge/Unity-2D_Physics-black?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Scripting-9b59b6?style=for-the-badge&logo=c-sharp&logoColor=white)

</div>


## 🎀 How It Works
This script uses `Rigidbody2D` for physics based movement, ensuring the character interacts naturally with the world (gravity, collisions, etc.).

### ✨ Key Features
* **💨 Horizontal Movement:** Uses `Input.GetAxisRaw` for snappy, responsive turning without that "floaty" feeling.
* **🦘 Ground Check:** Uses **Raycasting** to detect the floor. No more infinite jumping glitches!
* **⚔️ Combat Ready:** Listens for `Mouse0` clicks to trigger attack animations via `tryToATT()`.
* **💃 Animation Sync:** Automatically sends `xVelocity` and `yVelocity` to the Animator so the character runs and falls at the right speeds.

---

## 🛠️ The Logic
A peek under the hood at how we handle the math.

| Function | What it does |
| :--- | :--- |
| `handleinput()` | Listens for Space (Jump) and Mouse Click (Attack). |
| `tryToJump()` | Checks if `isGround` is true before applying force. Safety first! 👷‍♀️ |
| `flip()` | Rotates the character 180° so they always face the right way. |
| `OnDrawGizmos()` | Draws a line in the editor so we can see the ground check working. 📏 |

---

## 📝 Setup Guide
1.  **Attach:** Drag this script onto your Player GameObject.
2.  **References:** It automatically finds the `Rigidbody2D` and `Animator` on `Awake()`.
3.  **Layers:** Make sure to set the **"Whats The Layer"** variable in the inspector to your Ground layer (so you can actually jump!).

> *Dev Note: Updated to use `rb.linearVelocity` for modern Unity 6 physics support!* 🚀

<div align="center">
  <i>"fixing the double tryToJump shit"  A Legacy</i> 
</div>
