using UnityEngine;

public class Utility : MonoBehaviour
{
    // Vector3 を Vector3Int に変換
    public static Vector3Int ToVector3Int(Vector3 v)
    {
        return new Vector3Int(
            Mathf.RoundToInt(v.x),
            Mathf.RoundToInt(v.y),
            Mathf.RoundToInt(v.z));
    }

    // Vector3 を Vector3Int に変換(切り捨て)
    public static Vector3Int FloorToVector3Int(Vector3 v)
    {
        return new Vector3Int(
            Mathf.FloorToInt(v.x),
            Mathf.FloorToInt(v.y),
            Mathf.FloorToInt(v.z));
    }
}
