CollisionSparks
This Unity script, CollisionSparks, is designed to trigger a visual sparks effect at the point of impact during collisions. The effect activates when the impact force exceeds a specified threshold and automatically deactivates when the collision ends.

Setup Instructions
Attach Script: Add the CollisionSparks script to the GameObject with the Collider where you want sparks to appear upon collision.

Assign References:

Sparks Trigger: Drag your sparks GameObject (e.g., Sparks_VFX) to the sparksTrigger field in the Inspector. This GameObject will move to the collision point when a collision occurs.
Scrape Sparks: Drag the particle effect GameObject (e.g., Spawner from Scrape Sparks VFX asset) to the scrapeSparks field.
Set Impact Threshold: Adjust the impactThreshold to control the minimum impact force needed to trigger the spark effect. By default, this is set to 5f.

Usage Notes
The sparksTrigger is initially deactivated to ensure it only activates during a qualifying collision.
Upon collision:
If the impact force exceeds impactThreshold, sparksTrigger is moved to the collision point and aligned with the collision normal.
The scrapeSparks particle effect starts playing.
When the collision ends, sparksTrigger deactivates, and scrapeSparks stops.
Asset Information
This script is compatible with Scrape Sparks VFX from the Unity Asset Store.
