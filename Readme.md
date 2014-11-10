Script|Description
------|-----------
Cursor2D|Script that manages the visibility of the mouse cursor aswell as the image that that is used as the cursor

Draggable|Script that allows any object to be dragged, also allows locking the X,Y axis

GotoLevel|loads the specified level by clicking the mouse or hitting the return key

InstantiateAtClick|creates the specified item at the 2D mouse location

IntervalSpawner|spawns a collection of items either all at once or 1 randomly at a set interval

LookAtMouse|Rotates the object to look at the mouse position

PlatformerMovement|left,right and jump aswell as onGround checking to prevent excessive jumping

UrlButton|script that opens a url when clicked

FlagManager|script that handles global flags, flags being the binary true or false value

OscillatingMovement|script that moves an object in an oscilating pattern

InstantPathMovement|script that animates an object by settings its position to a set of positions instantly(no smooth animation)

SmoothPathMovement|script that animates an object by transitioning from a set of positions smoothly (lerp,slerp,MoveTowards)

MoveToPoint|EaseIn/Out or instant movement that animates to a set position

GameManager/GameManagerEditor|Manages invisible but important background systems like score,health,inventory and anything else

CheckpointManager/CheckpointManagerEditor/CheckpointScript|Script that manages all gameObjects that have the CheckpointScript, which tracks if the attached collider has been triggered
	
DualStickController|Dual Stick (4 direction move/attack) controller that will make sprite face in whatever direction you are attacking
	
TriggerAreaLookAtTag|Will track(rotate, lookat) object with tag when the object enters the trigger area and stop when object leaves (think, tower defense)
	
DestroyOffscreen|Will destroy the gameobject when its no longer visible to the renderer
