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



TRY IT OUT !!!!!!!!!!!