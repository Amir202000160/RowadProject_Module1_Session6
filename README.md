# RowadProject
The pupose of this project is to understand the Controller RayCasting In VR 
The Steps:-
1. Make a new Scene (named as you like ... let's say it's name (Session6))
  1.1.Remember to Delete Main Camera
2. get from the starter assets( XR Origin (XR Rig) - XR Interaction manager - Event System -    XR Device Simulator)
  2.1. go back to your Scene (Session6) and make a gameObject Called(VR) and put ( XR Origin   (XR Rig) - XR Interaction manager - Event System - XR Device Simulator) as a childern for GameObject (VR)
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
        4.3.6. define the layer of rayCast by "Lamp"
5. make a gameobject called RayCastMnager and drag and drop the SetupRayInteractors script on the gameObject then assign the L&R Controllers in the spector by drag and Drop 

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
7.In the sepctor, assign VRInptManager Script to Left and Right Contorllers gameObjects as a Component By Drag and drop the Script on Left and Right Contorllers gameObjects.
8.Search in the project  tab about XRI Left and Right Interaction/Activation
9.assign XRI Left Interaction/activation to left contorller and same as for Right Contorlller
by drag and drop  XRI Left Interaction/activation and right ib VRInputManager Component on the Controllers gameObjects

   TEST IT ONT IN SPECTOR (In PlaySettings, make Input manager both)

And now for Target code 

10. in your scene make a cube object and name it (Target)
11. add XR Simple Interactor to the targe gameObject as a Component (Add Component)
12. make a script named (SampleTarget)
    12.1. make 2 private serialedfield materials 
        there names are defaultmaterial and hitmaterial
    12.2. make serialedfield for XRRayInteractable 
    12.3. make private attribute for meshRender for the target
    12.4. make attribute privte XRSimpleInteractor 
    12.5. in Awake() method 
        12.5.1. GetComponent for meshRender and for XRSimpleInteractor and place them in the Inspector or it will give error of nullReference
    12.6. in Enable() method
        12.6.1. Call 2 addListeners one for OnHoverEnter and another for OnHoverExit
    12.7. in Start()
        12.7.1. make the Material of meshRender of the Target gameObject = defaultMaterial
    12.8. make 2 methods (OnHoverEnter() - OnHoverExit)
        12.8.1. in the methods make the material changes
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




Stack: **Unity 6.2.2f1**, **OpenXR**, **XR Plug-in Management 4.5.1**, **XR Interaction Toolkit (XRI) 3.2.1**, **Input System**.

---

# 🧱 Block 0 — Project & Packages (one-time)

**Goal:** Make sure the project has the correct XR + Input packages.

**Editor steps**

1. **Create / open** a 3D (URP OK) project.
2. **Project Settings → XR Plug-in Management**

   * PC (if you’ll test with Link): **OpenXR = ON**
   * Android (for Quest build later): **OpenXR = ON**
3. **Window → Package Manager (Unity Registry)**

   * Install **XR Interaction Toolkit** (3.2.1).
   * In XRI’s **Samples** (right pane): import **Starter Assets** and (optional) **XR Device Simulator**.
4. **Project Settings → Player → Other Settings**

   * **Active Input Handling** = **Input System (New)**.

**Why:** OpenXR is the runtime; XRI gives us Interactors/Interactables; Starter Assets give ready input actions.

**Mini-test:** Create an empty scene → *Play* (no errors about Input System or OpenXR).

**Common mistakes:**

* If you still have “Both” input systems enabled and get warnings, switch to **Input System (New)** only.

---

# 🧱 Block 1 — Scene Scaffold

**Goal:** Basic XR scene that compiles.

**Editor steps**

1. **File → New Scene** (call it `Session6`).
2. Delete **Main Camera**.
3. **GameObject → XR → XR Origin (Action-based)**.
4. **GameObject → XR → XR Interaction Manager**.
5. **GameObject → UI → Event System**.
6. (Optional) **GameObject → XR → Device Simulator**.
7. Create **Empty** `VR` and drag the three XR objects under it (for organization).
8. **GameObject → 3D Object → Plane** (as floor) at (0,0,0).

**Why:** XR Origin has the tracked camera and controller anchors. Manager routes interactions. Event System enables UI.

**Mini-test:** *Play* with a headset connected (or with Device Simulator): no red errors.

**Common mistakes:**

* Don’t keep the **Main Camera**; XR Origin includes its own camera.

---

# 🧱 Block 2 — Target Layer + Target Object

**Goal:** Make a simple object that our ray will be allowed to hit.

**Editor steps**

1. Top-right **Layers → Edit Layers…** → create user layer **“Target”**.
2. **GameObject → 3D Object → Cube**. Rename to **Target**.
3. Set **Target**’s **Layer = Target**.
4. **Add Component → XRSimpleInteractable** (on the Target).

**Why:** Layer filtering is a huge performance & clarity boost. We’ll make our ray only check **Target**.

**Mini-test:** The cube exists and shows **XRSimpleInteractable** in the Inspector.

