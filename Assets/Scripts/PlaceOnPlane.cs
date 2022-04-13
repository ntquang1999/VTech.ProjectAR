using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.ProjectAR
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        [SerializeField]
        GameObject m_Indicator;
        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }
        public bool objectPlaced = false;
        bool posValid = false;
        public PlayerController controller;
        public Camera camera;
        public Text text;
        [SerializeField] GameObject moveAnim;
        [SerializeField] GameObject placeAnim;
        [SerializeField] GameObject shakeBtn;
        public ARPlaneManager planeManager;

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (!objectPlaced && m_RaycastManager.Raycast(Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f)), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                moveAnim.SetActive(false);
                placeAnim.SetActive(true);
                text.text = "Đã phát hiện được mặt phẳng, chạm vào màn hình để đặt ống quẻ";
                var hitPose = s_Hits[0].pose;
                
                if (spawnedObject == null)
                {
                    //objectPlaced = true;
                    //controller.objectPlaced = true;
                    spawnedObject = Instantiate(m_Indicator, hitPose.position, m_PlacedPrefab.transform.rotation);
                }
                else
                {
                    spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }

                posValid = true;
            }
                if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (posValid)
            {
                if(!objectPlaced)
                {
                    DestroyImmediate(spawnedObject);
                }
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                  
                    objectPlaced = true;
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, Quaternion.Euler(hitPose.rotation.x, hitPose.rotation.y + 90, hitPose.rotation.z));
                }
                text.gameObject.SetActive(true);
                placeAnim.SetActive(false);
                text.text = "Di chuyển thiết bị từ từ để quan sát";
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
