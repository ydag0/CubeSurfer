using UnityEngine;
public class GameSettings : Singleton<GameSettings>
{
    [Header("Camera")]
    [Range(0.1f,10.0f)]
    [Tooltip("Higher value for faster camera follow")]
    public float cameraLerpMultiplier;
    [Header("Character")]
    public float characterSpeed;
    [Tooltip("Extra Speed for Side Move")]
    public float characterSideSpeed;
    [Header("Cubes")]
    public Transform cubesParentTransform;
    
    [Tooltip("World Boundary X")]
    public float worldBoundaryX;

}
public static class Tags
{
    public static string collactableCubeTag = "Collectable";
    public static string unCollactableCubeTag = "UnCollectable";
    public static string firstCubeTag = "CubeParent";
    public static string characterTag = "Player";
    public static string untagged = "Untagged";
    public static string layerName = "Cubes";
    public static string gameEndTag = "Finish";
}
