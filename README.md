# RowadProject
The pupose of this project is to understand the Controller RayCasting In VR 
The Steps:-
1. Make a new Scene (Remember to Delete Main Camera)
2. get from the starter assets( XR Origin (XR Rig) - XR Interaction manager - Event System)
3. Make your own Environment
4. make a script called "SetupRayInteractors"
    4.1. make 2 Serializedfield for Left & Right Controllers
    4.2. In Start() method, check if there is any XRRayInteractor// why?
          - **Safety Check:** Ensures that the controller GameObject actually has the    XRRayInteractor component attached before we try to use it
        4.2.2 If not add Component(XRRayInteractor) and disabled it
    4.3. make ConfigureRayInteractor() method
        4.3.1. define the length of Ray
        4.3.2. define the start tranform for the ray to begain form
        4.3.4. Add XRRayInteractor line Visual in spector
        4.3.5. define line width 
5. make a gameobject called RayCastMnager and drag and drop the SetupRayInteractors script on the gameObject then assign the L&R Controllers in the spector 

NOW.... let's make Inputs to connect to the Controllers

6.make a script (VRInputManager)
    6.1. make a serializedfield for InputActionRefence called ActivateAction
    6.2. make a variable XRRayInteractor rayInteractor 
    6.3. In Awake() GetComponent XRRayInteractor to make a reference  to it
    6.4. make onEable() function and inside this function do:
        6.4.1. make action.performed that make rayInteractor.enabled =true
                        ctx-------> CallBackContext
        6.4.2. make action.canceled that make rayInteractor.enabled =false
                        ctx-------> CallBackContext
7.In the sepctor, assign VRInptManager to Left and Right Contorllers gameObjects
8.Search in the project  tab about XRI Left and Right Interaction/Activation
9.aaign XRI Left Interaction/activation to left contorller and same as for Right Contorlller
   TEST IT ONT IN SPECTOR (In PlaySettings, make Input manager both)

And now for Target code 

10. in the scene make a cube object and name it (Target)
11. add XR Simple Interactor to the targe gameObject
12. make a script named (SampleTarget)
    12.1. make 2 private serialedfield materials 
        there names are defaultmaterial and hitmaterial
    12.2. make serialedfield for XRRayInteractable 
    12.3. make private attribute for meshRender for the target
    12.4. make attribute privte XRSimpleInteractor 
    12.5. in start() method 
        12.5.1. GetComponent for meshRender and for XRSimpleInteractor and place them in the Inspector or it will give error of nullReference
        12.5.2. make 2 AddListeners for the Interactable one for hoverEntered and one for hoverExit 
        12.5.3. make 2 methods (OnHoverEnter() - OnHoverExit)
        12.5.4. in the methods make the material changes
        (Do not forget to OnDisable to prevent memory leak)
13. attach the script (SimpleTarget) to target gameObject in the spector and assign all materials




# 🔹 RowadProject – Updated God-Mode Setup (Unity 6.2.2f1 + OpenXR + XRI 3.2.1)

The purpose of this project is to **understand and implement controller raycasting in VR** with proper input handling and a simple interactive target.

---

## ✅ Step 1 – New Scene

* Create a new Scene.
* Delete the default **Main Camera**.
* *Reason:* XR Origin prefab has its own tracked camera.

---

## ✅ Step 2 – Add Core XR Objects

From **Starter Assets → Prefabs**:

* Drag into Hierarchy:

  * **XR Origin (XR Rig)**
  * **XR Interaction Manager**
  * **Event System**
* *Reason:* These handle tracking, interactions, and UI events.

---

## ✅ Step 3 – Build Environment

* Add **Plane** at `(0,0,0)` → floor.
* Add **Cube Plinth** → place slightly forward.
* Add Materials → color objects for visibility.

---

## ✅ Step 4 – Setup Ray Interactors (Script)

Attach `SetupRayInteractors.cs`  to an empty GameObject (e.g., `RaycastManager`).

### Inside the script:

* **4.1. Serialized fields** → Left & Right controllers.
* **4.2. Start() check:**

  * If no **XRRayInteractor** → add one and start disabled.
  * *Reason:* Safety check → prevents NullReference if component missing.
* **4.3. ConfigureRayInteractor():**

  * Set max ray length (e.g., 20m).
  * Set ray origin = controller transform.
  * Limit interaction to `"Target"` layer.
  * Add **XRInteractorLineVisual** (line width, material).

👉 In Inspector: assign Left & Right controller GameObjects.

---

## ✅ Step 5 – Input Handling

Attach `VRInputManager.cs`  to each Controller.

* **5.1. Serialized InputActionReference** → `ActivateAction`.
* **5.2. Awake():** get reference to XRRayInteractor.
* **5.3. OnEnable():**

  * `performed` → enable Ray.
  * `canceled` → disable Ray.
  * *Reason:* Saves GPU when ray not used.

👉 In Inspector:

* Assign **ActivateAction** to:

  * Left → `XRI Left Interaction/Activate`
  * Right → `XRI Right Interaction/Activate`.

---

## ✅ Step 6 – Interactive Target

* Create Cube → rename **Target**.
* Add **XRSimpleInteractable**.
* Attach `SimpleTarget.cs` .

### Inside the script:

* Serialized fields:

  * `defaultMaterial`
  * `hitMaterial`
* In `Start()`:

  * Get **MeshRenderer** + **XRSimpleInteractable**.
  * Subscribe to `hoverEntered` / `hoverExited`.
* On hover enter → switch to `hitMaterial`.
* On hover exit → revert to `defaultMaterial`.
* OnDisable → remove listeners (*Reason:* prevents memory leaks).

👉 In Inspector: assign both materials + interactable reference.

---

## ✅ Step 7 – Layer Setup

* Create new Layer → `"Target"`.
* Assign **Target Cube** to `"Target"`.
* *Reason:* Ray interactor only interacts with Target layer (set in SetupRayInteractors).

---

## ✅ Step 8 – Test

* Enter Play Mode.
* Press **Trigger/Grip (Activate)** → controller ray appears.
* Point ray at Target cube → material changes on hover.

---

# ⚡ Improvements Added

1. **Scripts cleaned up & explained** (safety checks, null prevention).
2. **Layer filtering** → prevents rays hitting unintended objects.
3. **Memory management** → listeners removed in `OnDisable()` in `SimpleTarget`.
4. **Best practices** → disable rays until input action performed (perf gain).
5. **Separation of concerns** →

   * `SetupRayInteractors` = configure rays.
   * `VRInputManager` = enable/disable rays with input.
   * `SimpleTarget` = handle interaction feedback.

---

✅ Now you have a **robust VR Raycasting demo**:

* **Controller Rays** → appear on input.
* **Ray Visuals** → configurable material/width.
* **Interactive Target** → feedback on hover.
