using UnityEngine;
using WestportTheGame.Player;
using WestportTheGame.Vehicles;

namespace WestportTheGame
{
    public sealed class PrototypeSceneBootstrap : MonoBehaviour
    {
        private Material ground, road, building, playerMat, carMat;
        private void Start() { ground=Mat(new Color(.24f,.42f,.22f)); road=Mat(new Color(.12f,.13f,.15f)); building=Mat(new Color(.58f,.48f,.36f)); playerMat=Mat(new Color(.15f,.45f,.9f)); carMat=Mat(new Color(.8f,.12f,.08f)); Light(); Ground(); Roads(); Buildings(); var p=Player(); Camera(p.transform); Car(new Vector3(0,.55f,-10)); }
        private static Material Mat(Color c) { var m=new Material(Shader.Find("Universal Render Pipeline/Lit")??Shader.Find("Standard")); m.color=c; return m; }
        private static void Light() { var o=new GameObject("Sun"); var l=o.AddComponent<Light>(); l.type=LightType.Directional; l.intensity=1.2f; o.transform.rotation=Quaternion.Euler(50,-30,0); }
        private void Ground() { var o=GameObject.CreatePrimitive(PrimitiveType.Plane); o.name="Westport Greybox Ground"; o.transform.localScale=new Vector3(8,1,8); o.GetComponent<Renderer>().sharedMaterial=ground; }
        private void Roads() { Road("Bridge Street",new Vector3(0,.03f,0),new Vector3(5,.1f,90)); Road("Shop Street",new Vector3(-18,.04f,4),new Vector3(46,.1f,5)); Road("James Street",new Vector3(16,.05f,15),new Vector3(5,.1f,56)); Road("The Mall",new Vector3(-5,.05f,28),new Vector3(60,.1f,5)); }
        private void Road(string n,Vector3 p,Vector3 s) { var o=GameObject.CreatePrimitive(PrimitiveType.Cube); o.name=n; o.transform.position=p; o.transform.localScale=s; o.GetComponent<Renderer>().sharedMaterial=road; }
        private void Buildings() { var lots=new[]{new Vector3(-12,2,-12),new Vector3(12,3,-12),new Vector3(-12,2.5f,12),new Vector3(12,2,12),new Vector3(-30,3,4),new Vector3(28,2.5f,4),new Vector3(-26,2,28),new Vector3(25,3.5f,28),new Vector3(0,2.5f,42)}; for(var i=0;i<lots.Length;i++){var o=GameObject.CreatePrimitive(PrimitiveType.Cube);o.name=$"Placeholder Building {i+1:00}";o.transform.position=lots[i];o.transform.localScale=new Vector3(8,lots[i].y*2,7);o.GetComponent<Renderer>().sharedMaterial=building;} }
        private GameObject Player() { var o=GameObject.CreatePrimitive(PrimitiveType.Capsule); o.name="Player"; o.transform.position=new Vector3(0,1,-25); Destroy(o.GetComponent<CapsuleCollider>()); o.AddComponent<CharacterController>(); o.AddComponent<ThirdPersonWalker>(); o.GetComponent<Renderer>().sharedMaterial=playerMat; return o; }
        private static void Camera(Transform t) { var o=new GameObject("Main Camera"){tag="MainCamera"};o.AddComponent<Camera>();o.AddComponent<AudioListener>();var f=o.AddComponent<PrototypeCameraFollow>();f.Target=t;o.transform.position=t.position+new Vector3(0,8,-10); }
        private void Car(Vector3 p) { var o=GameObject.CreatePrimitive(PrimitiveType.Cube);o.name="Starter Car";o.transform.position=p;o.transform.localScale=new Vector3(2,1,4);o.GetComponent<Renderer>().sharedMaterial=carMat;Destroy(o.GetComponent<BoxCollider>());var b=o.AddComponent<Rigidbody>();b.mass=1200;b.constraints=RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;o.AddComponent<SimpleCarController>();o.AddComponent<VehicleInteractor>(); }
    }
}