**Common mistakes:**

* If you forget to put the cube on the **Target** layer, the ray (later) won’t register it.

---

# 🧱 Block 3 — Quick Ray (no code yet)

**Goal:** Prove the concept with a **built-in** ray so juniors see success immediately.

**Editor steps**

1. Expand **XR Origin (Action-based)** → find children **LeftHand Controller** and **RightHand Controller**.
2. On **RightHand Controller**: **Add Component → XR Ray Interactor**.
3. Also add **XR Interactor Line Visual** (to see the beam).
4. Set **XR Ray Interactor → Max Raycast Distance = 6**.
5. (We’ll set mask via code in the next block, but for a smoke test, leave defaults.)

**Mini-test:** *Play*; you should see a ray (always on) from right controller. It may hit lots of things—that’s ok for now.

**Why:** Immediate visual feedback builds confidence before coding.

**Common mistakes:**

* If the line doesn’t show, ensure **XR Interactor Line Visual** is enabled and the play camera is in view of something.

---

# 🧱 Block 4 — Configure Rays by Script

**Goal:** Add a manager that **adds/standardizes** rays on both controllers and restricts them to the **Target** layer.

**Create script** `SetupRayInteractors.cs` (in a **Scripts** folder) and **attach** it to an empty `RaycastManager` in the scene.
In the Inspector, drag **LeftHand Controller** and **RightHand Controller** onto the fields.

```csharp
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetupRayInteractors : MonoBehaviour
{
    [Header("Assign controller GameObjects from XR Origin")]
    [SerializeField] private GameObject leftController;
    [SerializeField] private GameObject rightController;

    [Header("Ray Tuning")]
    [SerializeField] private float maxDistance = 6f;
    [SerializeField] private float lineWidth = 0.01f;
    [SerializeField] private string raycastLayerName = "Target";

    private void Start()
    {
        ConfigureOne(leftController);
        ConfigureOne(rightController);
    }

    private void ConfigureOne(GameObject controllerGO)
    {
        if (!controllerGO)
        {
            Debug.LogWarning("[SetupRayInteractors] Missing controller reference.");
            return;
        }

        // Ensure ray exists, start disabled (perf-friendly)
        var ray = controllerGO.GetComponent<XRRayInteractor>();
        if (!ray) ray = controllerGO.AddComponent<XRRayInteractor>();
        ray.enabled = false;
        ray.maxRaycastDistance = maxDistance;

        // Restrict to the Target layer
        int layer = LayerMask.NameToLayer(raycastLayerName);
        ray.raycastMask = (layer == -1) ? ~0 : (1 << layer);

        // Visual line
        var line = controllerGO.GetComponent<XRInteractorLineVisual>();
        if (!line) line = controllerGO.AddComponent<XRInteractorLineVisual>();
        line.lineWidth = lineWidth;
        line.enabled = true;
    }
}
```

**Why:** “Separation of concerns.” One place controls both rays consistently (length, mask, visuals) and prevents missing components.

**Mini-test:** *Play* → no ray visible (by design). We’ll enable it via input in the next block.

**Common mistakes:**

* Forgetting to assign the **Left/Right controller** GameObjects in the Inspector.

---

# 🧱 Block 5 — Input-Driven Ray (Press to show)

**Goal:** Ray appears **only while a button is held** (event-driven; saves perf).

**Create script** `VRInputManager.cs`. **Add it** to **both** controllers (Left/Right).
**Assign InputActionReference** in Inspector:

