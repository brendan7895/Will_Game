using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;

    public GameObject iconPrefab;
    List<CompassMarkers> compassMarkers = new List<CompassMarkers>();

    float compassUnit;

    public float maxDistance = 200;

    public CompassMarkers maron;
    public CompassMarkers seahorse;
    public CompassMarkers shark;

    void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddMarker(maron);
        AddMarker(seahorse);
        AddMarker(shark);
    }

    // Update is called once per frame
    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0f, 1f, 1f);

        foreach(CompassMarkers marker in compassMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

            float dist = Vector2.Distance(new Vector2(player.transform.position.x, player.position.z), marker.position);
            float scale = 0;

            if(dist < maxDistance)
            {
                scale = 1f - (dist / maxDistance);
            }

            marker.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    public void AddMarker(CompassMarkers marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        compassMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(CompassMarkers marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        return new Vector2(compassUnit * angle, 0f);
    }
}
