using UnityEngine;

namespace WestportTheGame.World
{
    /// <summary>Converts WGS84 latitude/longitude into a local Unity metre grid.</summary>
    public sealed class GeoReference : MonoBehaviour
    {
        [Header("Westport origin (WGS84)")]
        [SerializeField] private double originLatitude = 53.8008;
        [SerializeField] private double originLongitude = -9.5167;

        [Tooltip("Unity metres represented by one degree of latitude/longitude at the origin.")]
        [SerializeField] private float metresPerDegree = 111_320f;

        public Vector3 ToUnity(double latitude, double longitude, float altitudeMetres = 0f)
        {
            var latitudeScale = metresPerDegree;
            var longitudeScale = metresPerDegree * Mathf.Cos((float)(originLatitude * Mathf.Deg2Rad));
            var east = (float)((longitude - originLongitude) * longitudeScale);
            var north = (float)((latitude - originLatitude) * latitudeScale);
            return new Vector3(east, altitudeMetres, north);
        }

        public (double latitude, double longitude) FromUnity(Vector3 position)
        {
            var longitudeScale = metresPerDegree * Mathf.Cos((float)(originLatitude * Mathf.Deg2Rad));
            return (originLatitude + position.z / metresPerDegree,
                originLongitude + position.x / longitudeScale);
        }
    }
}