* Left → `XRI LeftHand Interaction / Activate`
* Right → `XRI RightHand Interaction / Activate`
  (These live in the **XRI Default Input Actions** asset you imported from Samples. Use the Project search to find them.)

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInputManager : MonoBehaviour
{
    [Header("Drag the XRI ... / Activate action here")]
    [SerializeField] private InputActionReference activateAction;

    private XRRayInteractor ray;

    private void Awake()
    {
        ray = GetComponent<XRRayInteractor>();
        if (!ray)
            Debug.LogError("[VRInputManager] XRRayInteractor is required on the same GameObject.");
    }

    private void OnEnable()
    {
        if (activateAction != null)
        {
            activateAction.action.performed += OnPerformed;
            activateAction.action.canceled  += OnCanceled;
            activateAction.action.Enable();
        }

        if (ray) ray.enabled = false; // start hidden
    }

    private void OnDisable()
    {
        if (activateAction != null)
        {
            activateAction.action.performed -= OnPerformed;
            activateAction.action.canceled  -= OnCanceled;
            activateAction.action.Disable();
        }
    }

    private void OnPerformed(InputAction.CallbackContext _)
    {
        if (ray) ray.enabled = true;
    }

    private void OnCanceled(InputAction.CallbackContext _)
    {
        if (ray) ray.enabled = false;
    }
}
```

**Why:** Juniors clearly see the mapping: “input event → enable ray”. No polling in `Update()`.

**Mini-test:** *Play*. Hold **Activate** (usually Trigger/Grip per binding) → ray shows; release → ray hides.

**Common mistakes:**

* Assigned the wrong action (e.g., “Select” instead of “Activate”).
* Action reference left **None** (ray never turns on).

---

# 🧱 Block 6 — Visual Feedback on Hover

**Goal:** When the ray **hovers** the Target, it changes color.

**Create two materials** in your project: `DefaultMat` (any color), `HitMat` (different color).
**Create script** `SimpleTarget.cs` and **add it** to the **Target** cube.
Make sure **XRSimpleInteractable** is also on the Target.

```csharp
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleTarget : MonoBehaviour
{
    [Header("Assign materials")]
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material hitMaterial;

    private MeshRenderer meshRenderer;
    private XRSimpleInteractable simple;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        simple = GetComponent<XRSimpleInteractable>();

        if (!simple)
            Debug.LogError("[SimpleTarget] Requires XRSimpleInteractable on the same GameObject.");
    }

    private void Start()
    {
        if (meshRenderer && defaultMaterial)
            meshRenderer.material = defaultMaterial;
    }

    private void OnEnable()
    {
        if (simple != null)
        {
            simple.hoverEntered.AddListener(OnHoverEntered);
            simple.hoverExited.AddListener(OnHoverExited);
        }
    }

    private void OnDisable()
    {
        if (simple != null)
        {
            simple.hoverEntered.RemoveListener(OnHoverEntered);
            simple.hoverExited.RemoveListener(OnHoverExited);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs _)
    {
        if (meshRenderer && hitMaterial)
            meshRenderer.material = hitMaterial;
    }

    private void OnHoverExited(HoverExitEventArgs _)
    {
        if (meshRenderer && defaultMaterial)
            meshRenderer.material = defaultMaterial;
    }
}
```

**Why:** Students learn the event model: the **Interactable** fires **hover** events; our script reacts.

**Mini-test:** *Play*. Hold **Activate** to show the ray. Aim at **Target** → it switches to `HitMat`. Move away → reverts to `DefaultMat`.

**Common mistakes:**

* Forgot **XRSimpleInteractable** on the Target.
* Didn’t assign the materials in the Inspector.

---

# 🧱 Block 7 — Device Simulator (No Headset)

**Goal:** Practice without a headset.

**Editor steps**

1. Ensure **XR Device Simulator** is in your scene.
2. *Play*. Use these keys (defaults):

   * **Right mouse**: look around
   * **WASD / QE**: move
   * **1/2**: switch devices
   * **T**: “select/activate” action (shows the ray)
   * **X**: swap between left/right hand

**Why:** Great for students at home without a headset.

**Mini-test:** Press **T** → ray appears; hover the cube → color changes.

**Common mistakes:**

* Scene camera not pointed at the Target: move closer with WASD.

---

# 🧱 Block 8 — Nice Polishes (choose any)

**A) Hide Ray when nothing valid is hit**

* On each **XRRayInteractor**, enable **Hide Raycast Line If No Hit** (or set **Line Visual → “Only Show When Hit”** style by code).
  **Why:** Cleaner UX.

**B) Per-hand responsibilities (UI vs 3D)**

* Put UI on a **UI** layer; set **Left ray mask = UI**, **Right ray mask = Target**.
  **Why:** Prevents “one ray hitting everything.”

**C) Small reticle**

* Add a tiny sphere at the hit point via **XR Interactor Line Visual → Reticle** to help depth perception.

---

## Folder & Hierarchy Snapshot (for juniors)

```
Assets/
  Materials/
    DefaultMat.mat
    HitMat.mat
  Scripts/
    SetupRayInteractors.cs
    VRInputManager.cs
    SimpleTarget.cs
  XRI Samples/ (auto from package)
Scenes/
  Session6.unity

Hierarchy
└─ VR
   ├─ XR Origin (Action-based)
   │  ├─ Camera Offset
   │  │  ├─ Main Camera (from XR Origin)
   │  │  ├─ LeftHand Controller  (has XRRayInteractor + Line Visual + VRInputManager)
   │  │  └─ RightHand Controller (has XRRayInteractor + Line Visual + VRInputManager)
   ├─ XR Interaction Manager
   ├─ Event System
   └─ XR Device Simulator (optional)
└─ RaycastManager (SetupRayInteractors)
└─ Plane (floor)
└─ Target (Cube, Layer=Target, XRSimpleInteractable, SimpleTarget)
```

---

## What students learn (explicitly)

* **Interactor vs Interactable**: the “hand” casts a ray; the “cube” responds.
* **Events, not polling**: `hoverEntered/Exited`, `performed/canceled`.
* **Separation of concerns**:

  * `SetupRayInteractors` = build/configure rays
  * `VRInputManager` = connect input → enable/disable
  * `SimpleTarget` = visual feedback logic
* **Safety**: start rays **disabled** and enable only on demand (perf win).
* **Filtering**: layers keep interactions intentional and fast.

---

If you want, I can package this as a **Markdown lab sheet** (with checkboxes) or a **GitHub README** formatted exactly like your Lab-Guide repo so you can teach while building live.

